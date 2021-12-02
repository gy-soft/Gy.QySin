using System;
using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class PrecioOrdenableUi
    {
        [Key]
        public Guid Clave { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Nombre { get; set; }
        public OrdenableCategorias Categoria { get; set; }
    }
}