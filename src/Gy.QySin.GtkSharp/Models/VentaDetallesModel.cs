using System.Collections.Generic;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.Models
{
    class VentaDetallesModel : ListStore
    {
        public VentaDetallesModel() 
            : base(
                typeof(string),// Nombre
                typeof(int),// Cantidad
                typeof(string),// Clave
                typeof(int)// Categoria
            ) {}

        public void AgregarVentaDetalle(DetalleVenta detalleVenta)
        {
            AppendValues(new object[] { 
                detalleVenta.Nombre,
                detalleVenta.Cantidad,
                detalleVenta.Clave,
                (int)detalleVenta.Categoria
            });
        }
        public List<DetalleVenta> ExtraerVentaDetalles()
        {
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            TreeIter iter;
            if (GetIterFirst(out iter))
            {
                string nombre;
                int cantidad;
                string clave;
                int categoria;
                do
                {
                    nombre = (string)GetValue(iter, 0);
                    cantidad = (int)GetValue(iter, 1);
                    clave = (string)GetValue(iter, 2);
                    categoria = (int)GetValue(iter, 3);
                    detalleVentas.Add(new DetalleVenta(
                        categoria, cantidad, clave, nombre
                    ));
                } while (IterNext(ref iter));
            }
            return detalleVentas;
        }
    }
}