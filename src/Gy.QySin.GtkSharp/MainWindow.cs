using System;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;
using Gy.QySin.GtkSharp.ViewModels;
using MediatR;
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
        [UI] private Entry _text_nota = null;
        [UI] private Button _btn_registrar_venta = null;

        private AgregarOrdenVM agregarOrdenVM = null;
        private ListadoOrdenesVm listadoOrdenesVm = null;
        private ISender mediator = null;

        public MainWindow(IServiceProvider serviceProvider) : this(new Builder("MainWindow.glade"))
        {
            this.mediator = (ISender)serviceProvider.GetService(typeof(ISender));
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            agregarOrdenVM = new AgregarOrdenVM(_combo_categoria, _combo_ordenable, _spin_cantidad, _btn_agregar_orden);
            agregarOrdenVM.OrdenAgregada += AgregarOrden_OrdenAgregada;
            listadoOrdenesVm = new ListadoOrdenesVm(_list_ordenes, _text_nota, _btn_registrar_venta);
            listadoOrdenesVm.RegistrarVenta += BtnRegistrarVenta_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
        }

        private void AgregarOrden_OrdenAgregada(object sender, EventArgs a)
        {
            OrdenVal orden = (OrdenVal)sender;
            listadoOrdenesVm.AgregarOrden(orden);
        }
        private void BtnRegistrarVenta_Clicked(object sender, EventArgs a)
        {
            Application.Ventas.Comandos.Crear.CrearCmd cmd = (Application.Ventas.Comandos.Crear.CrearCmd)sender;
            mediator.Send(cmd);
        }
    }
}
