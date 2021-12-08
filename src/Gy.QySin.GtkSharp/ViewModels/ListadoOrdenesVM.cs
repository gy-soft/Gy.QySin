using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class ListadoOrdenesVm
    {
        private readonly ListBox listOrdenes;
        private readonly Entry textNota;
        private readonly Button btnRegistrarVenta;
        private readonly List<OrdenVal> ordenes = new List<OrdenVal>();
        public event EventHandler RegistrarVenta;

        public ListadoOrdenesVm(ListBox listOrdenes, Entry textNota, Button btnRegistrarVenta)
        {
            this.listOrdenes = listOrdenes;
            this.textNota = textNota;
            this.btnRegistrarVenta = btnRegistrarVenta;
            this.btnRegistrarVenta.Sensitive = false;
            this.btnRegistrarVenta.Clicked += BtnRegistrarVenta_Clicked;
        }
        public void AgregarOrden(OrdenVal nuevaOrden)
        {
            string text = $"{nuevaOrden.Cantidad} - {nuevaOrden.Nombre}";
            var label = new Label(text);
            listOrdenes.Add(label);
            label.Show();
            ordenes.Add(nuevaOrden);
            btnRegistrarVenta.Sensitive = true;
        }
        private void BtnRegistrarVenta_Clicked(object sender, EventArgs a)
        {
            var comando = new Application.Ventas.Comandos.Crear.CrearCmd
            {
                Anotación = textNota.Text,
                Bebidas = ordenes
                    .Where(o => o.Categoria == Domain.Enums.OrdenableCategorias.Bebidas)
                    .Select(o => new Application.Ventas.Comandos.Crear.OrdenDto
                    {
                        Cantidad = o.Cantidad,
                        Clave = o.Clave
                    }).ToList(),
                Platillos = ordenes
                    .Where(o => o.Categoria == Domain.Enums.OrdenableCategorias.Platillos)
                    .Select(o => new Application.Ventas.Comandos.Crear.OrdenDto
                    {
                        Cantidad = o.Cantidad,
                        Clave = o.Clave
                    }).ToList()
            };
            LimpiarForma();
            RegistrarVenta(comando, EventArgs.Empty);
        }
        private void LimpiarForma()
        {
            ordenes.Clear();
            foreach (var item in listOrdenes.Children)
            {
                listOrdenes.Remove(item);
            }
            textNota.Text = string.Empty;
            btnRegistrarVenta.Sensitive = false;
        }
    }
}