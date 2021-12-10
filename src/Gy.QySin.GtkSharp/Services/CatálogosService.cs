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

        public async Task<ReadOnlyCollection<Ordenable>> CargarOrdenablesAsync()
        {
            var response = await mediator.Send(
                new Application.Ordenables.Consultas.Listar.ListarCon()
            );
            List<Ordenable> ordenables = new List<Ordenable>(
                response.Bebidas.Count + response.Platillos.Count
            );
            ordenables.AddRange(
                response.Bebidas.Select(b => new Ordenable
                (
                    (int)OrdenableCategorias.Bebidas,
                    b.Clave,
                    b.Nombre
                ))
            );
            ordenables.AddRange(
                response.Platillos.Select(p => new Ordenable
                (
                    (int)OrdenableCategorias.Platillos,
                    p.Clave,
                    p.Nombre
                ))
            );
            return new ReadOnlyCollection<Ordenable>(ordenables);
        }
        static private List<IdNombre> categoriaOpciones = new List<IdNombre>
        {
            new IdNombre((int)OrdenableCategorias.Platillos, "Platillos"),
            new IdNombre((int)OrdenableCategorias.Bebidas, "Bebidas")
        };
        private readonly ISender mediator;
    }
}