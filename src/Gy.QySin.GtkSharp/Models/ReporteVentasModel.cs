using System.Collections.Generic;
using System.Linq;
using Gtk;
using Gy.QySin.Domain.ValueObjects;

namespace Gy.QySin.GtkSharp.Models
{
    class ReporteVentasModel : ListStore
    {
        public ReporteVentasModel(
            Application.Ordenables.Consultas.Listar.OrdenablesVm ordenablesVm,
            IEnumerable<ReporteVentasItem> itemsReporte)
            : this()
        {
            var nombresPorClave = CargarNombresPorClave(ordenablesVm);
            var total = itemsReporte.SingleOrDefault(i => i.Clave == "total");
            int montoPorcentaje = 0, unidadesPorcentaje = 0;
            foreach (var item in itemsReporte)
            {
                if (total is not null)
                {
                    montoPorcentaje = (int)(100 * item.Monto / total.Monto);
                    unidadesPorcentaje = (int)(100m * item.Unidades / total.Unidades);
                }
                AppendValues(new object[] {
                    (nombresPorClave.ContainsKey(item.Clave) ? nombresPorClave[item.Clave] : item.Clave),
                    item.Unidades,
                    unidadesPorcentaje,
                    item.Monto.ToString(),
                    montoPorcentaje,
                    CalcularPesoDeFuente(item.Clave)
                });
            }
        }
        public ReporteVentasModel()
        : base(
                typeof(string), // Concepto
                typeof(string), // Unidades
                typeof(int), // Porcentaje unidades
                typeof(string), // Monto
                typeof(int), // Porcentaje monto
                typeof(int) // Font weight
            ) {}
        public void MostrarValores(IEnumerable<ReporteVentasItem> itemsReporte)
        {
            TreeIter iter;
            if (GetIterFirst(out iter))
            {
                do
                {
                    Remove(ref iter);
                } while (IterNext(ref iter));
            }
            
        }
        private Dictionary<string, string> CargarNombresPorClave(
            Application.Ordenables.Consultas.Listar.OrdenablesVm ordenablesVm
        )
        {
            var nombresPorClave = new Dictionary<string, string>(
                ordenablesVm.Bebidas.Count + ordenablesVm.Platillos.Count
            );
            foreach (var bebida in ordenablesVm.Bebidas)
            {
                nombresPorClave.Add(bebida.Clave, bebida.Nombre);
            }
            foreach (var platillo in ordenablesVm.Platillos)
            {
                nombresPorClave.Add(platillo.Clave, platillo.Nombre);
            }
            return nombresPorClave;
        }
        private Pango.Weight CalcularPesoDeFuente(string clave)
        {
            return nombresSecciones.Contains(clave) ?
                Pango.Weight.Bold :
                Pango.Weight.Normal;
        }
        private readonly string[] nombresSecciones = new string[]
        {
            ReporteVentasItem.BEBIDAS,
            ReporteVentasItem.PLATILLOS,
            ReporteVentasItem.TOTAL
        };
    }
}