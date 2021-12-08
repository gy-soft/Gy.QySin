using System;
using Gtk;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.GtkSharp.Models;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp
{
    class MainWindow : Window
    {
        [UI] private Button _btn_registrar_venta = null;
        [UI] private ComboBoxText _combo_categoria = null;
        [UI] private ComboBoxText _combo_ordenable = null;

        private readonly IServiceProvider serviceProvider;

        public MainWindow(IServiceProvider serviceProvider) : this(new Builder("MainWindow.glade"))
        {
            this.serviceProvider = serviceProvider;
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _btn_registrar_venta.Clicked += BtnRegistrar_Clicked;
            ModelBinder.BindComboBoxTextModel(_combo_categoria, new CategoriaModel());
            _combo_categoria.Changed += ComboCategoria_Changed;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
        }

        private void ComboCategoria_Changed(object sender, EventArgs a)
        {
            ComboBoxText combo = (ComboBoxText)sender;
            switch (combo.ActiveId)
            {
                case "0":
                    ModelBinder.BindComboBoxTextModel(_combo_ordenable, new PlatillosModel());
                    break;
                case "1":
                    ModelBinder.BindComboBoxTextModel(_combo_ordenable, new BebidasModel());
                    break;
                default:
                    _combo_ordenable.RemoveAll();
                    break;
            }
        }
        private void BtnRegistrar_Clicked(object sender, EventArgs a)
        {
            //
        }
    }
}
