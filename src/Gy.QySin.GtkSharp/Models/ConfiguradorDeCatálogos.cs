using System;
using Gtk;

namespace Gy.QySin.GtkSharp.Models
{
    static class ConfiguradorDeCatálogos
    {
        internal static void ConfigurarTreeBebidas(TreeView treeView, TreeModelFilterVisibleFunc visibleFunc)
        {
            RemoverColumnas(treeView);
            var filteredModel = new CatáloBebidasModel();
            filteredModel.VisibleFunc = visibleFunc;
            treeView.Model = filteredModel;
            treeView.AppendColumn(
                "Nombre", new CellRendererText(), new object[] { "text", 0 }
            );
            treeView.AppendColumn(
                "Contenido", new CellRendererText(), new object[] { "text", 1 }
            );
            treeView.AppendColumn(
                "Precio", new CellRendererText(), new object[] { "text", 2 }
            );
        }
        internal static void ConfigurarTreePlatillos(TreeView treeView, TreeModelFilterVisibleFunc visibleFunc)
        {
            RemoverColumnas(treeView);
            var filteredModel = new CatálogoPlatillosModel();
            filteredModel.VisibleFunc = visibleFunc;
            treeView.Model = filteredModel;
            treeView.AppendColumn(
                "Nombre", new CellRendererText(), new object[] { "text", 0 }
            );
            treeView.AppendColumn(
                "Vegetariano", new CellRendererText(), new object[] { "text", 1 }
            );
            treeView.AppendColumn(
                "Precio", new CellRendererText(), new object[] { "text", 2 }
            );
        }
        internal static void ConfigurarTreePrecios(TreeView treeView, TreeModelFilterVisibleFunc visibleFunc)
        {
            RemoverColumnas(treeView);
            var filteredModel = new CatálogoPreciosModel();
            filteredModel.VisibleFunc = visibleFunc;
            treeView.Model = filteredModel;
            treeView.AppendColumn(
                "Nombre", new CellRendererText(), new object[] { "text", 0 }
            );
            treeView.AppendColumn(
                "Precio", new CellRendererText(), new object[] { "text", 1 }
            );
            treeView.AppendColumn(
                "Fecha Inicio", new CellRendererText(), new object[] { "text", 2 }
            );
            treeView.AppendColumn(
                "Fecha Fin", new CellRendererText(), new object[] { "text", 3 }
            );
        }

        private static void RemoverColumnas(TreeView treeView)
        {
            foreach (var col in treeView.Columns)
            {
                treeView.RemoveColumn(col);
            }
        }
    }
}