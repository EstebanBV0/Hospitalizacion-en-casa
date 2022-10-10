using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.Models
{
    public class Medico : Persona

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        [Remote(action: "VerificarExistMedico", controller:"Medicos")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe estar {2} y {1} caracteres")]
        public string Rethus { get; set; }


    }
}
