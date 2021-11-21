using FluentValidation;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Application.Usuarios.Comandos.CrearUsuario
{
    public class CrearUsuarioCmdValidador : AbstractValidator<CrearUsuarioCmd>
    {
        private readonly IDbConfigurations dbConfigurations;

        public CrearUsuarioCmdValidador(IDbConfigurations dbConfigurations)
        {
            this.dbConfigurations = dbConfigurations;
        }
        public CrearUsuarioCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty().WithMessage("'Nombre' es requerido.");
            RuleFor(cmd => cmd.Nombre)
                .MaximumLength(dbConfigurations.LongTextColumnLength);
        }
    }
}