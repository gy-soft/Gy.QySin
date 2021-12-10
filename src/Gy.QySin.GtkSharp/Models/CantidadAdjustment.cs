using GLib;
using Gtk;

namespace Gy.QySin.GtkSharp.Models
{
    class CantidadAdjustment : Adjustment
    {
        public CantidadAdjustment() : base(1, 1, 99, 1, 1, 1)
        {
        }
        [Property("clave")]
        public string Clave { get; set; }
    }
}