using System.ComponentModel.DataAnnotations;

namespace Gy.QySin.Domain.Entities
{
    public class Orden
    {
        [Key]
        public int NoOrden { get; set; }
        public string NotaMesero { get; set; }
        public string NotaCocina { get; set; }
        public BaseOrdenable Ordenable { get; set; }
    }
}