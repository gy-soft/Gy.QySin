using System;

namespace Gy.QySin.Domain.Entities
{
    public class Venta
    {
        public DateTime TimeStamp { get; set; }
        public long Clave { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}