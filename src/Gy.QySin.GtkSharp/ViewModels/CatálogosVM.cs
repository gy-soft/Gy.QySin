using System;
using Gtk;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class CatálogosVM : Gtk.Box
    {
        public CatálogosVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("MainWindow.glade"))
        {
            
        }
        private CatálogosVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxCatálogos"))
        {
            builder.Autoconnect(this);
        }
    }
}