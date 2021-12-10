using System;
using System.Collections.Generic;
using Gtk;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.GtkSharp.Models
{
    static class ModelFactory
    {
        public static void ConfigurarCategoriaListModel(ComboBox combo)
        {
            TreeIter iter;
            var model = new ListStore(typeof(string), typeof(string));
            model.AppendValues(new object[] { "Seleccionar...", -1 });
            foreach (var opt in categoriaOpciones)
            {
                iter = model.Append();
                model.SetValues(iter, new object[] { opt.Value, (int)opt.Key });
            }

            combo.Model = model;
            combo.IdColumn = 1;
            combo.Active = 0;
        }
        public static void ConfigurarOrdenableListModel(ComboBox combo)
        {
            combo.Model = NuevoOrdenableListModel();
            combo.IdColumn = 1;
            combo.Active = 0;
        }
        public static void ConfigurarOrdenableFilteredListModel(ComboBox combo, TreeModelFilterVisibleFunc visibleFunc)
        {
            var model = NuevoOrdenableListModel();
            var filteredModel = new TreeModelFilter(model, null);
            filteredModel.VisibleFunc = visibleFunc;
            combo.Model = filteredModel;
            combo.Active = 0;
        }
        private static ListStore NuevoOrdenableListModel()
        {
            TreeIter iter;
            var model = new ListStore(typeof(string), typeof(string), typeof(int));
            model.AppendValues(new object[] { "Seleccionar...", "-1", -1 });
            foreach (var opt in ordenableOpciones)
            {
                iter = model.Append();
                model.SetValues(iter, new object[] { opt.Value.Item1, opt.Key, (int)opt.Value.Item2 });
            }
            return model;
        }
        static private Dictionary<OrdenableCategorias, string> categoriaOpciones = new Dictionary<OrdenableCategorias, string>
        {
            { OrdenableCategorias.Platillos, "Platillos" },
            { OrdenableCategorias.Bebidas, "Bebidas"}
        };
        static private Dictionary<string, Tuple<string, OrdenableCategorias>> ordenableOpciones = new Dictionary<string, Tuple<string, OrdenableCategorias>>
        {
                { "a85f763e-4a74-11ec-957d-af9a5847120e", new Tuple<string, OrdenableCategorias>("Milanesa de res", OrdenableCategorias.Platillos) },
                { "23c2a080-4a75-11ec-be6c-9f2f00b944c5", new Tuple<string, OrdenableCategorias>("Milanesa de pollo", OrdenableCategorias.Platillos) },
                { "53c87192-4a75-11ec-a2eb-df1c165275d1", new Tuple<string, OrdenableCategorias>("Chile relleno de queso", OrdenableCategorias.Platillos) },
                { "cd5e9346-4e04-11ec-86a5-e7dac512f012", new Tuple<string, OrdenableCategorias>("Chile relleno de pollo", OrdenableCategorias.Platillos) },
                { "5d299146-52de-11ec-905c-0bd9398be3e3", new Tuple<string, OrdenableCategorias>("Bistek ranchero", OrdenableCategorias.Platillos) },
                { "cc6f3c2c-52de-11ec-b9d9-f348fbf8b319", new Tuple<string, OrdenableCategorias>("Enchiladas de pollo", OrdenableCategorias.Platillos) },
                { "d8b07a6e-52de-11ec-ba69-5f50901cce02", new Tuple<string, OrdenableCategorias>("Enchiladas de queso", OrdenableCategorias.Platillos) },
                { "6c6287bf-055c-4d26-a533-c7d78ef866f3", new Tuple<string, OrdenableCategorias>("Limonada", OrdenableCategorias.Bebidas) },
                { "0e94c95c-4e05-11ec-9480-67932bb6f9a8", new Tuple<string, OrdenableCategorias>("Agua de jamaica", OrdenableCategorias.Bebidas) },
                { "3ec21770-4e04-11ec-95c6-97281991a166", new Tuple<string, OrdenableCategorias>("Café americano", OrdenableCategorias.Bebidas) },
                { "3564501e-52d0-11ec-9279-df8a768bc59d", new Tuple<string, OrdenableCategorias>("Coca-cola", OrdenableCategorias.Bebidas) },
                { "5aa44186-52d0-11ec-beea-5b157d3e29b9", new Tuple<string, OrdenableCategorias>("Coca-cola light", OrdenableCategorias.Bebidas) },
                { "8360cdce-52d0-11ec-a593-c3c3fdde367e", new Tuple<string, OrdenableCategorias>("Sprite", OrdenableCategorias.Bebidas) },
                { "d26aa9d2-52dd-11ec-b829-135430a773b0", new Tuple<string, OrdenableCategorias>("Fanta", OrdenableCategorias.Bebidas) }
        };
    }
}