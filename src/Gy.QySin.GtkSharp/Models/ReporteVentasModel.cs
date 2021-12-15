using System.Collections.Generic;
using System.Linq;
using Gtk;
using Gy.QySin.Application.Ordenables.Consultas.Listar;
using Gy.QySin.Domain.Entities;
using Gy.QySin.Domain.ValueObjects;

namespace Gy.QySin.GtkSharp.Models
{
    class ReporteVentasModel : ListStore
    {
        private readonly Dictionary<string, string> Ordenables;
        public ReporteVentasModel(
            Application.Ordenables.Consultas.Listar.OrdenablesVm ordenables,
            IEnumerable<ArrObjectKeyDecimalValue> itemsReporte)
            : base(
                typeof(string), // Concepto
                typeof(string), // Unidades
                typeof(int), // Porcentaje unidades
                typeof(string), // Monto
                typeof(int), // Porcentaje monto
                typeof(int) // Font weight
            )
        {
            Ordenables = new Dictionary<string, string>(ordenables.Bebidas.Count + ordenables.Platillos.Count);
            foreach (var bebida in ordenables.Bebidas)
            {
                Ordenables.Add(bebida.Clave, bebida.Nombre);
            }
            foreach (var platillo in ordenables.Platillos)
            {
                Ordenables.Add(platillo.Clave, platillo.Nombre);
            }

            MostrarDatos(itemsReporte);
        }
        private void MostrarDatos(IEnumerable<ArrObjectKeyDecimalValue> itemsReporte)
        {
            var rows = new Dictionary<string, ReporteVentasItem>();
            string clave, propiedad;
            ReporteVentasItem row;
            foreach (var item in itemsReporte)
            {
                clave = item.Key.Length > 5 ?
                    (string)item.Key[5] :
                    (string)item.Key[4];
                propiedad = (string)item.Key[3];
                if(!rows.TryGetValue(clave, out row))
                {
                    row = new ReporteVentasItem(clave, Ordenables);
                    rows.Add(clave, row);
                }
                if (propiedad == "unidades")
                    row.Unidades = (int)item.Value;
                if (propiedad == "monto")
                    row.Monto = item.Value;
            }
            
            var total = rows.ContainsKey("total") ? rows["total"] : null;
            int montoPorcentaje = 0, unidadesPorcentaje = 0;
            foreach (var valor in rows.Values)
            {
                if (total is not null)
                {
                    montoPorcentaje = (int)(100 * valor.Monto / total.Monto);
                    unidadesPorcentaje = (int)(100m * valor.Unidades / total.Unidades);
                }
                AppendValues(new object[] {
                    valor.Concepto,
                    valor.Unidades,
                    unidadesPorcentaje,
                    valor.Monto.ToString(),
                    montoPorcentaje,
                    valor.FontWeight
                });
            }
        }
        class ReporteVentasItem
        {
            private static string[] categorias = new string[] { "total", "bebidas", "platillos" };
            public ReporteVentasItem(string clave, Dictionary<string, string> Ordenables)
            {
                Clave = clave;
                Concepto = Ordenables.ContainsKey(clave) ?
                    Ordenables[clave] :
                    clave;
                FontWeight = categorias.Contains(clave) ?
                    Pango.Weight.Bold :
                    Pango.Weight.Normal;
            }
            public string Clave { get; set; }
            public string Concepto { get; set; }
            public int Unidades { get; set; }
            public decimal Monto { get; set; }
            public Pango.Weight FontWeight { get; set; }
        }
    }
}