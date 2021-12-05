using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Platillo : Ordenable
    {
        public Platillo(string nombre, string descripción, bool vegetariano)
            : base(nombre)
            {
            Descripción = descripción;
            Vegetariano = vegetariano;
        }
        public decimal Precio { get; set; }
        public string Descripción { get; set; }
        public bool Vegetariano { get; set; }
    }
}