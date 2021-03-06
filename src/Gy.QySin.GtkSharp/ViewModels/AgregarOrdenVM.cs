using System;
using System.Threading;
using System.Threading.Tasks;
using Gtk;
using Gy.QySin.GtkSharp.Interfaces;
using Gy.QySin.GtkSharp.Models;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class AgregarOrdenVM
    {
        private readonly ICatálogosService catálogosService;
        private readonly ComboBoxText comboCategoria;
        private readonly ComboBoxText comboOrdenable;
        private readonly SpinButton spinCantidad;
        private readonly Button btnAgregarOrden;

        public AgregarOrdenVM(
            ICatálogosService catálogosService,
            ComboBoxText comboCategoria,
            ComboBoxText comboOrdenable,
            SpinButton spinCantidad,
            Button btnAgregarOrden
        ) {
            this.catálogosService = catálogosService;
            this.comboCategoria = comboCategoria;
            this.comboOrdenable = comboOrdenable;
            this.spinCantidad = spinCantidad;
            this.btnAgregarOrden = btnAgregarOrden;

            ConfigurarCombos();
            this.btnAgregarOrden.Sensitive = false;
            this.comboCategoria.Changed += ComboCategoria_Changed;
            this.comboOrdenable.Changed += ComboOrdenable_Changed;

            this.spinCantidad.ValueChanged += SpinCantidad_Changed;
            this.btnAgregarOrden.Clicked += BtnAgregarOrden_Clicked;
        }
        public event EventHandler OrdenAgregada;
        private void ConfigurarCombos()
        {
            Task.Run(async () =>
            {
                var categoriasCat = await catálogosService.CargarCategoriasAsync();
                var model = new CategoriaModel(categoriasCat);
                Gtk.Application.Invoke((sender, args) =>
                {
                    ConfiguradorDeWidgets.ConfigurarComboCategorias(model, comboCategoria);
                });
            });

            Task.Run(async () =>
            {
                var ordenablesCat = await catálogosService.CargarOrdenablesAsync();
                var model = new OrdenablesModel(ordenablesCat);
                Gtk.Application.Invoke((sender, args) =>
                {
                    ConfiguradorDeWidgets.ConfigurarComboOrdenables(
                        model, comboOrdenable, FiltrarComboOrdenableFunc
                    );
                });
            });
        }
        private void ComboCategoria_Changed(object sender, EventArgs a)
        {
            comboOrdenable.Active = 0;
            var filter = (TreeModelFilter)comboOrdenable.Model;
            filter.Refilter();
            ValidarForma();
        }
        private void ComboOrdenable_Changed(object sender, EventArgs a)
        {
            ValidarForma();
        }
        private bool FiltrarComboOrdenableFunc(ITreeModel model, TreeIter iter)
        {
            string idOpción = (string)model.GetValue(iter, 1);
            int categoriaOpción = (int)model.GetValue(iter, 2);
            int categoriaActiva = Convert.ToInt32(comboCategoria.ActiveId);
            return idOpción == "-1" ||
                categoriaActiva == -1 ||
                categoriaActiva == categoriaOpción;
        }
        private void SpinCantidad_Changed(object sender, EventArgs a)
        {
            ValidarForma();
        }
        private void BtnAgregarOrden_Clicked(object sender, EventArgs a)
        {
            var valor = GetValue();
            comboCategoria.Active = 0;
            comboOrdenable.Active = 0;
            spinCantidad.Value = 1d;
            ValidarForma();
            OrdenAgregada(valor, EventArgs.Empty);
        }
        private void ValidarForma()
        {
            btnAgregarOrden.Sensitive = 
            (
                comboOrdenable.ActiveId != "-1"
                && spinCantidad.ValueAsInt > 0
            );
        }
        private VentaDetalle GetValue()
        {
            comboOrdenable.GetActiveIter(out TreeIter iter);
            return new VentaDetalle(
                (int)comboOrdenable.Model.GetValue(iter, 2),
                spinCantidad.ValueAsInt,
                comboOrdenable.ActiveId,
                (string)comboOrdenable.Model.GetValue(iter, 0));
        }
    }
}