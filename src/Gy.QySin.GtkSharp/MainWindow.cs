using System;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;
using Gy.QySin.GtkSharp.ViewModels;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp
{
    class MainWindow : Window
    {
        [UI] private ComboBoxText _combo_categoria = null;
        [UI] private ComboBoxText _combo_ordenable = null;
        [UI] private SpinButton _spin_cantidad = null;
        [UI] private Button _btn_agregar_orden = null;
        [UI] private ListBox _list_ordenes = null;
        [UI] private Button _btn_registrar_venta = null;

        private AgregarOrdenVM agregarOrdenVM = null;
        private ListadoOrdenesVm listadoOrdenesVm = null;

        private readonly IServiceProvider serviceProvider;

        public MainWindow(IServiceProvider serviceProvider) : this(new Builder("MainWindow.glade"))
        {
            this.serviceProvider = serviceProvider;
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _btn_registrar_venta.Clicked += BtnRegistrarVenta_Clicked;
            agregarOrdenVM = new AgregarOrdenVM(_combo_categoria, _combo_ordenable, _spin_cantidad, _btn_agregar_orden);
            agregarOrdenVM.OrdenAgregada += AgregarOrden_OrdenAgregada;
            listadoOrdenesVm = new ListadoOrdenesVm(_list_ordenes);
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
        }

        private void AgregarOrden_OrdenAgregada(object sender, EventArgs a)
        {
            OrdenDto dto = (OrdenDto)sender;
            listadoOrdenesVm.AgregarOrden(dto);
        }
        private void BtnRegistrarVenta_Clicked(object sender, EventArgs a)
        {
            //
        }
    }
}
