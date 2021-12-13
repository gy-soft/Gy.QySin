using System.Text.Json.Serialization;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class VentaDetalle
    {
        public VentaDetalle(OrdenableCategorias categoria, string clave, string nombre, decimal precioUnitario, int cantidad)
        {
            Categoria = categoria;
            Clave = clave;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }
        public void AgregarCantidad(int agregando)
        {
            Cantidad += agregando;
        }
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public string IdVenta { get; set; }
        public int[] Ts { get; set; }
        public OrdenableCategorias Categoria { get; set; }
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