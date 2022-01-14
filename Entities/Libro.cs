using System.ComponentModel.DataAnnotations;
using WebApiAutores.validations;

namespace WebApiAutores.Entities {
    public class Libro {
        public int Id { get; set; }
        
        [Required]
        [FirstLetterUpperCaseAttribute]
        [StringLength(maximumLength:250)]
        public String Titulo { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}