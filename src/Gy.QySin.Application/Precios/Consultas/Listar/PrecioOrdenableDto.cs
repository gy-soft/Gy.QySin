using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Application.Precios.Consultas.Listar
{
    public class PrecioOrdenableDto
    {
        public string Clave { get; set; }
        public decimal Precio { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime? FechaFin { get; set; }
        public string Nombre { get; set; }
        public OrdenableCategorias Categoria { get; set; }
    }
}