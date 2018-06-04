using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLINICAMVC.Models;

namespace TestClinica
{
    [TestClass]
    public class EspecialidadTest
    {
        private ApplicationDbContext _context;
        [TestInitialize]
        public void Initialize()
        {
            try
            {
                _context = ApplicationDbContext.Create();
                _context.Especialidad.RemoveRange(_context.Especialidad);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                _context.Especialidad.RemoveRange(_context.Especialidad);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [TestMethod]
        public void RegistroEspecialidadTest()
        {
            //Arrange
            
            var especialidad = new Especialidad()
            {
                Id=14,
                DesEspecialidad = "Neurologia",
                PreEspecialidad = 95,
                EstEspecialidad = true
            };
            //Act
            var espeporx = new EspecialidadPorx(_context);
            var res = espeporx.CrearEspecialidad(especialidad);
            //Assert
            Assert.IsTrue(res);
        }
    }
}
