using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Bebida : Ordenable
    {
        // Mililitros
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
        public override OrdenableCategorias Categoria { get => OrdenableCategorias.Bebidas; }
    }
}