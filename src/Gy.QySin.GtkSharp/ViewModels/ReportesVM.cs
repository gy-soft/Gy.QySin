using System;
using Gtk;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class ReportesVM : Gtk.Box
    {
        public ReportesVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            
        }
        private ReportesVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxCatálogos"))
        {
            builder.Autoconnect(this);
        }
    }
}