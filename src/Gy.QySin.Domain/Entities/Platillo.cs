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
        }
        public string Descripción { get; set; }
        public bool Vegetariano { get; set; }
        public override OrdenableCategorias Categoria { get => OrdenableCategorias.Platillos; }
    }
}