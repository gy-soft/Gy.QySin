using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gy.QySin.Domain.Enums;
using Gy.QySin.GtkSharp.Interfaces;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Services
{
    class MockCatálogosService : ICatálogosService
    {
        public Task<ReadOnlyCollection<IdNombre>> CargarCategoriasAsync()
        {
            return Task.FromResult(
                new ReadOnlyCollection<IdNombre>(categoriaOpciones)
            );
        }

        public Task<ReadOnlyDictionary<string, Ordenable>> CargarOrdenablesDictAsync()
        {
            return Task.FromResult(
                new ReadOnlyDictionary<string, Ordenable>(ordenableOpciones)
            );
        }
        static private List<IdNombre> categoriaOpciones = new List<IdNombre>
        {
            new IdNombre((int)OrdenableCategorias.Platillos, "Platillos"),
            new IdNombre((int)OrdenableCategorias.Bebidas, "Bebidas")
        };
        static private Dictionary<string, Ordenable> ordenableOpciones = new Dictionary<string, Ordenable>
        {
            { "a85f763e-4a74-11ec-957d-af9a5847120e", new Ordenable((int)OrdenableCategorias.Platillos, "a85f763e-4a74-11ec-957d-af9a5847120e", "Milanesa de res") },
            { "23c2a080-4a75-11ec-be6c-9f2f00b944c5", new Ordenable((int)OrdenableCategorias.Platillos, "23c2a080-4a75-11ec-be6c-9f2f00b944c5", "Milanesa de pollo") },
            { "53c87192-4a75-11ec-a2eb-df1c165275d1", new Ordenable((int)OrdenableCategorias.Platillos, "53c87192-4a75-11ec-a2eb-df1c165275d1", "Chile relleno de queso") },
            { "cd5e9346-4e04-11ec-86a5-e7dac512f012", new Ordenable((int)OrdenableCategorias.Platillos, "cd5e9346-4e04-11ec-86a5-e7dac512f012", "Chile relleno de pollo") },
            { "5d299146-52de-11ec-905c-0bd9398be3e3", new Ordenable((int)OrdenableCategorias.Platillos, "5d299146-52de-11ec-905c-0bd9398be3e3", "Bistek ranchero") },
            { "cc6f3c2c-52de-11ec-b9d9-f348fbf8b319", new Ordenable((int)OrdenableCategorias.Platillos, "cc6f3c2c-52de-11ec-b9d9-f348fbf8b319", "Enchiladas de pollo") },
            { "d8b07a6e-52de-11ec-ba69-5f50901cce02", new Ordenable((int)OrdenableCategorias.Platillos, "d8b07a6e-52de-11ec-ba69-5f50901cce02", "Enchiladas de queso") },
            { "6c6287bf-055c-4d26-a533-c7d78ef866f3", new Ordenable((int)OrdenableCategorias.Bebidas, "6c6287bf-055c-4d26-a533-c7d78ef866f3", "Limonada") },
            { "0e94c95c-4e05-11ec-9480-67932bb6f9a8", new Ordenable((int)OrdenableCategorias.Bebidas, "0e94c95c-4e05-11ec-9480-67932bb6f9a8", "Agua de jamaica") },
            { "3ec21770-4e04-11ec-95c6-97281991a166", new Ordenable((int)OrdenableCategorias.Bebidas, "3ec21770-4e04-11ec-95c6-97281991a166", "Café americano") },
            { "3564501e-52d0-11ec-9279-df8a768bc59d", new Ordenable((int)OrdenableCategorias.Bebidas, "3564501e-52d0-11ec-9279-df8a768bc59d", "Coca-cola") },
            { "5aa44186-52d0-11ec-beea-5b157d3e29b9", new Ordenable((int)OrdenableCategorias.Bebidas, "5aa44186-52d0-11ec-beea-5b157d3e29b9", "Coca-cola light") },
            { "8360cdce-52d0-11ec-a593-c3c3fdde367e", new Ordenable((int)OrdenableCategorias.Bebidas, "8360cdce-52d0-11ec-a593-c3c3fdde367e", "Sprite") },
            { "d26aa9d2-52dd-11ec-b829-135430a773b0", new Ordenable((int)OrdenableCategorias.Bebidas, "d26aa9d2-52dd-11ec-b829-135430a773b0", "Fanta") }
        };
    }
}