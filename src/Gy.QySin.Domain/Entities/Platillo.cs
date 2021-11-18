using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Platillo : Ordenable
    {
        public Platillo(string nombre, decimal precio, string descripción, bool vegetariano)
            : base(nombre, precio)
            {
            Descripción = descripción;
            Vegetariano = vegetariano;
            Categoria = OrdenableCategorias.Platillos;
        }
        public string Descripción { get; set; }
        public bool Vegetariano { get; set; }
    }
}