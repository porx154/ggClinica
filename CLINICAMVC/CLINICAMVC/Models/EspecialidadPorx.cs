using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Models
{
    public class EspecialidadPorx : Manager
    {
        public EspecialidadPorx(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Especialidad> ListarEspecialidad()
        {
            try
            {
                return Context.Especialidad.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public IEnumerable<Especialidad> BuscarEspecialidad(string especialidad)
        {
            try
            {
                if (especialidad == null)return ListarEspecialidad();
                var espe = Context.Especialidad.Where(e => e.DesEspecialidad.Contains(especialidad)).ToList();
                return espe;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool CrearEspecialidad(Especialidad especialidad)
        {
            try
            {
                if (especialidad == null) return false;
                Context.Especialidad.Add(especialidad);
                Context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public Especialidad BuscarEspecialidadID(int id)
        {
            try
            {
                var espeid = Context.Especialidad.FirstOrDefault(e => e.Id == id);
                return espeid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool ModificarEspecialidad(Especialidad especialidad)
        {
            try
            {
                if (especialidad == null) return false;
                var buscarespe = BuscarEspecialidadID(especialidad.Id);
                if (buscarespe == null) return false;
                buscarespe.DesEspecialidad = especialidad.DesEspecialidad;
                buscarespe.PreEspecialidad = especialidad.PreEspecialidad;
                buscarespe.EstEspecialidad = especialidad.EstEspecialidad;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public SelectList listEspCmb()
        {
            var ep = Context.Especialidad.Where(e=>e.EstEspecialidad==true).ToList();
            SelectList lista = new SelectList(ep, "Id", "DesEspecialidad");
            return lista;
        }
    }
}