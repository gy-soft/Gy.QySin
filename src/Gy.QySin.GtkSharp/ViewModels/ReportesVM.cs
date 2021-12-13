using System;
using System.Threading.Tasks;
using Gtk;
using Gy.QySin.GtkSharp.Models;
using MediatR;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class ReportesVM : Gtk.Box
    {
        [UI] private TreeView _list_reporte = null;
        private readonly ISender mediator;

        public ReportesVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            ConfiguradorDeWidgets.ConfigurarTreeReporteVentas(_list_reporte);
        }
        private ReportesVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxReportes"))
        {
            this.mediator = (ISender)serviceProvider.GetService(typeof(ISender));
            builder.Autoconnect(this);
        }
        private void CargarReporte()
        {
            Task.Run(async () =>
            {
                var hoy = DateTime.Now;
                // Cargar reporte
                Gtk.Application.Invoke((sender, args) =>
                {
                    // Mostar reporte
                });
            });
        }
    }
}