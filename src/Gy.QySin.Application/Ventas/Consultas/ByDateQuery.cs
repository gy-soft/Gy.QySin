using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Ventas.Consultas
{
    class ByDateQuery : IByDateQuery
    {
        public int Limit { set; get; }
        public int[] Date { set; get; }
        public bool IncludeAggregates { set; get; }
    }
}