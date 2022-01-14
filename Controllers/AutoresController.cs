using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs.Autor;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers {
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase {

        public readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/autores
        public async Task<ActionResult<List<AutorDTO>>> Get() {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreationDTO autorCreationDTO) {

            var existAutorSameName = await context.Autores.AnyAsync(x => x.Nombre == autorCreationDTO.Nombre);
            if( existAutorSameName ) {
                return BadRequest($"Ya existe el nombre que quiere agregar: {autorCreationDTO.Nombre}");
            }
            var autor = mapper.Map<Autor>(autorCreationDTO);

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutorDTO>> Get(int id) {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if( autor == null ) {
                return NotFound();
            }
            return mapper.Map<AutorDTO>(autor);
        }
 
        [HttpGet("nombre")]
        public async Task<ActionResult<List<AutorDTO>>> Get(String nombre) {
            var autores = await context.Autores.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpPut("{id:int}")] // api/autores/1 
        public async Task<ActionResult> Put(Autor autor, int id) {
            if( autor.Id != id ) {
                return BadRequest("El id del autor no coincide con el id de la url");
            }
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if( !existe ) {
                return NotFound();
            }
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] // api/autores/1 
        public async Task<ActionResult> Delete(int id) {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if( !existe ) {
                return NotFound();
            }
            context.Remove(new Autor() {Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}