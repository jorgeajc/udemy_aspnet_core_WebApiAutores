using System.ComponentModel.DataAnnotations;
using WebApiAutores.validations;

namespace WebApiAutores.Entidades {
    public class Autor {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo nombre no debe tener más de 10 carateres")]
        [FirstLetterUpperCaseAttribute]
        public String Nombre { get; set; }
    }
}