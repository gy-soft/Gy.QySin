namespace Gy.QySin.GtkSharp.ValueObjects
{
    class IdNombre
    {
        public IdNombre(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; }
        public string Nombre { get; }
    }
}