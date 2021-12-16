using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.ValueObjects;

namespace Gy.QySin.Application.Common.Interfaces
{
    public interface IApplicationRepositories
    {
        IRepository<Usuario> Usuarios { get; }
        IRepository<Bebida> Bebidas { get; }
        IRepository<Platillo> Platillos { get; }
        IRepository<Ordenable> Ordenables { get; }
        IRepository<PrecioOrdenable> PrecioOrdenables { get; }
        IAppendRepository<Venta> Ventas { get; }
        IReportRepository<ReporteVentasItem> ReportRepository { get; }
    }
}