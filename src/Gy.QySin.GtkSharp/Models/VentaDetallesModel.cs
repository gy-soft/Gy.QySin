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
            bool hasAny = GetIterFirst(out TreeIter iter);
            bool iterUpdated = false;
            if (hasAny)
            ApplyToTree(hasAny, ref iter, () =>
            {
                if (ventaDetalle.Clave == clave)
                {
                    SetValue(iter, 1, cantidad + ventaDetalle.Cantidad);
                    iterUpdated = true;
                }
            });
            if(!hasAny || !iterUpdated)
            AppendValues(new object[] { 
                ventaDetalle.Nombre,
                ventaDetalle.Cantidad,
                ventaDetalle.Clave,
                (int)ventaDetalle.Categoria
            });
        }
        public List<VentaDetalle> ExtraerVentaDetalles()
        {
            bool hasAny = GetIterFirst(out TreeIter iter);
            List<VentaDetalle> ventaDetalles = new List<VentaDetalle>();
            ApplyToTree(hasAny, ref iter, () =>
            {
                ventaDetalles.Add(
                    new VentaDetalle(categoria, cantidad, clave, nombre)
                );
            });
            return ventaDetalles;
        }
        private void ApplyToTree(bool hasAny, ref TreeIter iter, System.Action action)
        {
            if (hasAny)
            {
                do
                {
                    nombre = (string)GetValue(iter, 0);
                    cantidad = (int)GetValue(iter, 1);
                    clave = (string)GetValue(iter, 2);
                    categoria = (int)GetValue(iter, 3);
                    action();
                } while (IterNext(ref iter));
            }
        }

        private string nombre;
        private int cantidad;
        private string clave;
        private int categoria;
    }
}