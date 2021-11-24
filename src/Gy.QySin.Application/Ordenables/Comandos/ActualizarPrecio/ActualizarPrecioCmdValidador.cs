using FluentValidation;

namespace Gy.QySin.Application.Ordenables.Comandos.ActualziarPrecio
{
    public class ActualizarPrecioCmdValidador : AbstractValidator<ActualizarPrecioCmd>
    {
        public ActualizarPrecioCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<ActualizarPrecioCmd, decimal>(0m);
        }
    }
}