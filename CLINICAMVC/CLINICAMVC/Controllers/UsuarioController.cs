using CLINICAMVC.Models;
using CLINICAMVC.Models.AnnotationsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Controllers
{
    [Authorize]
    [PorxAuthorize(Roles = "Administrador")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();
        // GET: Usuario
        //public ActionResult ConsultaEmpleadoCuenta(string buscar)
        //{
        //    try
        //    {
        //        var ep = new EmpleadosPorx(_context);
        //        var empleado = ep.BuscarEmpleadosCuenta(buscar);
        //        return View(empleado);
                
        //    }
        //    catch 
        //    {
        //        throw;
        //    }
        //}
        
        public ActionResult ConsultaUsuario(string buscar)
        {
            try
            {
                var up = new UsuariosPorx(_context);

                ViewBag.buscar = buscar;

                if (!String.IsNullOrEmpty(buscar))
                {
                    var listausuarios = up.BuscarPorCampo(buscar);
                    return View(listausuarios);
                }

                var listaUsuario = up.BuscarUsuarios();
                return View(listaUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}