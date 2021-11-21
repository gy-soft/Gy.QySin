using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Bebidas.Comandos.CrearBebida
{
    public class CrearBebidaCmdValidador : AbstractValidator<CrearBebidaCmd>
    {
        private readonly IDbConfigurations dbConfigurations;

        public CrearBebidaCmdValidador(IDbConfigurations dbConfigurations)
        {
            this.dbConfigurations = dbConfigurations;
        }
        public CrearBebidaCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty()
                .MaximumLength(dbConfigurations.LongTextColumnLength);
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<CrearBebidaCmd, decimal>(0m);
            RuleFor(cmd => cmd.Contenido)
                .GreaterThan<CrearBebidaCmd, int>(0);
        }
    }
}