using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Interfaces
{
    interface ICatálogosService
    {
        Task<ReadOnlyCollection<IdNombre>> CargarCategoriasAsync();
        Task<ReadOnlyDictionary<string, Ordenable>> CargarOrdenablesDictAsync();
    }
}