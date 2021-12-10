namespace Gy.QySin.GtkSharp.ValueObjects
{
    class Ordenable
    {
        public Ordenable(int categoria, string clave, string nombre)
        {
            Categoria = categoria;
            Clave = clave;
            Nombre = nombre;
        }

        public int Categoria { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}