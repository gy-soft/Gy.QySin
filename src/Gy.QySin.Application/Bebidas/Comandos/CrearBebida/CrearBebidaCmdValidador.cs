using FluentValidation;

namespace Gy.QySin.Application.Bebidas.Comandos.CrearBebida
{
    public class CrearBebidaCmdValidador : AbstractValidator<CrearBebidaCmd>
    {
        public CrearBebidaCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty();
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<CrearBebidaCmd, decimal>(0m);
            RuleFor(cmd => cmd.Contenido)
                .GreaterThan<CrearBebidaCmd, int>(0);
        }
    }
}