using System.Collections.Generic;

namespace Gy.QySin.GtkSharp.Models
{
    class BebidasModel : IComboBoxTextModel
    {
        public BebidasModel()
        {
            Items = new Dictionary<string, string>
            {
                { "6c6287bf-055c-4d26-a533-c7d78ef866f3", "Limonada" },
                { "0e94c95c-4e05-11ec-9480-67932bb6f9a8", "Agua de jamaica" },
                { "3ec21770-4e04-11ec-95c6-97281991a166", "Café americano" },
                { "3564501e-52d0-11ec-9279-df8a768bc59d", "Coca-cola" },
                { "5aa44186-52d0-11ec-beea-5b157d3e29b9", "Coca-cola light" },
                { "8360cdce-52d0-11ec-a593-c3c3fdde367e", "Sprite" },
                { "d26aa9d2-52dd-11ec-b829-135430a773b0", "Fanta" }
            };
        }
        public IDictionary<string, string> Items { get; set; }
    }
}