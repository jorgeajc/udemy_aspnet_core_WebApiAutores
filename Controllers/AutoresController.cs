using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;
using WebApiAutores.services;

namespace WebApiAutores.Controllers {
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase {

        public readonly ApplicationDbContext context;
        public readonly IService service;
        public readonly ServiceTrasient serviceTrasient;
        public readonly ServiceScoped serviceScoped;
        public readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<AutoresController> logger;

        public AutoresController(ApplicationDbContext context, IService service, 
            ServiceTrasient serviceTrasient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton, 
            ILogger<AutoresController> logger) {
            this.context = context;
            this.service = service;
            this.serviceTrasient = serviceTrasient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
        }

        [HttpGet("GUID")]
        public ActionResult ObtenerGuids() {
            return Ok(new {
                AutoresControllerTrasient = serviceTrasient.Guid,
                ServiceA_Trasient = service.ObtenerTrasient(),

                AutoresControllerScoped = serviceScoped.Guid,
                ServiceA_Scoped = service.ObtenerScoped(),

                AutoresControllerSingleton = serviceSingleton.Guid,
                ServiceA_Singleton = service.ObtenerSingleton()
            });
        }

        [HttpGet] // api/autores
        [HttpGet("listado")] // api/autores/listado
        [HttpGet("/listado")] // listado
        public async Task<ActionResult<List<Autor>>> Get() {
            logger.LogInformation("listaado de autores");
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("first")]
        public async Task<ActionResult<Autor>> FirsAutor() {
            return await context.Autores.FirstOrDefaultAsync();
        } 
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) {

            var existAutorSameName = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);
            if( existAutorSameName ) {
                return BadRequest($"Ya existe el nombre que quiere agregar: {autor.Nombre}");
            }

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id) {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if( autor == null ) {
                return NotFound();
            }
            return autor;
        }

        [HttpGet("{id:int}/{param2=default}")]
        public async Task<ActionResult<Autor>> Get(int id, String param2) {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if( autor == null ) {
                return NotFound();
            }
            return autor;
        }


        [HttpGet("nombre")]
        public async Task<ActionResult<Autor>> Get(String nombre) {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if( autor == null ) {
                return NotFound();
            }
            return autor;
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