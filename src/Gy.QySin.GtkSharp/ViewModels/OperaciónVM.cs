using System;
using Gtk;
using Gy.QySin.GtkSharp.Interfaces;
using Gy.QySin.GtkSharp.ValueObjects;
using MediatR;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class OperaciónVM : Gtk.Box
    {
        [UI] private ComboBoxText _combo_categoria = null;
        [UI] private ComboBoxText _combo_ordenable = null;
        [UI] private SpinButton _spin_cantidad = null;
        [UI] private Button _btn_agregar_orden = null;
        [UI] private TreeView _list_ordenes = null;
        [UI] private Entry _text_nota = null;
        [UI] private Button _btn_registrar_venta = null;
        private AgregarOrdenVM agregarOrdenVM = null;
        private RegistrarVentaVM listadoOrdenesVm = null;
        private ISender mediator = null;
        private ICatálogosService catálogosService = null;
        public OperaciónVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            agregarOrdenVM = new AgregarOrdenVM(catálogosService, _combo_categoria, _combo_ordenable, _spin_cantidad, _btn_agregar_orden);
            agregarOrdenVM.OrdenAgregada += AgregarOrden_OrdenAgregada;
            listadoOrdenesVm = new RegistrarVentaVM(_list_ordenes, _text_nota, _btn_registrar_venta);
            listadoOrdenesVm.RegistrarVenta += BtnRegistrarVenta_Clicked;
        }

        private OperaciónVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxOperación"))
        {
            builder.Autoconnect(this);
            this.mediator = (ISender)serviceProvider.GetService(typeof(ISender));
            this.catálogosService = (ICatálogosService)serviceProvider.GetService(typeof(ICatálogosService));
            ConfigurarWidgetsPorDefecto();
        }
        private void AgregarOrden_OrdenAgregada(object sender, EventArgs a)
        {
            VentaDetalle orden = (VentaDetalle)sender;
            listadoOrdenesVm.AgregarOrden(orden);
        }
        private void BtnRegistrarVenta_Clicked(object sender, EventArgs a)
        {
            Application.Ventas.Comandos.Crear.CrearCmd cmd = (Application.Ventas.Comandos.Crear.CrearCmd)sender;
            mediator.Send(cmd);
        }
        private void ConfigurarWidgetsPorDefecto()
        {
            ListStore model = new ListStore(
                typeof(string),
                typeof(string)
            );
            model.AppendValues(new object[] { "Seleccionar...", "-1" });
            _combo_ordenable.Model = new TreeModelFilter(model, null);
        }
    }
}