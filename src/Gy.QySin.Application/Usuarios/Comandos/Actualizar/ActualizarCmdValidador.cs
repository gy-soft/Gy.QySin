using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Usuarios.Comandos.Actualizar
{
    public class ActualizarCmdValidador : AbstractValidator<ActualizarCmd>
    {
        private readonly IDbConfigurations dbConfigurations;

        public ActualizarCmdValidador(IDbConfigurations dbConfigurations)
        {
            this.dbConfigurations = dbConfigurations;
        }
        public ActualizarCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty()
                .MaximumLength(dbConfigurations.LongTextColumnLength);
            RuleFor(cmd => cmd.NombreCorto)
                .NotEmpty()
                .MaximumLength(dbConfigurations.ShortTextColumnLength);
        }
    }
}