using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.SqlPersistence
{
    public class ApplicationRepositories : IApplicationRepositories
    {
        public ApplicationRepositories(IApplicationDbContext context)
        {
            Usuarios = new SqlRepository<IApplicationDbContext, Usuario>(context, context.Usuarios);
            Ordenables = new SqlRepository<IApplicationDbContext, Ordenable>(context, context.Ordenables);
            Bebidas = new SqlRepository<IApplicationDbContext, Bebida>(context, context.Bebidas);
            Platillos = new SqlRepository<IApplicationDbContext, Platillo>(context, context.Platillos);
            Comandas = new SqlRepository<IApplicationDbContext, Comanda>(context, context.Comandas);
        }
        public IRepository<Usuario> Usuarios { get; private set; }

        public IRepository<Ordenable> Ordenables { get; private set; }

        public IRepository<Bebida> Bebidas { get; private set;}

        public IRepository<Platillo> Platillos { get; private set; }

        public IRepository<Comanda> Comandas { get; private set; }
    }
}