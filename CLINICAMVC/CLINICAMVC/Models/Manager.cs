using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class Manager
    {
        protected ApplicationDbContext Context;

        public Manager(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}