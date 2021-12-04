using Gy.QySin.Domain.Entities;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IApplicationRepositories
    {
        IRepository<Usuario> Usuarios { get; }
        IRepository<Bebida> Bebidas { get; }
        IRepository<Platillo> Platillos { get; }
        IRepository<Ordenable> Ordenables { get; }
        IRepository<PrecioOrdenable> PrecioOrdenables { get; }
    }
}