using System.Collections.Generic;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Models
{
    class CategoriaModel : ListStore
    {
        public CategoriaModel(IEnumerable<IdNombre> categorias)
            : base(
                typeof(string), // Nombre
                typeof(int) // Id
            )
        {
            AppendValues(new object[] { "Seleccionar...", -1 });
            foreach (var cat in categorias)
            {
                AppendValues(new object[] { cat.Nombre, cat.Id });
            }
        }
    }
}