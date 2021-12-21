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
    class CatálogosVM : Gtk.Box
    {
        [UI] private Entry _text_nombre = null;
        [UI] private TreeView _tree_catalogos = null;
        private ISender mediator = null;
        private ReadOnlyDictionary<string, Ordenable> ordenables = null;
        public CatálogosVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("Catálogos.glade"))
        {
            _text_nombre.Changed += BúsquedaNombre_Changed;
            CargarPrecios();
        }
        private CatálogosVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxCatálogos"))
        {
            builder.Autoconnect(this);
            mediator = (ISender)serviceProvider.GetService(typeof(ISender));
        }
        private void CargarPrecios()
        {
            ConfiguradorDeWidgets.ConfigurarTreePrecios(_tree_catalogos, FiltrarComboOrdenableFunc);
            Task.Run(async () => {
                var precios = await mediator.Send(new Application.Precios.Consultas.Listar.ListarCon());
                Gtk.Application.Invoke((sender, args) =>
                {
                    ((CatálogoPreciosModel)_tree_catalogos.Model).AgregarPrecios(precios);
                });
            });
        }
        private void BúsquedaNombre_Changed(object sender, EventArgs args)
        {
            var model = (CatálogoPreciosModel)_tree_catalogos.Model;
            model.Refilter();
        }
        private bool FiltrarComboOrdenableFunc(ITreeModel model, TreeIter iter)
        {
            string búsqueda = _text_nombre.Text;
            string nombre;
            if (string.IsNullOrEmpty(búsqueda))
            {
                return true;
            }
            else{
                nombre = (string)model.GetValue(iter, 0);
                return nombre.ToLower().Contains(búsqueda.ToLower());
            }
        }
    }
}