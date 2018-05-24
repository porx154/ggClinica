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
    public class EspecialidadController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();
        // GET: Especialidad
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConsultaEspecialidad(string especialidad)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                var espe = new EspecialidadPorx(_context);
                var busqueda = espe.BuscarEspecialidad(especialidad);
                if (busqueda.Count() == 0)
                {
                    ViewBag.Error = "Lo sentimos no se encontro especialidad";
                    return View(espe.ListarEspecialidad());
                }
                return View(busqueda);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al consultar especialidad ",ex);
                return View();
            }
        }
        public ActionResult CrearEspecialidad()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearEspecialidad(Especialidad especialidad)
        {
            try
            {
                var espe = new EspecialidadPorx(_context);
                var busespe = espe.BuscarEspecialidad(especialidad.DesEspecialidad);
                if(busespe.Count() != 0)
                {
                    ViewBag.Error = "Ya existe la especialidad no se pudo registrar";
                    return View();
                }
                espe.CrearEspecialidad(especialidad);
                return RedirectToAction("ConsultaEspecialidad", "Especialidad");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al registrar especialdiad", ex);
                return View();
            }
        }
        public ActionResult ModificarEspecialidad(int id)
        {
            var esp = new EspecialidadPorx(_context);
            var especialidad = esp.BuscarEspecialidadID(id);
            if (especialidad == null) return RedirectToAction("ConsultaEspecialidad", "Especialidad");
            return View(especialidad);
        }
        [HttpPost]
        public ActionResult ModificarEspecialidad(Especialidad especialidad)
        {
            try
            {
                
                var espe = new EspecialidadPorx(_context);
                var modespecialidad = espe.ModificarEspecialidad(especialidad);
                if (!modespecialidad)
                {
                    ViewBag.Error = "No se pudo actualizar Especialidad";
                }
                return RedirectToAction("ConsultaEspecialidad", "Especialidad");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al modificar especialidad", ex);
                return View();
            }
        }
    }
}