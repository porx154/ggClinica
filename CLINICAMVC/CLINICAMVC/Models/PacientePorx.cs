using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLINICAMVC.Models
{
    public class PacientePorx : Manager
    {
        public PacientePorx(ApplicationDbContext context) : base(context)
        {
        }
        public bool CrearPaciente(Paciente paciente)
        {
            try
            {
                //aqui va codigo
                if (paciente == null) return false;
                var pacienterepe = BuscarPacienteDNI(paciente.DniPaciente);
                if (pacienterepe != null) return false;
                Context.Paciente.Add(paciente);
                Context.SaveChanges();
                return true;
                //if (pacienterepe != null)
                //{
                //    Context.Paciente.Add(paciente);
                //    Context.SaveChanges();
                //    return true;
                //}
                //return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Paciente BuscarPacienteDNI(string dni)
        {
            try
            {
                var paciente = Context.Paciente.FirstOrDefault(p => p.DniPaciente.Equals(dni));
                return paciente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public IEnumerable<Paciente>BuscarPacienteCampo(string buscar)
        {
            try
            {
                if (buscar == null) return ListarPacientes();
                var pacientes = Context.Paciente.Where(p => p.NomPaciente.Contains(buscar) || p.ApePaciente.Contains(buscar) || p.DniPaciente.Contains(buscar)).ToList();
                return pacientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
  
        public IEnumerable<Paciente>ListarPacientes()
        {
            try
            {
                return Context.Paciente.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public Paciente BuscarPacienteID(int id)
        {
            try
            {
                var pacienteid = Context.Paciente.FirstOrDefault(p => p.Id == id);
                return pacienteid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool ModificarPaciente(Paciente paciente)
        {
            try
            {
                if (paciente == null) return false;
                var buscarpaciente = Context.Paciente.FirstOrDefault(p => p.Id == paciente.Id);
                if (buscarpaciente == null) return false;
                buscarpaciente.NomPaciente = paciente.NomPaciente;
                buscarpaciente.ApePaciente = paciente.ApePaciente;
                buscarpaciente.DirPaciente = paciente.DirPaciente;
                buscarpaciente.CelPaciente = paciente.CelPaciente;
                buscarpaciente.EmailPaciente = paciente.EmailPaciente;
                buscarpaciente.GrupoSangre = paciente.GrupoSangre;
                buscarpaciente.Sexo = paciente.Sexo;
                buscarpaciente.AlePaciente = paciente.AlePaciente;
                buscarpaciente.AntPaciente = paciente.AntPaciente;
                buscarpaciente.FecNacPaciente = paciente.FecNacPaciente;
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