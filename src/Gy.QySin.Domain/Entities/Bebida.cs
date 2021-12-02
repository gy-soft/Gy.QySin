using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Bebida : Ordenable
    {
        public Bebida(string nombre, int contenido, bool rellenable)
            : base(nombre)
            {
            Contenido = contenido;
            Rellenable = rellenable;
        }
        // Mililitros
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
    }
}