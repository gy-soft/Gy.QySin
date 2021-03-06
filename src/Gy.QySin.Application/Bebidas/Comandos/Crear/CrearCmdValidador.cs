using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Bebidas.Comandos.Crear
{
    public class CrearBebidaCmdValidador : AbstractValidator<CrearCmd>
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
            RuleFor(cmd => cmd.Contenido)
                .GreaterThan<CrearCmd, int>(0);
        }
    }
}