using System;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class PrecioOrdenableUi : PrecioOrdenable
    {
        public PrecioOrdenableUi(Guid clave, DateTime fechaInicio) : base(clave, fechaInicio)
        {
        }

        public string Nombre { get; set; }
        public OrdenableCategorias Categoria { get; set; }
    }
}