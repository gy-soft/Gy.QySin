using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Ordenable
    {
        public Ordenable(string nombre) {
            Nombre = nombre;
        }
        [Key]
        public System.Guid Clave { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public OrdenableCategorias Categoria {get;set;}
    }
}