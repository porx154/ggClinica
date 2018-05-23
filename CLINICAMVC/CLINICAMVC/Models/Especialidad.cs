using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Especialidad
    {
        public int Id { get; set; }

        [Display(Name ="Especialidad")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(50)]
        public string DesEspecialidad { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        [Display(Name ="Precio S/.")]
        public int PreEspecialidad { get; set; }

        [Display(Name ="Estado")]
        public bool EstEspecialidad { get; set; }
        public List<Medico> Medico { get; set; }


    }
}