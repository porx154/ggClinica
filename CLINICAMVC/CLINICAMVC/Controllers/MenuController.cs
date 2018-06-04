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
        [PorxAuthorize(Roles = "Recepcionista-Admision,Administrador")]
        public ActionResult MenuCitas()
        {
            return View();
        }
        [PorxAuthorize(Roles = "Medico,Administrador")]
        public ActionResult MenuHistorialPaciente()
        {
            return View();
        }

        [PorxAuthorize(Roles = "Jefe-Personal,Administrador")]
        public ActionResult MenuConsultorioMedico()
        {
            return View();
        }
        [PorxAuthorize(Roles = "Jefe-Personal,Administrador")]
        public ActionResult MenuEspecialidad()
        {
            return View();
        }
    }
}