using System;
using System.Collections.Generic;
using System.Linq;
using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Comanda : IEntity
    {
        public Comanda(string mesero, int mesa)
        {
            Mesero = System.Guid.Parse(mesero);
            Mesa = mesa;
            Estado = ComandaEstados.Nueva;
        }
        public int NúmeroComanda { get; set; }
        public int Mesa { get; set; }
        public System.Guid Mesero { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public List<Orden> Ordenes { get; set; }
        public ComandaEstados Estado { get; set; }

        public object Id => NúmeroComanda;

        public void AgregarOrdenes(IEnumerable<Orden> ordenes)
        {
            if (Ordenes is null)
                Ordenes = new List<Orden>();

            Ordenes.AddRange(ordenes);
        }
        public decimal CalcularTotal()
        {
            return Ordenes.Sum(o => o.Ordenable.Precio);
        }
    }
}