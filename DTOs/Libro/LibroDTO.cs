using WebApiAutores.DTOs.Comentario;

namespace WebApiAutores.DTOs.Libro {
    public class LibroDTO {
        public int Id { get; set; }
        public string titulo { get; set; }

        public List<ComentarioDTO> Comentarios { get; set; }
        
    }
}