-- drop functions
DROP FUNCTION IF EXISTS insert_into_platillos;
DROP FUNCTION IF EXISTS insert_into_bebidas;

-- drop tables
DROP TABLE IF EXISTS "PrecioOrdenables";
DROP TABLE IF EXISTS "DetalleBebidas";
DROP TABLE IF EXISTS "DetallePlatillos";
DROP TABLE IF EXISTS "Ordenables" CASCADE;
DROP TABLE IF EXISTS "Usuarios";

--drop types
DROP TYPE IF EXISTS "OrdenableCategorias";
DROP TYPE IF EXISTS "UsuarioRoles";