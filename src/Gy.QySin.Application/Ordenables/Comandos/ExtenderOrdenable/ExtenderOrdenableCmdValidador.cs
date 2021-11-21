using FluentValidation;

namespace Gy.QySin.Application.Ordenables.Comandos.ExtenderOrdenable
{
    public class ExtenderOrdenableCmdValidador : AbstractValidator<ExtenderOrdenableCmd>
    {
        public ExtenderOrdenableCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<ExtenderOrdenableCmd, decimal>(0m);
        }
    }
}