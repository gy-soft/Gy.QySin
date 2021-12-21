using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Gy.QySin.Domain.Enums;
using Gy.QySin.GtkSharp.Interfaces;
using Gy.QySin.GtkSharp.ValueObjects;
using MediatR;

namespace Gy.QySin.GtkSharp.Services
{
    class CatálogosService : ICatálogosService
    {
        public CatálogosService(ISender mediator)
        {
            this.mediator = mediator;
        }
        public Task<ReadOnlyCollection<IdNombre>> CargarCategoriasAsync()
        {
            return Task.FromResult(
                new ReadOnlyCollection<IdNombre>(categoriaOpciones)
            );
        }

        public async Task<ReadOnlyDictionary<string, Ordenable>> CargarOrdenablesDictAsync()
        {
            var response = await mediator.Send(
                new Application.Ordenables.Consultas.Listar.ListarCon()
            );
            var dict = new Dictionary<string, Ordenable>(
                response.Bebidas.Count + response.Platillos.Count
            );
            foreach(var b in response.Bebidas)
            {
                dict.Add(b.Clave, new Ordenable(
                    (int)OrdenableCategorias.Bebidas,
                    b.Clave,
                    b.Nombre
                ));
            }
            foreach (var p in response.Platillos)
            {
                dict.Add(p.Clave, new Ordenable(
                    (int)OrdenableCategorias.Platillos,
                    p.Clave,
                    p.Nombre
                ));
            }
            return new ReadOnlyDictionary<string, Ordenable>(dict);
        }
        
        static private List<IdNombre> categoriaOpciones = new List<IdNombre>
        {
            new IdNombre((int)OrdenableCategorias.Platillos, "Platillos"),
            new IdNombre((int)OrdenableCategorias.Bebidas, "Bebidas")
        };
        private readonly ISender mediator;
    }
}