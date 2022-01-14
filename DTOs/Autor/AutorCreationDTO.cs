using System.ComponentModel.DataAnnotations;
using WebApiAutores.validations;

namespace WebApiAutores.DTOs.Autor {
    public class AutorCreationDTO {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo nombre no debe tener más de 10 carateres")]
        [FirstLetterUpperCaseAttribute]

        public string Nombre { get; set; }
    }
}