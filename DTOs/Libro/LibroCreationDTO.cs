using System.ComponentModel.DataAnnotations;
using WebApiAutores.validations;

namespace WebApiAutores.DTOs.Libro {
    public class LibroCreationDTO {
        [FirstLetterUpperCaseAttribute]
        [StringLength(maximumLength:250)]
        [Required]
        public string titulo { get; set; }
    }
}