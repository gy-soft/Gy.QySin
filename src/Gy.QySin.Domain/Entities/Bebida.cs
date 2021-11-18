using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Bebida : Ordenable
    {
        public Bebida(string nombre, decimal precio, int contenido, bool rellenable)
            : base(nombre, precio)
            {
            Contenido = contenido;
            Rellenable = rellenable;
        }
        // Mililitros
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
        public override OrdenableCategorias Categoria { get => OrdenableCategorias.Bebidas; }
    }
}