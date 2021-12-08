using System.Collections.Generic;

namespace Gy.QySin.GtkSharp.Models
{
    class PlatillosModel : IComboBoxTextModel
    {
        public PlatillosModel()
        {
            Items = new Dictionary<string, string>
            {
                { "a85f763e-4a74-11ec-957d-af9a5847120e", "Milanesa de res" },
                { "23c2a080-4a75-11ec-be6c-9f2f00b944c5", "Milanesa de pollo" },
                { "53c87192-4a75-11ec-a2eb-df1c165275d1", "Chile relleno de queso" },
                { "cd5e9346-4e04-11ec-86a5-e7dac512f012", "Chile relleno de picadillo" },
                { "5d299146-52de-11ec-905c-0bd9398be3e3", "Bistek ranchero" },
                { "cc6f3c2c-52de-11ec-b9d9-f348fbf8b319", "Enchiladas de pollo" },
                { "d8b07a6e-52de-11ec-ba69-5f50901cce02", "Enchiladas de queso" },
            };
        }
        public IDictionary<string, string> Items { get; set; }
    }
}