using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CLINICAMVC.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string NomEmpleado { get; set; }
        [Required]
        public string ApeEmpleado { get; set; }
        [Required]
        public string DirEmpleado { get; set; }
        [Required]
        public string CelEmpleado { get; set; }
        [Required]
        public string EmailEmpleado { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(8, ErrorMessage = "El campo {0} debe tener {1} caracteres", MinimumLength = 8)]
        public string DniEmpleado { get; set; }
        public DateTime FecIngEmpleado { get; set; }
        public DateTime FecNacEmpleado { get; set; }
        public bool EstadoUsuario { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<Consultorio> Consultorio { get; set; }
        public DbSet<Medico> Medico { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}