using AutoMapper;
using WebApiAutores.DTOs.Autor;
using WebApiAutores.DTOs.Comentario;
using WebApiAutores.DTOs.Libro;
using WebApiAutores.Entities;

namespace WebApiAutores.Utils {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<AutorCreationDTO, Autor>();
            CreateMap<Autor, AutorDTO>();
            
            CreateMap<LibroCreationDTO, Libro>();
            CreateMap<Libro, LibroDTO>();

            CreateMap<ComentarioCreationDTO, Comentario>();
            CreateMap<Comentario, ComentarioDTO>();
        }
    }
}