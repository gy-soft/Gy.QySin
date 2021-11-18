using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;

namespace Gy.QySin.Domain.Entities
{
    public class Usuario
    {
        public Usuario() {}
        public Usuario(string nombre, UsuarioRoles rol)
        {
            Clave = Guid.NewGuid();
            Nombre = nombre;
            Roles = new List<UsuarioRoles>()
            {
                rol
            };
            Activo = true;
        }
        [Key]
        public Guid Clave { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioRoles> Roles { get; set; }
        public bool Activo { get; set; }
    }
}