using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Collections.ObjectModel;
using Microsoft.AspNet.Identity.EntityFramework;
namespace CLINICAMVC.Models
{
    public class UsuariosPorx:Manager
    {
        public UsuariosPorx(ApplicationDbContext context) 
            : base(context) 
        {
            
        }
        public bool ModificarContrasena(string id, RegisterViewModel model)
        {
            try
            {
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
                var usuario = um.FindById(id);
                if (usuario == null) return false;

                usuario.PasswordHash = new PasswordHasher().HashPassword(model.Password);

                um.Update(usuario);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public ApplicationUser BuscarUsuarioDNI(string dni)
        {
            try
            {
                var usuariodni = Context.Users.FirstOrDefault(x => x.DniEmpleado.Equals(dni));
                return usuariodni;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public IEnumerable<RegisterViewModel> BuscarPorCampo(string buscar)
        {
            try
            {
                var listaUsuario = Context.Users.Where(s => s.NomEmpleado.ToUpper().Contains(buscar.ToUpper().Trim()) || s.ApeEmpleado.ToUpper().Contains(buscar.ToUpper().Trim()) || s.DniEmpleado.ToUpper().Contains(buscar.ToUpper().Trim()));

                var lista = new Collection<RegisterViewModel>();

                foreach (var item in listaUsuario)
                {
                    var nuevo = new RegisterViewModel()
                    {
                        Id = item.Id,
                        DniEmpleado = item.DniEmpleado,
                        NomEmpleado = item.NomEmpleado,
                        ApeEmpleado = item.ApeEmpleado,
                        DirEmpleado = item.DirEmpleado,
                        CelEmpleado = item.CelEmpleado,
                        FecIngEmpleado = item.FecIngEmpleado,
                        FecNacEmpleado = item.FecNacEmpleado,
                        UserName = item.UserName,
                        Password = item.PasswordHash,
                        UserRoles = ListarRol(item.Id),
                        EstadoUsuario = item.EstadoUsuario
                    };

                    lista.Add(nuevo);
                }

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public IEnumerable<RegisterViewModel> BuscarUsuarios()
        {
            try
            {
                var listaUsuario = Context.Users.ToList();

                var lista = new List<RegisterViewModel>();

                foreach (var item in listaUsuario)
                {
                    var nuevo = new RegisterViewModel()
                    {
                        Id = item.Id,
                        DniEmpleado = item.DniEmpleado,
                        NomEmpleado = item.NomEmpleado,
                        ApeEmpleado = item.ApeEmpleado,
                        DirEmpleado = item.DirEmpleado,
                        CelEmpleado = item.CelEmpleado,
                        FecIngEmpleado = item.FecIngEmpleado,
                        FecNacEmpleado = item.FecNacEmpleado,
                        UserName = item.UserName,
                        Password = item.PasswordHash,
                        UserRoles = ListarRol(item.Id),
                        EstadoUsuario = item.EstadoUsuario
                    };

                    lista.Add(nuevo);
                }

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string ListarRol(string id)
        {
            try
            {
                using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context)))
                {
                    return userManager.GetRoles(id)[0];
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string CrearUsuario(RegisterViewModel model)
        {
            try
            {
                var usuario = new ApplicationUser
                {
                    UserName = model.UserName,
                    DniEmpleado = model.DniEmpleado,
                    NomEmpleado = model.NomEmpleado,
                    ApeEmpleado = model.ApeEmpleado,
                    DirEmpleado = model.DirEmpleado,
                    CelEmpleado = model.CelEmpleado,
                    EmailEmpleado = model.EmailEmpleado,
                    FecIngEmpleado = model.FecIngEmpleado,
                    FecNacEmpleado = model.FecNacEmpleado,
                    EstadoUsuario = model.EstadoUsuario
                    
                    
                };
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
                var result = userManager.Create(usuario, model.Password);
                if (result.Succeeded)
                {
                    var resultrol = userManager.AddToRole(usuario.Id, model.UserRoles);
                    if (resultrol.Succeeded)
                    {
                        return usuario.Id;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public ApplicationUser BuscarUsuarioNombre(string NombUsuario)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
                return userManager.FindByName(NombUsuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public ApplicationUser BuscarUsuarioID(string Id)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
                return userManager.FindById(Id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool ModificarUsuario(string id,RegisterViewModel model)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
                var um = userManager.FindById(id);
                if (um == null) return false;

                um.UserName = model.UserName;
                um.NomEmpleado = model.NomEmpleado;
                um.ApeEmpleado = model.ApeEmpleado;
                um.DirEmpleado = model.DirEmpleado;
                um.CelEmpleado = model.CelEmpleado;
                um.EmailEmpleado = model.EmailEmpleado;
                um.DniEmpleado = model.DniEmpleado;
                um.FecIngEmpleado = model.FecIngEmpleado;
                um.FecNacEmpleado = model.FecNacEmpleado;
                um.EstadoUsuario = model.EstadoUsuario;

                userManager.Update(um);

                var AntiguoRol = userManager.GetRoles(id)[0];
                if (!AntiguoRol.Equals(model.UserRoles))
                {
                    userManager.RemoveFromRole(id, AntiguoRol);
                    userManager.AddToRole(id, model.UserRoles);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}