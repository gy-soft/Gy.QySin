using System.Collections.Generic;
using Gtk;
using Gy.QySin.Application.Ordenables.Consultas.Listar;

namespace Gy.QySin.GtkSharp.Models
{
    class CatáloBebidasModel : TreeModelFilter
    {
        public CatáloBebidasModel()
        : base(new ListStore(
            typeof(string), // Nombre
            typeof(string), // Contenido
            typeof(string) // Precio
        ), null) {}

        internal void AgregarBebidas(IList<BebidaDto> bebidas)
        {
            var model = (ListStore)Model;
            foreach (var bebida in bebidas)
            {
                model.AppendValues(new object[]
                {
                    bebida.Nombre,
                    bebida.Contenido.ToString(),
                    bebida.Precio.ToString("C")
                });
            }
        }
    }
}