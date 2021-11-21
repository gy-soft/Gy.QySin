using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Usuarios.Comandos.ActualizarUsuario
{
    public class ActualizarUsuarioCmdValidador : AbstractValidator<ActualizarUsuarioCmd>
    {
        private readonly IDbConfigurations dbConfigurations;

        public ActualizarUsuarioCmdValidador(IDbConfigurations dbConfigurations)
        {
            this.dbConfigurations = dbConfigurations;
        }
        public ActualizarUsuarioCmdValidador()
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