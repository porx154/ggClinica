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
    [PorxAuthorize(Roles = "Medico,Administrador")]
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();
        // GET: Pacientess
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult CrearPaciente()
        //{
        //    var listaSangre = new PacientePorx(_context);
        //    ViewBag.ListaSangre = listaSangre.GrupoSanguineo();
        //    return View();
        //}
        public ActionResult CrearPaciente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearPaciente(Paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var pp = new PacientePorx(_context);
                var cpaciente = pp.CrearPaciente(paciente);
                if (!cpaciente)
                {
                    ViewBag.Error = "Error al registrar Historial / Dni Repetido";
                    return View(paciente);
                }
                return RedirectToAction("ConsultarHistorialPaciente", "Paciente");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al crear Historial", ex);
                return View();
            }
        }
        public ActionResult ConsultarHistorialPaciente(string buscar)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var pp = new PacientePorx(_context);
                var buscarpaciente = pp.BuscarPacienteCampo(buscar);
                if(buscarpaciente.Count()==0)
                {
                    ViewBag.Error = "Lo Sentimos el Paciente no se Encontro";
                    return View(pp.ListarPacientes());
                }
                return View(buscarpaciente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al crear Historial", ex);
                return View();
            }
        }
        public ActionResult ModificarHistorialPaciente(int id)
        {
            var pp = new PacientePorx(_context);
            var historial = pp.BuscarPacienteID(id);
            if (historial == null) return RedirectToAction("ConsultarHistorialPaciente", "Paciente");
            return View(historial);
        }
        [HttpPost]
        public ActionResult ModificarHistorialPaciente(int id,Paciente paciente)
        {
            try
            {
                var pp = new PacientePorx(_context);
                var actpaciente = pp.ModificarPaciente(paciente);
                if (!actpaciente)
                {
                    ViewBag.Error = "No se pudo Actualizar";
                    return View(actpaciente);
                }
                return RedirectToAction("ConsultarHistorialPaciente", "Paciente");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar Historial Paciente", ex);
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