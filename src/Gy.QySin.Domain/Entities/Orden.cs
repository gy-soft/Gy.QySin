using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Orden
    {
        public string NotaMesero { get; set; }
        public string NotaCocina { get; set; }
        public IOrdenable Ordenable { get; set; }
    }
}