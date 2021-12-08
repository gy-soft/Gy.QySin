namespace Gy.QySin.GtkSharp.ValueObjects
{
    class OrdenDto
    {
        public OrdenDto(int cantidad, string clave, string nombre)
        {
            Cantidad = cantidad;
            Clave = clave;
            Nombre = nombre;
        }
        public int Cantidad { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}