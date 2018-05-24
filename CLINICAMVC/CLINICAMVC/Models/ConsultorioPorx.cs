using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Models
{
    public class ConsultorioPorx : Manager
    {
        public ConsultorioPorx(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}