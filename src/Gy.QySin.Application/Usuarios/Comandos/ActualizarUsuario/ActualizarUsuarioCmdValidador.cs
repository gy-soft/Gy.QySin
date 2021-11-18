using FluentValidation;

namespace Gy.QySin.Application.Usuarios.Comandos.ActualizarUsuario
{
    public class ActualizarUsuarioCmdValidador : AbstractValidator<ActualizarUsuarioCmd>
    {
        public ActualizarUsuarioCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(cmd => cmd.NombreCorto)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}