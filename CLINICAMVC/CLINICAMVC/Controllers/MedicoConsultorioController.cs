using CLINICAMVC.Models;
using CLINICAMVC.Models.AnnotationsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Controllers
{
    [PorxAuthorize(Roles = "Jefe-Personal")]
    public class MedicoConsultorioController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();
        // GET: MedicoConsultorio
        public ActionResult Index()
        {
            //var cmbespecialidad = new EspecialidadPorx(_context);
            //ViewBag.ConMeEsp = cmbespecialidad.listEspCmb();
            return View();
        }
       
        public ActionResult ConsultarMedicoConsultorio(string idespecialidad)
        {
            try
            {
                var listar = new MedicoPorx(_context);
                if (!ModelState.IsValid) return View();
                var cmbespecialidad = new EspecialidadPorx(_context);
                ViewBag.ConMeEsp = cmbespecialidad.listEspCmb();
                var ls = listar.BuscarMedicoEspecialidad(idespecialidad);
                return View(ls);
                //return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al consultar", ex);
                return View();
            }

        }
        public ActionResult CrearMedicoConsultorio()
        {
            var espe = new EspecialidadPorx(_context);
            var consul = new ConsultorioPorx(_context);
            ViewBag.ListEspe = espe.listEspCmb();
            ViewBag.ListConsul = consul.LstCmbConsultorio();
            return View();
        }
        [HttpPost]
        public ActionResult CrearMedicoConsultorio(Medico medico)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var consmed = new MedicoPorx(_context);
                var crearcm = consmed.CrearMedicoConsultorio(medico);
                var espe = new EspecialidadPorx(_context);
                var consul = new ConsultorioPorx(_context);
                ViewBag.ListEspe = espe.listEspCmb();
                ViewBag.ListConsul = consul.LstCmbConsultorio();
                if (!crearcm)
                {
                    ViewBag.Error = "El DNI del Medico ya Existe";
                    return View(medico);
                }
                return RedirectToAction("ConsultarMedicoConsultorio", "MedicoConsultorio");
                //var espe = new EspecialidadPorx(_context);
                //var consul = new ConsultorioPorx(_context);
                //ViewBag.ListEspe = espe.listEspCmb();
                //ViewBag.ListConsul = consul.LstCmbConsultorio();
                //if (busespe.Count() != 0)
                //{
                //    ViewBag.Error = "Ya existe la especialidad no se pudo registrar";
                //    return View();
                //}
                //espe.CrearEspecialidad(especialidad);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al registrar", ex);
                return View();
            }
        }
        public ActionResult ModificarMedicoConsultorio(int id)
        {
            var mc = new MedicoPorx(_context);
            var consul = new ConsultorioPorx(_context);
            var espe = new EspecialidadPorx(_context);
            var medicoConsultorio = mc.BuscarMedicoID(id);
            if (medicoConsultorio == null) return RedirectToAction("ConsultarMedicoConsultorio", "MedicoConsultorio");
            ViewBag.Meespe = espe.listEspCmb();
            ViewBag.MeConsul = consul.LstCmbConsultorio();
            return View(medicoConsultorio);
        }
        [HttpPost]
        public ActionResult ModificarMedicoConsultorio(Medico medico)
        {
            try
            {
                var medicP = new MedicoPorx(_context);
                var modmed = medicP.ModificarMedicoConsultorio(medico);
                if (!modmed)
                {
                    ViewBag.Error = "Error al modificar";
                }
                return RedirectToAction("ConsultarMedicoConsultorio", "MedicoConsultorio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al modicar Medico Consultorio", ex);
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}