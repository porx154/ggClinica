using CLINICAMVC.Models.AnnotationsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Controllers
{
    public class MenuController : Controller
    {
        [Authorize]
        // GET: Menusssss
        public ActionResult Inicio()
        {
            return View();
        }
        [PorxAuthorize(Roles ="Administrador")]
        public ActionResult MenuSeguridad()
        {
            return View();
        }
        [PorxAuthorize(Roles = "Recepcionista-Admision")]
        public ActionResult MenuCitas()
        {
            return View();
        }
        [PorxAuthorize(Roles ="Medico")]
        public ActionResult MenuHistorialPaciente()
        {
            return View();
        }
        public ActionResult MenuConsultorioMedico()
        {
            return View();
        }
        public ActionResult MenuEspecialidad()
        {
            return View();
        }
    }
}