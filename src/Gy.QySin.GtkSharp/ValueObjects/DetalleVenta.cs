using Gy.QySin.Domain.Enums;

namespace Gy.QySin.GtkSharp.ValueObjects
{
    class DetalleVenta
    {
        public DetalleVenta(int categoria, int cantidad, string clave, string nombre)
        {
            Categoria = (OrdenableCategorias)categoria;
            Cantidad = cantidad;
            Clave = clave;
            Nombre = nombre;
        }
        public OrdenableCategorias Categoria { get; set; }
        public int Cantidad { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}