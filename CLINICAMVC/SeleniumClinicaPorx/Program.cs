using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumClinicaPorx
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(20000);
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:55678/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            
            driver.FindElement(By.Id("ingresar")).Click();
            
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("porx154");
            driver.FindElement(By.Id("ingresar")).Click();
            
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("porx154");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("marinos154");
            driver.FindElement(By.Id("ingresar")).Click();
           
            driver.FindElement(By.LinkText("Seguridad")).Click();
            driver.FindElement(By.XPath("//a[@href='/Account/RegistroUsuario']")).Click();
            
            driver.FindElement(By.Id("registrar")).Click();
            driver.Navigate().Refresh();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).SendKeys("Sato");
            driver.FindElement(By.Id("Password")).SendKeys("marinos154");
            
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("marinos155");
            driver.FindElement(By.Id("NomEmpleado")).Click();
            
            driver.FindElement(By.Id("ConfirmPassword")).Click();
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("marinos154");

            driver.FindElement(By.Id("NomEmpleado")).SendKeys("Salmon");
            driver.FindElement(By.Id("ApeEmpleado")).SendKeys("Taberu");
            driver.FindElement(By.Id("DirEmpleado")).SendKeys("Las Palmeras");
           
            driver.FindElement(By.Id("CelEmpleado")).SendKeys("abcdef");
            driver.FindElement(By.Id("EmailEmpleado")).Click();
            
            driver.FindElement(By.Id("CelEmpleado")).Click();
            driver.FindElement(By.Id("CelEmpleado")).Clear();
            driver.FindElement(By.Id("CelEmpleado")).SendKeys("987526315");
           
            driver.FindElement(By.Id("EmailEmpleado")).SendKeys("abcdefasd");
            driver.FindElement(By.Id("DniEmpleado")).Click();
            
            driver.FindElement(By.Id("EmailEmpleado")).Click();
            driver.FindElement(By.Id("EmailEmpleado")).Clear();
            driver.FindElement(By.Id("EmailEmpleado")).SendKeys("Sato@gmail.com");
            
            driver.FindElement(By.Id("DniEmpleado")).SendKeys("asda");
            driver.FindElement(By.Id("FecIngEmpleado")).Click();
            
            driver.FindElement(By.Id("DniEmpleado")).Click();
            driver.FindElement(By.Id("DniEmpleado")).Clear();
            driver.FindElement(By.Id("DniEmpleado")).SendKeys("48522080");
            
            driver.FindElement(By.Id("FecIngEmpleado")).SendKeys("2016-06-07");
            driver.FindElement(By.Id("FecNacEmpleado")).SendKeys("2018-06-15");

            driver.FindElement(By.Id("EstadoUsuario")).Click();
            new SelectElement(driver.FindElement(By.Id("UserRoles"))).SelectByText("Jefe-Personal");
            driver.FindElement(By.Id("registrar")).Click();
            
            driver.FindElement(By.Id("FecIngEmpleado")).SendKeys("2016-06-07");
            driver.FindElement(By.Id("FecNacEmpleado")).SendKeys("1994-06-15");
            driver.FindElement(By.Id("registrar")).Click();
            
            driver.FindElement(By.Id("DniEmpleado")).Click();
            driver.FindElement(By.Id("DniEmpleado")).Clear();
            driver.FindElement(By.Id("DniEmpleado")).SendKeys("48522008");
            driver.FindElement(By.Id("registrar")).Click();
            driver.FindElement(By.LinkText("Seguridad")).Click();
            driver.FindElement(By.XPath("//a[@href='/Usuario/ConsultaUsuario']")).Click();
            driver.FindElement(By.LinkText("Nuevo Usuario")).Click();
            driver.FindElement(By.LinkText("Cancelar")).Click();
            
            driver.FindElement(By.Id("buscartext")).Click();
            driver.FindElement(By.Id("buscartext")).SendKeys("Salmon");
            driver.FindElement(By.Id("buscarbtn")).Click();
            
            driver.FindElement(By.Id("buscartext")).Clear();
            driver.FindElement(By.Id("buscarbtn")).Click();
            
            driver.FindElement(By.Id("buscartext")).SendKeys("Salmon");
            driver.FindElement(By.Id("buscarbtn")).Click();
            
            driver.FindElement(By.LinkText("Editar")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("Sato154");

            driver.FindElement(By.Id("NomEmpleado")).Click();
            driver.FindElement(By.Id("NomEmpleado")).Clear();
            driver.FindElement(By.Id("NomEmpleado")).SendKeys("Salmon Taberu");
            driver.FindElement(By.Id("guardarusuario")).Click();
           
            driver.FindElement(By.Id("buscartext")).Click();
            driver.FindElement(By.Id("buscartext")).SendKeys("48522008");
            driver.FindElement(By.Id("buscarbtn")).Click();
            driver.FindElement(By.LinkText("Contraseña")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("toorimase154");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("toorimase154");
            driver.FindElement(By.Id("cambiarcontrasenia")).Click();
            
            driver.FindElement(By.LinkText("Paciente")).Click();
            driver.FindElement(By.XPath("//a[@href='/Paciente/CrearPaciente']")).Click();
            driver.FindElement(By.Id("NomPaciente")).SendKeys("Carmen");
            driver.FindElement(By.Id("ApePaciente")).SendKeys("Arriola");
            driver.FindElement(By.Id("DirPaciente")).SendKeys("Calle Tokyo");
            
            driver.FindElement(By.Id("DniPaciente")).SendKeys("adada");
            driver.FindElement(By.Id("FecNacPaciente")).Click();
           
            driver.FindElement(By.Id("DniPaciente")).Click();
            driver.FindElement(By.Id("DniPaciente")).Clear();
            
            driver.FindElement(By.Id("DniPaciente")).SendKeys("40236963");

            driver.FindElement(By.Id("FecNacPaciente")).SendKeys("1998-09-17");
            
            driver.FindElement(By.Id("CelPaciente")).SendKeys("asda");
            driver.FindElement(By.Id("EmailPaciente")).Click();
            
            driver.FindElement(By.Id("CelPaciente")).Click();
            driver.FindElement(By.Id("CelPaciente")).Clear();
            driver.FindElement(By.Id("CelPaciente")).SendKeys("958254159");
            
            driver.FindElement(By.Id("EmailPaciente")).SendKeys("abs22");
            driver.FindElement(By.Id("EdadPaciente")).Click();
            
            driver.FindElement(By.Id("EmailPaciente")).Click();
            driver.FindElement(By.Id("EmailPaciente")).Clear();
            driver.FindElement(By.Id("EmailPaciente")).SendKeys("carmen@gmail.com");
            
            driver.FindElement(By.Id("EdadPaciente")).SendKeys("25");
            
            driver.FindElement(By.Id("PesoPaciente")).SendKeys("peso");
            driver.FindElement(By.Id("AlturaPaciente")).SendKeys("altura");
            driver.FindElement(By.Id("EdadPaciente")).Click();
            
            driver.FindElement(By.Id("PesoPaciente")).Click();
            driver.FindElement(By.Id("PesoPaciente")).Clear();
            driver.FindElement(By.Id("PesoPaciente")).SendKeys("73.5");
            driver.FindElement(By.Id("AlturaPaciente")).Click();
            driver.FindElement(By.Id("AlturaPaciente")).Clear();
            driver.FindElement(By.Id("AlturaPaciente")).SendKeys("1.53");
            new SelectElement(driver.FindElement(By.Id("Sexo"))).SelectByText("Femenino");
            new SelectElement(driver.FindElement(By.Id("GrupoSangre"))).SelectByText("AB+");
            driver.FindElement(By.Id("AlePaciente")).SendKeys("Anti virales");
            driver.FindElement(By.Id("AntPaciente")).SendKeys("Principios de Hepatitis B");
            driver.FindElement(By.Id("registrarPaciente")).Click();
            
            driver.FindElement(By.Id("EdadPaciente")).Click();
            driver.FindElement(By.Id("EdadPaciente")).Clear();
            driver.FindElement(By.Id("EdadPaciente")).SendKeys("20");
            driver.FindElement(By.Id("registrarPaciente")).Click();
            
            driver.FindElement(By.Id("DniPaciente")).Click();
            driver.FindElement(By.Id("DniPaciente")).Clear();
            driver.FindElement(By.Id("DniPaciente")).SendKeys("40236105");
            driver.FindElement(By.Id("registrarPaciente")).Click();
          
            driver.FindElement(By.LinkText("Paciente")).Click();
            driver.FindElement(By.XPath("//a[@href='/Paciente/ConsultarHistorialPaciente']")).Click();
            
            driver.FindElement(By.Id("buscarPaciente")).SendKeys("Carmen");
            driver.FindElement(By.Id("buscarPacientebtn")).Click();
            
            driver.FindElement(By.Id("buscarPaciente")).Click();
            driver.FindElement(By.Id("buscarPaciente")).Clear();
            driver.FindElement(By.Id("buscarPacientebtn")).Click();
            driver.FindElement(By.Id("buscarPaciente")).SendKeys("Carmen");
            driver.FindElement(By.Id("buscarPacientebtn")).Click();
            driver.FindElement(By.LinkText("Editar")).Click();
         
            driver.FindElement(By.Id("DirPaciente")).Click();
            driver.FindElement(By.Id("DirPaciente")).Clear();
            driver.FindElement(By.Id("DirPaciente")).SendKeys("Tacna y Arica");

            driver.FindElement(By.Id("CelPaciente")).Click();
            driver.FindElement(By.Id("CelPaciente")).Clear();
            driver.FindElement(By.Id("CelPaciente")).SendKeys("125485679");
            driver.FindElement(By.Id("guardarPaciente")).Click();
            
            driver.FindElement(By.LinkText("Especialidad")).Click();
            driver.FindElement(By.XPath("//a[@href='/Especialidad/CrearEspecialidad']")).Click();
            driver.FindElement(By.Id("DesEspecialidad")).SendKeys("Medicina Alternativa");
            driver.FindElement(By.Id("PreEspecialidad")).SendKeys("35");
            driver.FindElement(By.Id("EstEspecialidad")).Click();
            driver.FindElement(By.Id("registrarEspecialidad")).Click();
            
            driver.FindElement(By.LinkText("Especialidad")).Click();
            driver.FindElement(By.XPath("//a[@href='/Especialidad/ConsultaEspecialidad']")).Click();
            driver.FindElement(By.Id("buscaEspecialidad")).SendKeys("Otorrinolaringologia");
            driver.FindElement(By.Id("buscarEspecialidadbtn")).Click();
            driver.FindElement(By.LinkText("Editar")).Click();
            driver.FindElement(By.Id("guardarEspecialidad")).Click();
          
            driver.FindElement(By.LinkText("Medicos")).Click();
            driver.FindElement(By.XPath("//a[@href='/MedicoConsultorio/CrearMedicoConsultorio']")).Click();
            driver.FindElement(By.Id("NombMedico")).SendKeys("Darwin");
            driver.FindElement(By.Id("ApeMedico")).SendKeys("Quinteros");
            driver.FindElement(By.Id("DirMedico")).SendKeys("Los Palos");
            driver.FindElement(By.Id("CelMedico")).SendKeys("256985648");
            driver.FindElement(By.Id("EmailMedico")).SendKeys("darwin@gmail.com");
            driver.FindElement(By.Id("DniMedico")).SendKeys("25642487");
            driver.FindElement(By.Id("FecIngMedico")).SendKeys("2015-07-07");
            driver.FindElement(By.Id("FecNacMedico")).SendKeys("1966-05-12");
            new SelectElement(driver.FindElement(By.Id("EspecialidadId"))).SelectByText("Ginecologia");
            new SelectElement(driver.FindElement(By.Id("ConsultorioId"))).SelectByText("A-7");
            driver.FindElement(By.Id("registrarMedicoConsultorio")).Click();

            driver.FindElement(By.LinkText("Medicos")).Click();
            driver.FindElement(By.XPath("//a[@href='/MedicoConsultorio/ConsultarMedicoConsultorio']")).Click();

            new SelectElement(driver.FindElement(By.Id("idespecialidad"))).SelectByText("Pediatria");
            driver.FindElement(By.Id("buscarPorEspecialidad")).Click();

            driver.Close();
        }
    }
}
