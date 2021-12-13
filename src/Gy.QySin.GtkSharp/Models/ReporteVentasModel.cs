using System.Collections.Generic;
using Gtk;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.GtkSharp.Models
{
    class ReporteVentasModel : ListStore
    {
        public ReporteVentasModel(IEnumerable<Venta> ventas)
            : base(
                typeof(string),
                typeof(string),
                typeof(string)
            )
        {
            
        }
    }
}