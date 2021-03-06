using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Gy.QySin.Persistence.Sql
{
    public class PgSqlDbContext : DbContext, ISqlDbContext
    {

        /// <summary>
        /// Constructor pensado para usarse con Inyección de Dependencias (DI).
        /// Es llamado implícitamente por el método UsePostgres(...).
        /// </summary>
        /// <param name="options">El objeto con la configuración.</param>
        public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options)
            : base(options) {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<OrdenableCategorias>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<UsuarioRoles>("UsuarioRoles");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<OrdenableCategorias>("OrdenableCategorias");
        }

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ordenable> Ordenables { get; set; }
        public DbSet<PrecioOrdenable> PrecioOrdenables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<UsuarioRoles>();
            modelBuilder.HasPostgresEnum<OrdenableCategorias>();
            modelBuilder.Entity<Ordenable>()
                .ToTable("Ordenables");
            modelBuilder.Entity<Bebida>()
                .ToTable("Bebidas");
            modelBuilder.Entity<Platillo>()
                .ToTable("Platillos");
            modelBuilder.Entity<PrecioOrdenable>()
                .HasKey(p => new { p.Clave, p.FechaInicio });
        }
    }
}