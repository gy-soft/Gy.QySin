using System;
using Gtk;
using Gy.QySin.GtkSharp.Models;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class AgregarOrdenVM
    {
        private readonly ComboBoxText comboCategoria;
        private readonly ComboBoxText comboOrdenable;
        private readonly SpinButton spinCantidad;
        private readonly Button btnAgregarOrden;

        public AgregarOrdenVM(
            ComboBoxText comboCategoria,
            ComboBoxText comboOrdenable,
            SpinButton spinCantidad,
            Button btnAgregarOrden
        ) {
            this.comboCategoria = comboCategoria;
            this.comboOrdenable = comboOrdenable;
            this.spinCantidad = spinCantidad;
            this.btnAgregarOrden = btnAgregarOrden;

            this.btnAgregarOrden.Sensitive = false;
            ModelBinder.BindComboBoxTextModel(comboCategoria, new CategoriaModel());
            this.comboCategoria.Changed += ComboCategoria_Changed;
            this.comboOrdenable.Changed += ComboOrdenable_Changed;
            this.spinCantidad.ValueChanged += SpinCantidad_Changed;
            cantidad = this.spinCantidad.ValueAsInt;
            this.btnAgregarOrden.Clicked += BtnAgregarOrden_Clicked;
        }
        private int categoria;
        private string clave;
        private string nombre;
        private int cantidad;
        public event EventHandler OrdenAgregada;

        private void ComboCategoria_Changed(object sender, EventArgs a)
        {
            ComboBoxText combo = (ComboBoxText)sender;
            if (int.TryParse(combo.ActiveId, out int cat))
            {
                categoria = cat;
            }
            switch (combo.ActiveId)
            {
                case "0":
                    ModelBinder.BindComboBoxTextModel(comboOrdenable, new PlatillosModel());
                    break;
                case "1":
                    ModelBinder.BindComboBoxTextModel(comboOrdenable, new BebidasModel());
                    break;
                default:
                    comboOrdenable.RemoveAll();
                    break;
            }
        }
        private void ComboOrdenable_Changed(object sender, EventArgs a)
        {
            ComboBoxText combo = (ComboBoxText)sender;
            clave = combo.ActiveId;
            nombre = combo.ActiveText;
            ValidarForma();
        }
        private void SpinCantidad_Changed(object sender, EventArgs a)
        {
            SpinButton spin = (SpinButton)sender;
            cantidad = spin.ValueAsInt;
            ValidarForma();
        }
        private void BtnAgregarOrden_Clicked(object sender, EventArgs a)
        {
            var valor = GetValue();
            comboCategoria.Active = -1;
            spinCantidad.Value = 1d;
            cantidad = 1;
            ValidarForma();
            OrdenAgregada(valor, EventArgs.Empty);
        }
        private void ValidarForma()
        {
            if (!string.IsNullOrEmpty(clave)
            && cantidad > 0)
            {
                btnAgregarOrden.Sensitive = true;
            }
        }
        private OrdenVal GetValue() => new OrdenVal(categoria, cantidad, clave, nombre);
    }
}