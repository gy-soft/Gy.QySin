using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gtk;
using Gy.QySin.Domain.Enums;
using Gy.QySin.GtkSharp.Models;
using Gy.QySin.GtkSharp.ValueObjects;
using MediatR;
using UI = Gtk.Builder.ObjectAttribute;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class CatálogosVM : Gtk.Box
    {
        [UI] private Button _btn_bebidas = null;
        [UI] private Button _btn_platillos = null;
        [UI] private Button _btn_precios = null;
        [UI] private Entry _text_nombre = null;
        [UI] private TreeView _tree_catalogos = null;
        private ISender mediator = null;
        private ReadOnlyDictionary<string, Ordenable> ordenables = null;
        public CatálogosVM(IServiceProvider serviceProvider) : this(serviceProvider, new Builder("Catálogos.glade"))
        {
            _btn_bebidas.Clicked += (sender, args) =>
            {
                CargarBebidas();
            };
            _btn_platillos.Clicked += (sender, args) =>
            {
                CargarPlatillos();
            };
            _btn_precios.Clicked += (sender, args) =>
            {
                CargarPrecios();
            };
            _text_nombre.Changed += BúsquedaNombre_Changed;
            CargarBebidas();
        }
        private CatálogosVM(IServiceProvider serviceProvider, Builder builder) : base(builder.GetRawObject("BoxCatálogos"))
        {
            builder.Autoconnect(this);
            mediator = (ISender)serviceProvider.GetService(typeof(ISender));
        }
        private void CargarBebidas()
        {
            ConfiguradorDeCatálogos.ConfigurarTreeBebidas(_tree_catalogos, FiltrarTreeCatálogoFunc);
            Task.Run(async () =>
            {
                var bebidas = (await mediator.Send(
                    new Application.Ordenables.Consultas.Listar.ListarCon { Categoria = OrdenableCategorias.Bebidas }
                )).Bebidas;
                Gtk.Application.Invoke((sender, args) =>
                {
                    ((CatáloBebidasModel)_tree_catalogos.Model).AgregarBebidas(bebidas);
                });
            });
        }
        private void CargarPlatillos()
        {
            ConfiguradorDeCatálogos.ConfigurarTreePlatillos(_tree_catalogos, FiltrarTreeCatálogoFunc);
            Task.Run(async () =>
            {
                var platillos = (await mediator.Send(
                    new Application.Ordenables.Consultas.Listar.ListarCon { Categoria = OrdenableCategorias.Platillos }
                )).Platillos;
                Gtk.Application.Invoke((sender, args) =>
                {
                    ((CatálogoPlatillosModel)_tree_catalogos.Model).AgregarPlatillos(platillos);
                });
            });
        }
        private void CargarPrecios()
        {
            ConfiguradorDeCatálogos.ConfigurarTreePrecios(_tree_catalogos, FiltrarTreeCatálogoFunc);
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
            var model = (TreeModelFilter)_tree_catalogos.Model;
            model.Refilter();
        }
        private bool FiltrarTreeCatálogoFunc(ITreeModel model, TreeIter iter)
        {
            string búsqueda = _text_nombre.Text;
            string nombre;
            if (string.IsNullOrEmpty(búsqueda) || búsqueda.Length < 3)
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