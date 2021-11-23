using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Gy.QySin.SqlPersistence
{
    public class PgSqlDbContext : DbContext, IApplicationDbContext
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

        public DbSet<Ordenable> Ordenables { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

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
            modelBuilder.Entity<Comanda>()
                .HasKey(c => c.NúmeroComanda)
                .HasName("Comanda_pkey");
        }
    }
}