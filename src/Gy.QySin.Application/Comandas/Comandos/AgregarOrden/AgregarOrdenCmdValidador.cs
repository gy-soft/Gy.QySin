using FluentValidation;

namespace Gy.QySin.Application.Comandas.Comandos.AgregarOrden
{
    public class AgregarOrdenCmdValidador : AbstractValidator<AgregarOrdenCmd>
    {
        public AgregarOrdenCmdValidador()
        {
            RuleFor(cmd => cmd.NumeroComanda)
                .GreaterThan<AgregarOrdenCmd, int>(0);
            RuleFor(cmd => cmd.Ordenes)
                .NotEmpty();
        }
    }
}