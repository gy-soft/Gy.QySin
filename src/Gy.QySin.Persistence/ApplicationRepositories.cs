using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Persistence.Document;
using Gy.QySin.Persistence.Sql;

namespace Gy.QySin.Persistence
{
    public class ApplicationRepositories : IApplicationRepositories
    {
        public ApplicationRepositories(ISqlDbContext context, ICouchClientFactory docClientFactory)
        {
            Usuarios = new SqlRepository<ISqlDbContext, Usuario>(context, context.Usuarios);
            Bebidas = new SqlRepository<ISqlDbContext, Bebida>(context, context.Bebidas);
            Platillos = new SqlRepository<ISqlDbContext, Platillo>(context, context.Platillos);
            Ordenables = new SqlRepository<ISqlDbContext, Ordenable>(context, context.Ordenables);
            PrecioOrdenables = new SqlRepository<ISqlDbContext, PrecioOrdenable>(context, context.PrecioOrdenables);
            Ventas = new VentasRepository(docClientFactory);
        }
        public IRepository<Usuario> Usuarios { get; private set; }

        public IRepository<Bebida> Bebidas { get; private set;}

        public IRepository<Platillo> Platillos { get; private set; }
        public IRepository<Ordenable> Ordenables { get; private set; }

        public IRepository<PrecioOrdenable> PrecioOrdenables { get; private set; }
        public IAppendRepository<Venta> Ventas { get; private set; }
    }
}