using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gtk;
using Gy.QySin.GtkSharp.Interfaces;
using Gy.QySin.GtkSharp.Models;
using Gy.QySin.GtkSharp.ValueObjects;
using MediatR;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class ReportesVM : Gtk.Box
    {
        [UI] private Button _btn_anterior = null;
        [UI] private Button _btn_siguiente = null;
        [UI] private Label _text_fecha = null;
        [UI] private TreeView _list_reporte = null;
        private readonly ISender mediator;
        private readonly ICatálogosService catálogosService;
        private System.Globalization.Calendar Calendario = System.Globalization.CultureInfo.InvariantCulture.Calendar;
        private DateTime fechaReporte = DateTime.Now;
        private ReadOnlyDictionary<string, Ordenable> ordenables = null;

        public ReportesVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            _text_fecha.Text = fechaReporte.ToShortDateString();
            ConfiguradorDeWidgets.ConfigurarTreeReporteVentas(_list_reporte);
            _btn_anterior.Clicked += BtnAnterior_Clicked;
            _btn_siguiente.Clicked += BtnSiguiente_Clicked;
            CargarReporte();
        }
        private ReportesVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxReportes"))
        {
            this.mediator = (ISender)serviceProvider.GetService(typeof(ISender));
            this.catálogosService = (ICatálogosService)serviceProvider.GetService(typeof(ICatálogosService));
            builder.Autoconnect(this);
        }
        private void BtnAnterior_Clicked(object sender, EventArgs args)
        {
            fechaReporte = Calendario.AddDays(fechaReporte, -1);
            _text_fecha.Text = fechaReporte.ToShortDateString();
            CargarReporte();
        }
        private void BtnSiguiente_Clicked(object sender, EventArgs args)
        {
            fechaReporte = Calendario.AddDays(fechaReporte, 1);
            _text_fecha.Text = fechaReporte.ToShortDateString();
            CargarReporte();
        }
        private void CargarReporte()
        {
            Task.Run(async () =>
            {
                var fechaParams = new Application.Ventas.Consultas.ReporteDiarioCon
                {
                    Año = fechaReporte.Year,
                    Mes = fechaReporte.Month,
                    Día = fechaReporte.Day
                };
                if (ordenables is null)
                    ordenables = await catálogosService.CargarOrdenablesDictAsync();
                var reporte = await mediator.Send(fechaParams);
                Gtk.Application.Invoke((sender, args) =>
                {
                    _list_reporte.Model = new ReporteVentasModel(ordenables, reporte);
                });
            });
        }
    }
}