using System;
using Gy.QySin.Domain.Entities;

namespace Gy.QySin.Persistence
{
    public static class IdFactory
    {
        public static string NewId(Venta venta)
        {
            long delta = (long)DateTime.UtcNow.Subtract(
                new DateTime(
                    venta.Ts[0], venta.Ts[1], venta.Ts[2],
                    0, 0, 0, DateTimeKind.Utc)
            ).TotalMilliseconds;
            return $"{venta.Ts[0]}:{venta.Ts[1]}:{venta.Ts[2]}:{delta}";
        }
    }
}