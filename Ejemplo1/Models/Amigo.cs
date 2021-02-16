using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Models
{
    public class Amigo
    {
        public int Id { get; set; }

        //Validaciones  para el ingreso de datos
        [Required(ErrorMessage = "Obligatorio"), MaxLength(100, ErrorMessage = "No mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name ="Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la ciudad")]
        public Provincia? Ciudad { get; set; }
    }
}
