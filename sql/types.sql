CREATE TYPE "UsuarioRoles" AS ENUM (
    'administrador',
    'mesero',
    'gerente',
    'chef',
    'cocinero'
);

CREATE TYPE "OrdenableCategorias" AS ENUM (
    'platillos',
    'bebidas',
    'postres'
);