using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class ListadoOrdenesVm
    {
        private readonly ListBox listOrdenes;

        public ListadoOrdenesVm(ListBox listOrdenes)
        {
            this.listOrdenes = listOrdenes;
        }
        public void AgregarOrden(OrdenDto nuevaOrden)
        {
            string text = $"{nuevaOrden.Cantidad} - {nuevaOrden.Nombre}";
            var label = new Label(text);
            listOrdenes.Add(label);
            label.Show();
        }
    }
}