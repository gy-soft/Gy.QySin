using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class BaseOrdenable : IOrdenable
    {
        [Key]
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public virtual OrdenableCategorias Categoria { get; set; }
    }
}