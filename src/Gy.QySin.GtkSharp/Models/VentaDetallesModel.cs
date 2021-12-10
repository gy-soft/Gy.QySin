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

        public void AgregarVentaDetalle(VentaDetalle ventaDetalle)
        {
            AppendValues(new object[] { 
                ventaDetalle.Nombre,
                ventaDetalle.Cantidad,
                ventaDetalle.Clave,
                (int)ventaDetalle.Categoria
            });
        }
        public List<VentaDetalle> ExtraerVentaDetalles()
        {
            List<VentaDetalle> ventaDetalle = new List<VentaDetalle>();
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
                    ventaDetalle.Add(new VentaDetalle(
                        categoria, cantidad, clave, nombre
                    ));
                } while (IterNext(ref iter));
            }
            return ventaDetalle;
        }
    }
}