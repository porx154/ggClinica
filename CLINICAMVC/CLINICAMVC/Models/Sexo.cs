using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public enum Sexo
    {
        [Display(Name ="Masculino")]
        M,
        [Display(Name ="Femenino")]
        F
    }
}