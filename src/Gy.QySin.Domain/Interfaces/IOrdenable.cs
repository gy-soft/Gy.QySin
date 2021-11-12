namespace Gy.QySin.Domain.Interfaces
{
    public interface IOrdenable
    {
        string Clave { get; }
        string Nombre { get; }
        decimal Precio { get; }
    }
}