using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Consultorio
    {
        public int Id { get; set; }

        [StringLength(5)]
        public string DesConsultorio { get; set; }
        public List<Medico> Medico { get; set; }
    }
}