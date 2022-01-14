using AutoMapper;
using WebApiAutores.DTOs.Autor;
using WebApiAutores.Entities;

namespace WebApiAutores.Utils {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<AutorCreationDTO, Autor>();
            CreateMap<Autor, AutorDTO>();
        }
    }
}