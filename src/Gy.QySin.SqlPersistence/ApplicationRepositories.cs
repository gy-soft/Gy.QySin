using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.SqlPersistence
{
    public class ApplicationRepositories : IApplicationRepositories
    {
        public ApplicationRepositories(IApplicationDbContext context)
        {
            Usuarios = new SqlRepository<IApplicationDbContext, Usuario>(context, context.Usuarios);
            Bebidas = new SqlRepository<IApplicationDbContext, Bebida>(context, context.Bebidas);
            Platillos = new SqlRepository<IApplicationDbContext, Platillo>(context, context.Platillos);
            PrecioOrdenables = new SqlRepository<IApplicationDbContext, PrecioOrdenable>(context, context.PrecioOrdenables);
            PrecioOrdenablesUi = new SqlRepository<IApplicationDbContext, PrecioOrdenableUi>(context, context.PrecioOrdenablesUi);
        }
        public IRepository<Usuario> Usuarios { get; private set; }

        public IRepository<Bebida> Bebidas { get; private set;}

        public IRepository<Platillo> Platillos { get; private set; }

        public IRepository<PrecioOrdenable> PrecioOrdenables { get; private set; }
        public IRepository<PrecioOrdenableUi> PrecioOrdenablesUi { get; private set; }
    }
}