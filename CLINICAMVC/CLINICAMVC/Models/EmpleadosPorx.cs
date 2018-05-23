using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLINICAMVC.Models
{
    public class EmpleadosPorx:Manager
    {
        public EmpleadosPorx(ApplicationDbContext context)
            :base(context)
        {

        }
        //public IEnumerable<Empleados> BuscarEmpleadosCuenta(string buscar)
        //{
        //    try
        //    {
        //        if (buscar == null) return Context.Empleado.Select(x => x).ToList();
        //        var empleado = Context.Empleado.Where(x => x.NomEmpleado.Contains(buscar) || x.ApeEmpleado.Contains(buscar) || x.DniEmpleado.Contains(buscar));
        //        return empleado;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return null;
        //    }
        //}
        //public Empleados BuscarEmpleadosID(int id)
        //{
        //    try
        //    {
        //        var empleado = Context.Empleado.FirstOrDefault(x => x.Id == id);
        //        return empleado;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return null;
        //    }
        //}
    }
}