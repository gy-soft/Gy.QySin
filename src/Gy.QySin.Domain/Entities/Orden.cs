using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Orden : IEntity
    {
        [Key]
        public int NúmeroOrden { get; set; }
        public string Nota { get; set; }
        public Ordenable Ordenable { get; set; }

        public object Id => NúmeroOrden;
    }
}