using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    //sss
    public class Roles
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Rol")]
        public string NombreRol { get; set; }

        public List<Usuarios> Usuarios { get; set; }
    }
}