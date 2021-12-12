using System.Collections.Generic;
using System.Threading;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using MediatR;

namespace Gy.QySin.Application.Ventas.Consultas
{
    public class ListarPorFechaCon : IRequest<IEnumerable<Venta>>
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Día { get; set; }
        public bool IncluirDetalle { get; set; }
    }
    public class ListarPorFechaConMnjr : IRequestHandler<ListarPorFechaCon, IEnumerable<Venta>>
    {
        private readonly IApplicationRepositories repos;
        private readonly IDbConfigurations dbConfigurations;

        public ListarPorFechaConMnjr(
            IApplicationRepositories repos,
            IDbConfigurations dbConfigurations)
        {
            this.repos = repos;
            this.dbConfigurations = dbConfigurations;
        }
        public async  System.Threading.Tasks.Task<IEnumerable<Venta>> Handle(
            ListarPorFechaCon request, CancellationToken cancellationToken)
        {
            var query = new ByDateQuery
            {
                Date = new int[] { request.Año, request.Mes, request.Día },
                Limit = dbConfigurations.ResultsLimit,
                IncludeAggregates = request.IncluirDetalle
            };
            return await repos.Ventas.QueryByDateAsync(query);
        }
    }
}