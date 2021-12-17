using System;
using Microsoft.Extensions.Hosting;
using Gy.QySin.Persistence.Sql;
using Gy.QySin.Persistence.Document;
using Gy.QySin.Application;
using Microsoft.Extensions.DependencyInjection;
using Gy.QySin.GtkSharp.Services;
using Gy.QySin.GtkSharp.Interfaces;
// Hay un conflicto entre la classe Gtk.Application
// y el namespace Gy.QySin.Application
// using Gtk;

namespace Gy.QySin.GtkSharp
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((ctx, services) =>
                {
                    services.AddApplication();
                    services.UsePostgres(ctx.Configuration);
                    services.UseCouchDb(ctx.Configuration);
                    services.AddTransient<ICatálogosService, CatálogosService>();
                })
                .Build();
            Gtk.Application.Init();

            var app = new Gtk.Application("Gy.QySin.GtkSharp", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow(host.Services);
            app.AddWindow(win);

            win.Show();
            Gtk.Application.Run();
        }
    }
}
