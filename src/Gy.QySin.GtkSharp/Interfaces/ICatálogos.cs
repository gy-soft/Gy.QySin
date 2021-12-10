using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Interfaces
{
    interface ICatálogos
    {
        Task<ReadOnlyCollection<IdNombre>> CargarCategorias();
        Task<ReadOnlyCollection<Ordenable>> CargarOrdenables();
    }
}