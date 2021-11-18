using FluentValidation;

namespace Gy.QySin.Application.Usuarios.Comandos.DesactivarUsuario
{
    public class DesactivarUsuarioCmdValidador : AbstractValidator<DesactivarUsuarioCmd>
    {
        public DesactivarUsuarioCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
        }
    }
}