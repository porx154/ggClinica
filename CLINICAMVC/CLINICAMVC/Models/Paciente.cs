using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Nombre")]
        [StringLength(50)]
        public string NomPaciente { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Apellido")]
        [StringLength(50)]
        public string ApePaciente { get; set; }

        [Required]
        [Display(Name ="Dirección")]
        [StringLength(200)]
        public string DirPaciente { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(8,ErrorMessage ="El campo {0} necesita {1} digitos",MinimumLength =8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        [Display(Name ="DNI")]
        public string DniPaciente { get; set; }

        [Display(Name ="Celular")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        public string CelPaciente { get; set; }

        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage ="El campo {0} no es valido")]
        public string EmailPaciente { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        [Display(Name ="Edad")]
        public int EdadPaciente { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Peso")]
        public double PesoPaciente { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Altura")]
        public double AlturaPaciente { get; set; }
        
        public Sexo Sexo { get; set; }
        //[Required]
        //[Display(Name ="Grupo Sanguineo")]
        //[StringLength(5)]
        //public string GrupSannguineo { get; set; }
        [Display(Name ="Grupo Sanguineo")]
        public GrupoSangre GrupoSangre { get; set; }

        [Display(Name = "Alergias del Paciente")]
        [StringLength(200)]
       
        public string AlePaciente { get; set; }

        [Display(Name ="Antecedentes del Paciente")]
        [StringLength(200)]
        public string AntPaciente { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} es una fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecNacPaciente { get; set; }
        
    }
   
}