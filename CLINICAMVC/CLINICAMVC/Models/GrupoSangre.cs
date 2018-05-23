using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public enum GrupoSangre
    {
        [Display(Name="O+")]
        Op,
        [Display(Name ="O-")]
        On,
        [Display(Name = "A+")]
        Ap,
        [Display(Name = "A-")]
        An,
        [Display(Name = "AB+")]
        ABp,
        [Display(Name = "AB-")]
        ABn,
        [Display(Name = "B+")]
        Bp,
        [Display(Name = "B-")]
        Bn
    }
}