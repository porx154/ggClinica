using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Medico:IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Nombre")]
        [StringLength(50)]
        public string NombMedico { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string ApeMedico { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Direccíon")]
        [StringLength(200)]
        public string DirMedico { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Telefono")]
        [StringLength(12)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        public string CelMedico { get; set; }

        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "El campo {0} no es valido")]
        public string EmailMedico { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} es una fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecIngMedico { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} es una fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecNacMedico { get; set; }

        [Display(Name ="Especialidad")]
        public int EspecialidadId { get; set; }

        [Display(Name ="Consultorio")]
        public int ConsultorioId { get; set; }

        [Display(Name ="DNI")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} es numérico")]
        [StringLength(8, ErrorMessage = "El campo {0} debe tener {1} digitos", MinimumLength = 8)]
        public string DniMedico { get; set; }

        [NotMapped]
        [Display(Name ="Especialidad")]
        public string NomEspecialidad { get; set; }
        [NotMapped]
        [Display(Name = "Consultorio")]
        public string NomConsultorio { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var listerror = new List<ValidationResult>();
            if (FecIngMedico < FecNacMedico)
            {
                listerror.Add(new ValidationResult("La Fecha de Ingreso debe ser Mayor a Fecha de Nacimiento", new string[] { "FecIngMedico" }));
            }
            return listerror;
        }
    }
}