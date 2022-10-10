using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.Models
{
    public class Enfermera : Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public int  Horas { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public string Tarjeta{ get; set; }

    }

}