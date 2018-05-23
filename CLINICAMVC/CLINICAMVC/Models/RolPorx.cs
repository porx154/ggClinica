using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace CLINICAMVC.Models
{
    public class RolPorx: Manager
    {
        public RolPorx(ApplicationDbContext context) 
            : base(context) 
        {

        }

        public List<string> RolesList()
        {
            try
            {
                return Context.Roles.Select(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool AgregarRoles(string NombreRol)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Context));

                if (!roleManager.RoleExists(NombreRol))
                {
                    var roleidentity = new IdentityRole { Name = NombreRol };
                    roleManager.Create(roleidentity);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool EliminarRoles(string NombreRol)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Context));

                if (roleManager.RoleExists(NombreRol))
                {
                    var res = roleManager.Delete(new IdentityRole(NombreRol));
                    if (res.Succeeded) return true;
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


    }
}