using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.SqlPersistence
{
    public class PgSqlDbContext : DbContext, IApplicationDbContext
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor pensado para usarse con Inyección de Dependencias (DI).
        /// Es llamado implícitamente por el método UsePostgres(...).
        /// </summary>
        /// <param name="options">El objeto con la configuración.</param>
        public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options)
            : base(options) {}
        /// <summary>
        /// Constructor para configurar manualmente la cadena de conexión.
        /// Para usarse en pruebas unitarias por ejemplo.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos PostgreSQL.</param>
        public PgSqlDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<BaseOrdenable> Ordenables { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString != null)
                optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bebida>()
                .ToView("vBebidas");
            modelBuilder.Entity<Platillo>()
                .ToView("vPlatillos");
        }
    }
}