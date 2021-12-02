using System;

namespace Gy.QySin.Domain.Entities
{
    public class PrecioOrdenable
    {
        public PrecioOrdenable(Guid clave, DateTime fechaInicio)
        {
            Clave = clave;
            FechaInicio = fechaInicio;
        }
        public Guid Clave { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}