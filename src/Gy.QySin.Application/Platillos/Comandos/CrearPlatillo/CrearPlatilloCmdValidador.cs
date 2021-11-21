using FluentValidation;

namespace Gy.QySin.Application.Platillos.Comandos.CrearPlatillo
{
    public class CrearPlatilloCmdValidador : AbstractValidator<CrearPlatilloCmd>
    {
        public CrearPlatilloCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty();
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<CrearPlatilloCmd, decimal>(0m);
        }
    }
}