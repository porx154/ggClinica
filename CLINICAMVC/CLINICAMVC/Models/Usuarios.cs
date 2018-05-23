using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        [Required]
        public string NomEmpleado { get; set; }

        [Required]
        public string ApeEmpleado { get; set; }

        [Required]
        public string DirEmpleado { get; set; }

        [Required]
        public string CelEmpleado { get; set; }

        [Required]
        public string EmailEmpleado { get; set; }

        [Required]
        public string DniEmpleado { get; set; }

        [Required]
        public DateTime FecIngEmpleado { get; set; }
        [Required]
        public DateTime FecNacEmpleado { get; set; }

        [Required]

        public Roles RolId { get; set; }
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}