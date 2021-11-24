using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Platillos.Comandos.Crear
{
    public class CrearPlatilloCmdValidador : AbstractValidator<CrearCmd>
    {
        private readonly IDbConfigurations dbConfigurations;

        public CrearPlatilloCmdValidador(IDbConfigurations dbConfigurations)
        {
            this.dbConfigurations = dbConfigurations;
        }
        public CrearPlatilloCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty()
                .MaximumLength(dbConfigurations.LongTextColumnLength);
            RuleFor(cmd => cmd.Precio)
                .GreaterThan<CrearCmd, decimal>(0m);
        }
    }
}