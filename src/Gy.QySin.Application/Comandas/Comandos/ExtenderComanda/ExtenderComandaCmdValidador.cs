using FluentValidation;

namespace Gy.QySin.Application.Comandas.Comandos.ExtenderComanda
{
    public class ExtenderComandaCmdValidador : AbstractValidator<ExtenderComandaCmd>
    {
        public ExtenderComandaCmdValidador()
        {
            RuleFor(cmd => cmd.NumeroComanda)
                .GreaterThan<ExtenderComandaCmd, int>(0);
            RuleFor(cmd => cmd.Ordenes)
                .NotEmpty();
        }
    }
}