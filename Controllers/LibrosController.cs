using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs.Libro;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase {
        public readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> Get(int id) {
            var libro = await context.Libros.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<LibroDTO>(libro);
        } 

        [HttpPost]
        public async Task<ActionResult> Post(LibroCreationDTO libroCreationDTO) {
            var libro = mapper.Map<Libro>(libroCreationDTO);
            /* var existe = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            if( !existe ) {
                return BadRequest($"No existe el autor id: {libro.AutorId}");
            } */
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}