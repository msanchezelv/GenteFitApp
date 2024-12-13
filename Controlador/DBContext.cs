using GenteFitApp.Modelo;
using System.Data.Entity;

namespace GenteFitApp.Controlador
{
    public class GenteFitDbContext : DbContext
    {
        // Definir los DbSet para las entidades
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Monitor> Monitores { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Constructor que usa la cadena de conexión del archivo de configuración
        public GenteFitDbContext() : base(DatabaseConfig.ConnectionString)
        {
        }

        // Configuración adicional si es necesario
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Aquí puedes agregar configuraciones adicionales (si es necesario)
            base.OnModelCreating(modelBuilder);
        }
    }
}
