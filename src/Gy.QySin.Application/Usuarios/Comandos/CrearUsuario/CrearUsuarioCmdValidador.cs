using FluentValidation;

namespace Gy.QySin.Application.Usuarios.Comandos.CrearUsuario
{
    public class CrearUsuarioCmdValidador : AbstractValidator<CrearUsuarioCmd>
    {
        public CrearUsuarioCmdValidador()
        {
            RuleFor(cmd => cmd.Nombre)
                .NotEmpty().WithMessage("'Nombre' es requerido.");
            // Validar longitud del campo
        }
    }
}