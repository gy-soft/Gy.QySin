using System.Threading;
using System.Threading.Tasks;
using Gy.QySin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Bebida> Bebidas { get; set; }
        DbSet<Platillo> Platillos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Ordenable> Ordenables { get; set; }
        DbSet<PrecioOrdenable> PrecioOrdenables { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}