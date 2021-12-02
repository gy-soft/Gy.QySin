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
                .GreaterThanOrEqualTo(System.DateTime.Today);
            RuleFor(cmd => cmd.FechaFin)
                .GreaterThan(cmd => cmd.FechaInicio)
                .When(cmd => cmd.FechaFin.HasValue)
                .WithMessage("'Fecha Fin' debe ser mayor que 'Fecha Inicio'.");
        }
    }
}