using FluentValidation;

namespace Gy.QySin.Application.Usuarios.Comandos.Desactivar
{
    public class DesactivarUsuarioCmdValidador : AbstractValidator<DesactivarCmd>
    {
        public DesactivarUsuarioCmdValidador()
        {
            RuleFor(cmd => cmd.Clave)
                .NotEmpty();
        }
    }
}