using System.Collections.Generic;
using Xunit;

namespace Gy.QySin.Domain.ValueObjects.Test
{
    public class ReporteVentasItemTest
    {
        [Fact]
        public void ConstruirDeValoresPuntuales()
        {
            var valoresPuntuales = new List<ReporteVentasValorPuntual>
            {
                new ReporteVentasValorPuntual
                {
                    Clave = "id-platillo-1",
                    Magnitud = ReporteVentasValorPuntual.Magnitudes.Monto,
                    Valor = 1001.1m
                },
                new ReporteVentasValorPuntual
                {
                    Clave = "id-platillo-1",
                    Magnitud = ReporteVentasValorPuntual.Magnitudes.Unidades,
                    Valor = 3m,
                },
                new ReporteVentasValorPuntual
                {
                    Clave = "id-bebida-2",
                    Magnitud = ReporteVentasValorPuntual.Magnitudes.Unidades,
                    Valor = 5m
                },
                new ReporteVentasValorPuntual
                {
                    Clave = "id-bebida-2",
                    Magnitud = ReporteVentasValorPuntual.Magnitudes.Monto,
                    Valor = 444.43m
                }
            };
            var items = valoresPuntuales.AReporteVentasItems();
            Assert.Contains(items, (i) =>
            {
                return i.Clave == "id-platillo-1"
                && i.Monto == 1001.1m
                && i.Unidades == 3;
            });
            Assert.Contains(items, (i) =>
            {
                return i.Clave == "id-bebida-2"
                && i.Monto == 444.43m
                && i.Unidades == 5;
            });
        }
    }
}