using System.Collections.Generic;

namespace Gy.QySin.GtkSharp.Models
{
    class CategoriaModel : IComboBoxTextModel
    {
        public CategoriaModel()
        {
            Items = new Dictionary<string, string>
            {
                { "0", "Platillos" },
                { "1", "Bebidas" }
            };
        }
        public IDictionary<string, string> Items { get; set; }
    }
}