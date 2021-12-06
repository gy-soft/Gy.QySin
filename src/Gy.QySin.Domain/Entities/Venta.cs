using System;
using System.Collections.Generic;
using Gy.QySin.Domain.ValueObjects;

namespace Gy.QySin.Domain.Entities
{
    public class Venta
    {
        public Venta(string anotación)
        {
            Anotación = anotación;
            FechaHora = DateTime.Now;
        }
        public DateTime FechaHora { get; set; }
        public string Anotación { get; set; }
        public decimal GranTotal { get; set; }
        public IEnumerable<Orden> Ordenes { get => ordenesDict.Values; }
        public void AgregarOrdenes(IEnumerable<Orden> ordenes)
        {
            foreach (var orden in ordenes)
            {
                if (ordenesDict.ContainsKey(orden.Clave))
                {
                    ordenesDict[orden.Clave].AgregarCantidad(orden.Cantidad);
                }
                else
                {
                    ordenesDict.Add(orden.Clave, orden);
                }
            }
        }
        private Dictionary<string, Orden> ordenesDict = new Dictionary<string, Orden>();
    }
}