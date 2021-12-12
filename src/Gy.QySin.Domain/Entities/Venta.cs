using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Gy.QySin.Domain.Entities
{
    public class Venta
    {
        public Venta(string anotación, int[] ts)
        {
            Anotación = anotación;
            Ts = ts;
        }
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public int[] Ts { get; private set; }
        public string Anotación { get; private set; }
        public decimal GranTotal { get; private set; }
        public void AgregarOrdenes(IEnumerable<VentaDetalle> ordenes)
        {
            foreach (var orden in ordenes)
            {
                orden.Ts = Ts;
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
        public List<VentaDetalle> ExtraerDetalles()
        {
            if (Id is null)
                throw new InvalidOperationException("El 'Id' de la Venta no puede ser nulo.");
            return ordenesDict.Values
            .Select(o => {
                o.IdVenta = Id;
                return o;
            })
            .ToList();
        }

        private Dictionary<string, VentaDetalle> ordenesDict = new Dictionary<string, VentaDetalle>();
    }
}