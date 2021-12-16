using System.Collections.Generic;
using System.Linq;
using Xunit;
using Periodos = Gy.QySin.Domain.ValueObjects.ReporteVentasValorPuntual.Periodos;

namespace Gy.QySin.Domain.ValueObjects.Test
{
    public class ReporteVentasValorPuntualTest
    {
        [Fact]
        public void ConstruirDeUnKeyValue_MontoTotalDiario()
        {
            var KeyValue = new ArrObjectKeyDecimalValue();
            KeyValue.Key = new object[] { 2020, 1, 1, "monto", "total" };
            KeyValue.Value = 123.45m;

            var valorPuntual = new ReporteVentasValorPuntual(KeyValue, Periodos.Diario);
            Assert.Equal("total", valorPuntual.Clave);
            Assert.Equal(ReporteVentasValorPuntual.Magnitudes.Monto, valorPuntual.Magnitud);
            Assert.Equal(123.45m, valorPuntual.Valor);
        }
        [Fact]
        public void ConstruirDeUnKeyValue_UnidadesTotalDiario()
        {
            var KeyValue = new ArrObjectKeyDecimalValue();
            KeyValue.Key = new object[] { 2020, 1, 1, "unidades", "total" };
            KeyValue.Value = 123;

            var valorPuntual = new ReporteVentasValorPuntual(KeyValue, Periodos.Diario);
            Assert.Equal("total", valorPuntual.Clave);
            Assert.Equal(ReporteVentasValorPuntual.Magnitudes.Unidades, valorPuntual.Magnitud);
            Assert.Equal(123, valorPuntual.Valor);
        }
        [Fact]
        public void ConstruirDeUnKeyValue_MontoOrdenableDiario()
        {
            var KeyValue = new ArrObjectKeyDecimalValue();
            KeyValue.Key = new object[] { 2020, 1, 1, "monto", "platillos", "id-platillo" };
            KeyValue.Value = 123.45m;

            var valorPuntual = new ReporteVentasValorPuntual(KeyValue, Periodos.Diario);
            Assert.Equal("id-platillo", valorPuntual.Clave);
            Assert.Equal(ReporteVentasValorPuntual.Magnitudes.Monto, valorPuntual.Magnitud);
            Assert.Equal(123.45m, valorPuntual.Valor);
        }
        [Fact]
        public void ConstruirDeUnKeyValue_UnidadesOrdenableDiario()
        {
            var KeyValue = new ArrObjectKeyDecimalValue();
            KeyValue.Key = new object[] { 2020, 1, 1, "unidades", "platillos", "id-platillo" };
            KeyValue.Value = 123;

            var valorPuntual = new ReporteVentasValorPuntual(KeyValue, Periodos.Diario);
            Assert.Equal("id-platillo", valorPuntual.Clave);
            Assert.Equal(ReporteVentasValorPuntual.Magnitudes.Unidades, valorPuntual.Magnitud);
            Assert.Equal(123, valorPuntual.Valor);
        }
        [Fact]
        public void ConstruirDeVariosKeyValue_MontoOrdenableDiario()
        {
            List<ArrObjectKeyDecimalValue> keyValues = new List<ArrObjectKeyDecimalValue>
            {
                new ArrObjectKeyDecimalValue
                {
                    Key = new object[] { 2020, 1, 1, "monto", "platillos", "id-platillo-1" },
                    Value = 1001.1m
                },
                new ArrObjectKeyDecimalValue
                {
                    Key = new object[] { 2020, 1, 1, "monto", "platillos", "id-platillo-2" },
                    Value = 1002.2m
                },
                new ArrObjectKeyDecimalValue
                {
                    Key = new object[] { 2020, 1, 1, "unidades", "bebidas" },
                    Value = 3,
                },
                new ArrObjectKeyDecimalValue
                {
                    Key = new object[] { 2020, 1, 1, "unidades", "total" },
                    Value = 5
                }
            };
            var valoresPuntuales = keyValues.Select(kv => new ReporteVentasValorPuntual(kv, Periodos.Diario));
            Assert.Contains(valoresPuntuales, (v) => {
                return v.Clave == "id-platillo-1"
                && v.Magnitud == ReporteVentasValorPuntual.Magnitudes.Monto
                && v.Valor == 1001.1m;
            });
            Assert.Contains(valoresPuntuales, (v) => {
                return v.Clave == "id-platillo-2"
                && v.Magnitud == ReporteVentasValorPuntual.Magnitudes.Monto
                && v.Valor == 1002.2m;
            });
            Assert.Contains(valoresPuntuales, (v) => {
                return v.Clave == "bebidas"
                && v.Magnitud == ReporteVentasValorPuntual.Magnitudes.Unidades
                && v.Valor == 3;
            });
            Assert.Contains(valoresPuntuales, (v) => {
                return v.Clave == "total"
                && v.Magnitud == ReporteVentasValorPuntual.Magnitudes.Unidades
                && v.Valor == 5;
            });
        }
    }
}