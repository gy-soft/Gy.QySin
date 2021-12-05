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
        public decimal Precio { get; set; }
        // Mililitros
        public int Contenido { get; set; }
        public bool Rellenable { get; set; }
    }
}