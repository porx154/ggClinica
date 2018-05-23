using CLINICAMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(CLINICAMVC.Startup))]
namespace CLINICAMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            SuperUsuarioAdmin();
        }
        private void CreateRoles()
        {
            using(var context = ApplicationDbContext.Create())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Administrador"))
                {
                    var rol = new IdentityRole { Name = "Administrador" };
                    roleManager.Create(rol);
                }
                if (!roleManager.RoleExists("Medico"))
                {
                    var rol = new IdentityRole { Name = "Medico" };
                    roleManager.Create(rol);
                }
                if (!roleManager.RoleExists("Recepcionista-Admision"))
                {
                    var rol = new IdentityRole { Name = "Recepcionista-Admision" };
                    roleManager.Create(rol);
                }
            }
        }
        private void SuperUsuarioAdmin()
        {
            using (var context = ApplicationDbContext.Create())
            {
                try
                {
                    var UsuarioManager =new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    var superusuario = new ApplicationUser()
                    {
                        UserName = "Porx154",
                        DniEmpleado = "48522080",
                        NomEmpleado = "Isaias Ronald",
                        ApeEmpleado = "Macuri",
                        DirEmpleado = "Tacna",
                        CelEmpleado = "972014117",
                        EmailEmpleado = "porx_154@hotmail.com",
                        FecIngEmpleado = DateTime.Parse("2015-01-01"),
                        FecNacEmpleado = DateTime.Parse("1994-07-17"),
                        EstadoUsuario = true,
                        
                    };
                    var pasusuario = "marinos154";
                    var crearusuario = UsuarioManager.Create(superusuario, pasusuario);
                    if (crearusuario.Succeeded)
                    {
                        var result = UsuarioManager.AddToRole(superusuario.Id, "Administrador");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
