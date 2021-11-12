using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Common
{
    public interface IApplicationDbContext
    {
        DbSet<BaseOrdenable> Ordenables {get;set;}
        DbSet<Bebida> Bebidas { get; set; }
        DbSet<Platillo> Platillos { get; set; }
        DbSet<Comanda> Comandas { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}