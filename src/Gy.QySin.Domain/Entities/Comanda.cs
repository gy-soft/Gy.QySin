using System;
using System.Collections.Generic;
using System.Linq;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Comanda
    {
        public Comanda(int numeroOrden, string mesero)
        {
            NumeroOrden = numeroOrden;
            Mesero = mesero;
            Estado = ComandaEstados.Nueva;
            Ordenes = new List<Orden>();
        }
        public int NumeroOrden { get; }
        public int Mesa { get; set; }
        public string Mesero { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; }
        public ComandaEstados Estado { get; set; }
        
        public decimal CalcularTotal()
        {
            return Ordenes.Sum(o => o.Ordenable.Precio);
        }
    }
}