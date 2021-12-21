using System.Collections.Generic;
using Gtk;
using Gy.QySin.Application.Precios.Consultas.Listar;

namespace Gy.QySin.GtkSharp.Models
{
    class CatálogoPreciosModel : TreeModelFilter
    {
        public CatálogoPreciosModel()
        : base(new ListStore(
            typeof(string), // Nombre
            typeof(string), // Precio
            typeof(string), // FechaInicio
            typeof(string) // FechaFin
        ), null) {}

        internal void AgregarPrecios(List<PrecioOrdenableDto> precios)
        {
            var model = (ListStore)Model;
            foreach(var precio in precios)
            {
                model.AppendValues(new object[]
                {
                    precio.Nombre,
                    $"${precio.Precio}",
                    precio.FechaInicio.ToShortDateString(),
                    precio.FechaFin.HasValue ? precio.FechaFin.Value.ToShortDateString() : ""
                });
            }
        }
    }
}