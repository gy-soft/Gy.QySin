using FluentValidation;

namespace Gy.QySin.Application.Comandas.Comandos.Crear
{
    public class CrearComandaCmdValidador : AbstractValidator<CrearCmd>
    {
        public CrearComandaCmdValidador()
        {
            RuleFor(cmd => cmd.Mesero)
                .NotEmpty();
            RuleFor(cmd => cmd.Mesa)
                .GreaterThan<CrearCmd, int>(0);
        }
    }
}