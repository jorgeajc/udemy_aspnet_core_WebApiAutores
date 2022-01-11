using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.validations;

namespace WebApiAutores.Entidades {
    public class Autor: IValidatableObject {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo nombre no debe tener más de 10 carateres")]
        [FirstLetterUpperCaseAttribute]
        public String Nombre { get; set; }

        // [Range(18, 120)]
        // [NotMapped]
        // public int Edad { get; set;}

        // [CreditCard]
        // [NotMapped]
        // public String Tarjeta { get; set;}

        // [Url]
        // [NotMapped]
        // public String Url { get; set;}

        public List<Libro> Libros { get; set; }

        // public int mayor { get; set;}
        // public int menor { get; set;}

        // validación personalizada para este modelo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if( !string.IsNullOrEmpty(Nombre) ) {
                var firstLetter = Nombre[0].ToString();
                if( !Char.IsUpper( char.Parse( firstLetter) ) ) {
                    yield return new ValidationResult(
                        "La primera letra debe ser mayúscula",
                        new string[] { nameof(Nombre) }
                    );
                }
            }
            // if( mayor < menor ) {
            //     yield return new ValidationResult(
            //         "El numero mayor no puede ser menor al campo menor",
            //         new string[] { nameof(mayor) }
            //     );
            // }
        }
    }
}