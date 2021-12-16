using System.Collections.Generic;
using System.Linq;
using Magnitudes = Gy.QySin.Domain.ValueObjects.ReporteVentasValorPuntual.Magnitudes;

namespace Gy.QySin.Domain.ValueObjects
{
    public class ReporteVentasItem
    {
        public ReporteVentasItem(string clave, int unidades, decimal monto)
        {
            Clave = clave;
            Unidades = unidades;
            Monto = monto;
        }

        public string Clave { get; set; }
        public int Unidades { get; set; }
        public decimal Monto { get; set; }
    }
    public static class ReporteVentasExtensions
    {
        public static IEnumerable<ReporteVentasItem> AReporteVentasItems(this IEnumerable<ReporteVentasValorPuntual> valoresPuntuales)
        {
            var porClave = valoresPuntuales.GroupBy(v => v.Clave);
            var items = new List<ReporteVentasItem>(porClave.Count());
            foreach (var clave in porClave)
            {
                items.Add(new ReporteVentasItem(
                    clave.Key,
                    (int)clave.SingleOrDefault(v => v.Magnitud == Magnitudes.Unidades)?.Valor,
                    clave.SingleOrDefault(v => v.Magnitud == Magnitudes.Monto).Valor
                ));
            }
            return items;
        }
    }
}