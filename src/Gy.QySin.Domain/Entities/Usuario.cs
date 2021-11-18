using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Usuario : IUsuario
    {
        public Usuario() {}
        public Usuario(string nombre, UsuarioRoles rol)
        {
            Clave = Guid.NewGuid().ToString();
            Nombre = nombre;
            Roles = new List<UsuarioRoles>()
            {
                rol
            };
        }
        [Key]
        public string Clave { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioRoles> Roles { get; set; }
        public bool Activo { get; set; }
    }
}