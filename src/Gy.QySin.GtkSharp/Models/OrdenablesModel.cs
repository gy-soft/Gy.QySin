using System.Collections.Generic;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Models
{
    class OrdenablesModel : ListStore
    {
        public OrdenablesModel(IEnumerable<Ordenable> ordenables)
            : base(
                typeof(string), // Nombre
                typeof(string), // Clave
                typeof(int) // Categoria
            )
        {
            AppendValues(new object[] { "Seleccionar...", "-1", -1 });
            foreach (var ord in ordenables)
            {
                AppendValues(ord.Nombre, ord.Clave, ord.Categoria);
            }
        }
    }
}