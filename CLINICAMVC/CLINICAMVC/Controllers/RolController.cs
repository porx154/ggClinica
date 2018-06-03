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
    [PorxAuthorize(Roles ="Administrador")]
    public class RolController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();
        // GET: Rol
        public ActionResult AgregarRol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarRol(string NombreRol)
        {
            try
            {
                var rp = new RolPorx(_context);
                var nuevorol = rp.AgregarRoles(NombreRol);

                return RedirectToAction("ConsultaUsuario", "Usuario");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al agregar rol", ex);
                return View();
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