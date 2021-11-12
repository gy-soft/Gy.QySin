using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public abstract class BaseOrdenable : IOrdenable
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public abstract OrdenableCategorias Categoria { get; }
    }
}