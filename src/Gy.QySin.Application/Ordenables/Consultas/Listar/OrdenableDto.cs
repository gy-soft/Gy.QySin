using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Application.Ordenables.Consultas.Listar
{
    public class OrdenableDto
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public OrdenableCategorias Categoria {get;set;}
    }
}