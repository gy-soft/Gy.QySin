using FluentValidation;

namespace Gy.QySin.Application.Precios.Comandos.CambiarFechaFin
{
    public class CambiarFechaFinCmdValidador : AbstractValidator<CambiarFechaFinCmd>
    {
        public CambiarFechaFinCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.FechaInicio)
                .NotEmpty();
            RuleFor(cmd => cmd.FechaFin)
                .GreaterThan(System.DateTime.Today)
                .GreaterThan(cmd => cmd.FechaInicio);
        }
    }
}