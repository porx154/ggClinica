using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Nombres")]
        [StringLength(50)]
        public string NomEmpleado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Apellidos")]
        [StringLength(50)]
        public string ApeEmpleado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Dirección")]
        [StringLength(200)]
        public string DirEmpleado { get; set; }

        [Display(Name ="Celular")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="El campo {0} es numérico")]
        public string CelEmpleado { get; set; }

        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage ="El campo {0} no es valido")]
        public string EmailEmpleado { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(8,ErrorMessage ="El campo {0} debe tener {1} digitos",MinimumLength =8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        public string DniEmpleado { get; set; }

        [Display(Name ="Fecha de Ingreso")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} es una fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecIngEmpleado { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} es una fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecNacEmpleado { get; set; }

    }
}