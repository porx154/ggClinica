using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class MedicoPorx : Manager
    {
        public MedicoPorx(ApplicationDbContext context) : base(context)
        {
        }
        public Medico BuscarMedicoDNI(string dni)
        {
            try
            {
                var md = Context.Medico.FirstOrDefault(m => m.DniMedico.Equals(dni));
                return md;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool CrearMedicoConsultorio(Medico medico)
        {
            try
            {
                //busqueda de medico por dni
                if (medico == null) return false;
                var buscardni = BuscarMedicoDNI(medico.DniMedico);
                if (buscardni != null) return false;
                Context.Medico.Add(medico);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public Especialidad ListarEspecialidadID(int id)
        {
            try
            {
                var listar = Context.Especialidad.FirstOrDefault(e => e.Id == id);
                return listar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public Consultorio ListarConsultorioId(int id)
        {
            try
            {
                var listaconsul = Context.Consultorio.FirstOrDefault(c => c.Id == id);
                return listaconsul;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public IEnumerable<Medico>BuscarMedicoEspecialidad(string idespecialidad)
        {
            try
            {
                if (idespecialidad == null || idespecialidad == "") return ListarMedicoConsultorio();
                int convertirid = int.Parse(idespecialidad);
                var listarmedico = Context.Medico.Where(x => x.EspecialidadId == convertirid).ToList();
                var listarbusqueda = new List<Medico>();
                foreach (var item in listarmedico)
                {
                    var nuevabusqueda = new Medico()
                    {
                        Id = item.Id,
                        NombMedico = item.NombMedico,
                        ApeMedico = item.ApeMedico,
                        DirMedico = item.DirMedico,
                        CelMedico = item.CelMedico,
                        EmailMedico = item.EmailMedico,
                        FecIngMedico = item.FecIngMedico,
                        FecNacMedico = item.FecNacMedico,
                        DniMedico = item.DniMedico,
                        NomEspecialidad = ListarEspecialidadID(item.EspecialidadId).DesEspecialidad,
                        NomConsultorio = ListarConsultorioId(item.ConsultorioId).DesConsultorio
                    };
                    listarbusqueda.Add(nuevabusqueda);
                }
                return listarbusqueda;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public IEnumerable<Medico> ListarMedicoConsultorio()
        {
            try
            {
                var listamedico = Context.Medico.ToList();
                var lista = new List<Medico>();
                foreach(var item in listamedico)
                {
                    var nuevo = new Medico()
                    {
                        Id = item.Id,
                        NombMedico = item.NombMedico,
                        ApeMedico = item.ApeMedico,
                        DirMedico = item.DirMedico,
                        CelMedico = item.CelMedico,
                        EmailMedico = item.EmailMedico,
                        FecIngMedico = item.FecIngMedico,
                        FecNacMedico = item.FecNacMedico,
                        DniMedico = item.DniMedico,
                        NomEspecialidad = ListarEspecialidadID(item.EspecialidadId).DesEspecialidad,
                        NomConsultorio=ListarConsultorioId(item.ConsultorioId).DesConsultorio
                    };
                    lista.Add(nuevo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;                
            }
        }
        public Medico BuscarMedicoID(int id)
        {
            try
            {
                var medicoID = Context.Medico.FirstOrDefault(m => m.Id == id);
                return medicoID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool ModificarMedicoConsultorio(Medico medico)
        {
            try
            {
                if (medico == null) return false;
                var buscarmed = BuscarMedicoID(medico.Id);
                if (buscarmed == null) return false;
                buscarmed.NombMedico = medico.NombMedico;
                buscarmed.ApeMedico = medico.ApeMedico;
                buscarmed.DirMedico = medico.DirMedico;
                buscarmed.CelMedico = medico.CelMedico;
                buscarmed.EmailMedico = medico.EmailMedico;
                buscarmed.FecIngMedico = medico.FecIngMedico;
                buscarmed.FecNacMedico = medico.FecNacMedico;
                buscarmed.ConsultorioId = medico.ConsultorioId;
                buscarmed.EspecialidadId = medico.EspecialidadId;
                buscarmed.DniMedico = medico.DniMedico;
                Context.SaveChanges();
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