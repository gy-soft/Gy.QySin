using System;
using System.Collections.Generic;
using Gtk;
using Gy.QySin.GtkSharp.ViewModels;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp
{
    class MainWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        [UI] private Box _box_contenedor = null;
        [UI] private Button _btn_operacion = null;
        [UI] private Button _btn_reportes = null;
        [UI] private Button _btn_catalogos = null;

        public MainWindow(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            MostrarVista(Vistas.Catálogos);
            _btn_operacion.Clicked += (sender, args) =>
            {
                MostrarVista(Vistas.Operación);
            };
            _btn_reportes.Clicked += (sender, args) =>
            {
                MostrarVista(Vistas.Reportes);
            };
            _btn_catalogos.Clicked += (sender, args) =>
            {
                MostrarVista(Vistas.Catálogos);
            };
        }

        private MainWindow(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            this.serviceProvider = serviceProvider;
            vistasFactory = new Dictionary<Vistas, Func<Box>>
            {
                { Vistas.Operación, () => new OperaciónVM(this.serviceProvider)},
                { Vistas.Reportes, () => new ReportesVM(this.serviceProvider) },
                { Vistas.Catálogos, () => new CatálogosVM(this.serviceProvider)}
            };
        }

        private void MostrarVista(Vistas vista)
        {
            if (_box_contenedor.Children.GetLength(0) > 1)
            {
                var vistaActiva = _box_contenedor.Children[1];
                vistaActiva.Destroy();
                vistaActiva.Dispose();
            }
            _box_contenedor.Add(vistasFactory[vista]());
            _box_contenedor.ShowAll();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
        }

        private enum Vistas
        {
            Operación,
            Reportes,
            Catálogos
        }
        private Dictionary<Vistas, Func<Gtk.Box>> vistasFactory;
    }
}
