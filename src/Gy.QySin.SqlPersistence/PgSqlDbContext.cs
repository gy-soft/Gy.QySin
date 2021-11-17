using Gy.QySin.Application.Common;
using Gy.QySin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.SqlPersistence
{
    public class PgSqlDbContext : DbContext, IApplicationDbContext
    {
        private readonly string connectionString;

        // Use with DI
        public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options)
            : base(options) {}
        // Manual setup
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
    }
}