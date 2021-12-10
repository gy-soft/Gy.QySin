using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;
using Gy.QySin.GtkSharp.Models;
using Gy.QySin.GtkSharp.ValueObjects;

namespace Gy.QySin.GtkSharp.ViewModels
{
    class RegistrarVentaVM
    {
        private readonly TreeView treeVentaDetalles;
        private readonly Entry textNota;
        private readonly Button btnRegistrarVenta;
        public event EventHandler RegistrarVenta;

        public RegistrarVentaVM(TreeView treeVentaDetalles, Entry textNota, Button btnRegistrarVenta)
        {
            this.treeVentaDetalles = treeVentaDetalles;
            this.treeVentaDetalles.Model = new VentaDetallesModel();
            ConfiguradorDeWidgets.ConfigurarTreeVentaDetalles(this.treeVentaDetalles);
            this.textNota = textNota;
            this.btnRegistrarVenta = btnRegistrarVenta;
            this.btnRegistrarVenta.Sensitive = false;
            this.btnRegistrarVenta.Clicked += BtnRegistrarVenta_Clicked;
        }
        public void AgregarOrden(VentaDetalle detalleVenta)
        {
            ((VentaDetallesModel)treeVentaDetalles.Model).AgregarVentaDetalle(detalleVenta);
            btnRegistrarVenta.Sensitive = true;
        }
        private void BtnRegistrarVenta_Clicked(object sender, EventArgs a)
        {
            List<VentaDetalle> detalleVentas = ((VentaDetallesModel)treeVentaDetalles.Model).ExtraerVentaDetalles();
            var comando = new Application.Ventas.Comandos.Crear.CrearCmd
            {
                Anotación = textNota.Text,
                Bebidas = detalleVentas
                    .Where(o => o.Categoria == Domain.Enums.OrdenableCategorias.Bebidas)
                    .Select(o => new Application.Ventas.Comandos.Crear.OrdenDto
                    {
                        Cantidad = o.Cantidad,
                        Clave = o.Clave
                    }).ToList(),
                Platillos = detalleVentas
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
            this.treeVentaDetalles.Model = new VentaDetallesModel();
            textNota.Text = string.Empty;
            btnRegistrarVenta.Sensitive = false;
        }
    }
}