namespace Gy.QySin.Domain.ValueObjects
{
    public class ReporteVentasValorPuntual
    {
        public ReporteVentasValorPuntual(){}
        public ReporteVentasValorPuntual(ArrObjectKeyDecimalValue keyValue, Periodos periodo)
        {
            int índiceMagnitud = (int)periodo;
            Magnitud = (string)keyValue.Key[índiceMagnitud] == MONTO ?
                Magnitudes.Monto :
                Magnitudes.Unidades;
            bool esGrupo = keyValue.Key.Length == índiceMagnitud + 2;
            int índiceClave = índiceMagnitud + (esGrupo ? 1 : 2);
            Clave = (string)keyValue.Key[índiceClave];
            Valor = keyValue.Value;
        }
        public string Clave { get; set; }
        public Magnitudes Magnitud { get; set; }
        public decimal Valor { get; set; }
        public enum Magnitudes
        {
            Unidades,
            Monto
        }
        public enum Periodos
        {
            Diario = 3,
            Mensual = 2,
            Anual = 1
        }
        private const string MONTO = "monto";
        private const string UNIDADES = "unidades";
    }
}