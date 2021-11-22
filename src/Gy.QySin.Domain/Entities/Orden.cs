using System.ComponentModel.DataAnnotations;

namespace Gy.QySin.Domain.Entities
{
    public class Orden
    {
        [Key]
        public int NoOrden { get; set; }
        public string Nota { get; set; }
        public Ordenable Ordenable { get; set; }
    }
}