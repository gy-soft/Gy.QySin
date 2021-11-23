using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gy.QySin.Domain.Enums;
using Gy.QySin.Domain.Interfaces;

namespace Gy.QySin.Domain.Entities
{
    public class Usuario : IEntity
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

        public object Id => Clave;

        public void AgregarRol(UsuarioRoles rol)
        {
            if (Roles is null)
            {
                Roles = new List<UsuarioRoles>()
                {
                    rol
                };
            }
            else if (!Roles.Contains(rol))
            {
                Roles.Add(rol);
            }
        }
    }
}