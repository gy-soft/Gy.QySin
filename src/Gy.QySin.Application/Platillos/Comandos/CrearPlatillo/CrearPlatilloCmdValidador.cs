using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Platillos.Comandos.CrearPlatillo
{
    public class CrearPlatilloCmdValidador : AbstractValidator<CrearPlatilloCmd>
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
                .GreaterThan<CrearPlatilloCmd, decimal>(0m);
        }
    }
}