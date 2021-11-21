using FluentValidation;

namespace Gy.QySin.Application.Comandas.Comandos.CrearComanda
{
    public class CrearComandaCmdValidador : AbstractValidator<CrearComandaCmd>
    {
        public CrearComandaCmdValidador()
        {
            RuleFor(cmd => cmd.Mesero)
                .NotEmpty();
            RuleFor(cmd => cmd.Mesa)
                .GreaterThan<CrearComandaCmd, int>(0);
        }
    }
}