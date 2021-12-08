using System;
using Gtk;
using Gy.QySin.Application.Common.Interfaces;
using Gy.QySin.Domain.Entities;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;

        private readonly IServiceProvider serviceProvider;

        public MainWindow(IServiceProvider serviceProvider) : this(new Builder("MainWindow.glade"))
        {
            this.serviceProvider = serviceProvider;
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Gtk.Application.Quit();
        }

        private async void Button1_Clicked(object sender, EventArgs a)
        {
            try
            {
                 IApplicationRepositories repos = (IApplicationRepositories)serviceProvider
                    .GetService(typeof(IApplicationRepositories));
                string id = "d26aa9d2-52dd-11ec-b829-135430a773b0";
                var bebida = await repos.Bebidas.GetAsync(
                    new object[] { Guid.Parse(id) }
                );
                Console.WriteLine("Nombre bebida: {0}", bebida.Nombre);
            }
            catch (System.Exception e)
            {
                
                throw;
            }
            
        }
    }
}
