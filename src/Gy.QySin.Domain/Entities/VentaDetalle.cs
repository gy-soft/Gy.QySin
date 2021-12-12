namespace Gy.QySin.Domain.Entities
{
    public class VentaDetalle
    {
        public VentaDetalle(string clave, string nombre, decimal precioUnitario, int cantidad)
        {
            Clave = clave;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }
        public void AgregarCantidad(int agregando)
        {
            Cantidad += agregando;
        }
        public string IdVenta { get; set; }
        public int[] Ts { get; set; }
        public string Clave { get; }
        public string Nombre { get; }
        public decimal PrecioUnitario { get; }
        public int Cantidad
        {
            get => cantidad;
            private set
            {
                cantidad = value;
                Total = cantidad * PrecioUnitario;
            }
        }
        public decimal Total { get; private set; }
        private int cantidad;
    }
}