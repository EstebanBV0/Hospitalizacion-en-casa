using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.Models
{
    public abstract class Persona
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public string NumeroTelefono { get; set; }
        //public string Genero { get; set; }

        //[Required(ErrorMessage ="El campo {0} es requerido")]
        //[EmailAddress(ErrorMessage ="El campo debe ser un correo electrónico valido")]
        //public string CorreoElectronico { get; set; }

    }
}
