using Gtk;

namespace Gy.QySin.GtkSharp.Models
{
    static class ConfiguradorDeWidgets
    {
        public static void ConfigurarTreeVentaDetalles(TreeView treeView)
        {
            var cantidadRenderer = new CellRendererSpin()
            {
                Editable = true,
                Adjustment = new CantidadAdjustment(),
            };
            cantidadRenderer.Edited += (sender, args) =>
            {
                var renderer = (CellRendererSpin)sender;
                treeView.Model.GetIter(out TreeIter iter, new TreePath(args.Path));
                treeView.Model.SetValue(iter, 1, renderer.Adjustment.Value);
            };
            treeView.AppendColumn(
                new TreeViewColumn("Cantidad", cantidadRenderer, new object[] { "text", 1 })
            );
            treeView.AppendColumn(
                new TreeViewColumn("Nombre", new CellRendererText(), new object[] {"text", 0})
            );
            var eliminarRenderer = new CellRendererToggle();
            eliminarRenderer.Radio = true;
            eliminarRenderer.Toggled += (sender, args) =>
            {
                var renderer = (CellRendererToggle)sender;
                var model = (ListStore)treeView.Model;
                model.GetIter(out TreeIter iter, new TreePath(args.Path));
                model.Remove(ref iter);
            };
            treeView.AppendColumn(
                new TreeViewColumn("Eliminar", eliminarRenderer, System.Array.Empty<object>())
            );
        }
        public static void ConfigurarComboCategorias(ITreeModel model, ComboBox combo)
        {
            combo.Model = model;
            combo.IdColumn = 1;
            combo.Active = 0;
        }
        public static void ConfigurarComboOrdenables(
            ITreeModel model,
            ComboBox combo,
            TreeModelFilterVisibleFunc visibleFunc
        )
        {
            var filteredModel = new TreeModelFilter(model, null);
            filteredModel.VisibleFunc = visibleFunc;
            combo.Model = filteredModel;
            combo.IdColumn = 1;
            combo.Active = 0;
        }
        public static void ConfigurarTreeReporteVentas(TreeView treeView)
        {
            treeView.Model = new ReporteVentasModel();
            treeView.AppendColumn(
                new TreeViewColumn("Concepto", new CellRendererText(), new object[] { "text", 0, "weight", 5 })
            );
            treeView.AppendColumn(
                new TreeViewColumn("Unidades", new CellRendererText(), new object[] { "text", 1, "weight", 5 })
            );
            treeView.AppendColumn(
                new TreeViewColumn("Porcentaje", new CellRendererProgress(), new object[] { "value", 2 })
            );
            treeView.AppendColumn(
                new TreeViewColumn("Monto", new CellRendererText(), new object[] { "text", 3, "weight", 5 })
            );
            treeView.AppendColumn(
                new TreeViewColumn("Porcentaje", new CellRendererProgress(), new object[] { "value", 4 })
            );
        }
    }
}