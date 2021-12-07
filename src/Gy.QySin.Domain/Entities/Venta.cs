using System;
using System.Collections.Generic;
using System.Linq;

namespace Gy.QySin.Domain.Entities
{
    public class Venta
    {
        public Venta(string anotación)
        {
            Anotación = anotación;
            FechaHora = DateTime.Now;
        }
        public string Id { private get; set; }
        public DateTime FechaHora { get; private set; }
        public string Anotación { get; private set; }
        public decimal GranTotal { get; private set; }
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
            GranTotal = ordenesDict.Values.Sum(o => o.Total);
        }
        public IEnumerable<Orden> ExtraerOrdenes()
        {
            if (Id is null)
                throw new InvalidOperationException("El 'Id' de la Venta no puede ser nulo.");
            return ordenesDict.Values
                .Select(o => {
                    o.IdVenta = Id;
                    return o;
                });
        }
        private Dictionary<string, Orden> ordenesDict = new Dictionary<string, Orden>();
    }
}