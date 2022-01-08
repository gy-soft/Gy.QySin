using System.Collections.Generic;
using Gtk;
using Gy.QySin.Application.Ordenables.Consultas.Listar;

namespace Gy.QySin.GtkSharp.Models
{
    class CatálogoPlatillosModel : TreeModelFilter
    {
        public CatálogoPlatillosModel()
        : base(new ListStore(
            typeof(string), // Nombre
            typeof(string), // Vegetariano
            typeof(string) // Precio
        ), null) {}

        internal void AgregarPlatillos(IList<PlatilloDto> platillos)
        {
            var model = (ListStore)Model;
            foreach (var platillo in platillos)
            {
                model.AppendValues(
                    platillo.Nombre,
                    platillo.Vegetariano ? "Sí" : "No",
                    platillo.Precio.ToString("C")
                );
            }
        }
    }
}