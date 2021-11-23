using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.SqlPersistence
{
    public class ApplicationRepositories : IApplicationRepositories
    {
        private readonly IRepository<Usuario> usuarios;
        private readonly IRepository<Ordenable> ordenables;
        private readonly IRepository<Bebida> bebidas;
        private readonly IRepository<Platillo> platillos;
        public ApplicationRepositories(IApplicationDbContext context)
        {
            usuarios = new SqlRepository<IApplicationDbContext, Usuario>(context, context.Usuarios);
        }
        public IRepository<Usuario> Usuarios => usuarios;

        public IRepository<Ordenable> Ordenables => ordenables;

        public IRepository<Bebida> Bebidas => bebidas;

        public IRepository<Platillo> Platillos => platillos;
    }
}