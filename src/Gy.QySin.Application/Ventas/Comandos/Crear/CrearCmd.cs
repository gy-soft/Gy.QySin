using System.Linq;
using System.Collections.Generic;
using MediatR;

namespace Gy.QySin.Application.Ventas.Comandos.Crear
{
    public class CrearCmd : IRequest
    {
        public string Anotación { get; set; }
        public List<OrdenDto> Bebidas { get; set; }
        public List<OrdenDto> Platillos { get; set; }
        public int[] Fecha { get; set; }
    }
}