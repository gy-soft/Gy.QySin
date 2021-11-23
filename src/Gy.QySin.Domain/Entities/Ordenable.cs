using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Ordenable : IEntity
    {
        public Ordenable(string nombre, decimal precio) {
            Nombre = nombre;
            Precio = precio;
        }
        [Key]
        public System.Guid Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public virtual OrdenableCategorias Categoria { get; set; }

        [NotMapped]
        public object Id => Clave;
    }
}