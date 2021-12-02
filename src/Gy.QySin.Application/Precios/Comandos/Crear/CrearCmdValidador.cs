using FluentValidation;

namespace Gy.QySin.Application.Precios.Comandos.Crear
{
    public class CrearCmdValidador : AbstractValidator<CrearCmd>
    {
        public CrearCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.Precio)
                .GreaterThan(0m);
            RuleFor(cmd => cmd.FechaInicio)
                .NotEmpty()
                .GreaterThan(System.DateTime.Today);
            RuleFor(cmd => cmd.FechaFin)
                .GreaterThan(cmd => cmd.FechaInicio)
                .When(cmd => cmd.FechaFin is not null);
        }
    }
}