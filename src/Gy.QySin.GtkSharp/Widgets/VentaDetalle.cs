using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
namespace Gy.QySin.GtkSharp.Widgets
{
    class VentaDetalle : Widget
    {
        [UI] private SpinButton _spin_cantidad = null;
        [UI] private Label _text_nombre = null;
        [UI] private Button _btn_eliminar = null;
        public VentaDetalle() : this(new Builder("VentaDetalle.glade"))
        {}
        private VentaDetalle(Builder builder) : base(builder.GetRawObject("VentaDetalle"))
        {

        }
    }
}