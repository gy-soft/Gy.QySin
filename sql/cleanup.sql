-- drop tables and views
DROP VIEW IF EXISTS "PrecioOrdenablesUi";
DROP VIEW IF EXISTS "Bebidas";
DROP VIEW IF EXISTS "Platillos";
DROP TABLE IF EXISTS "PrecioOrdenables";
DROP TABLE IF EXISTS "DetalleBebidas";
DROP TABLE IF EXISTS "DetallePlatillos";
DROP TABLE IF EXISTS "Ordenables" CASCADE;
DROP TABLE IF EXISTS "Usuarios";

-- drop functions
DROP FUNCTION IF EXISTS insert_into_platillos;
DROP FUNCTION IF EXISTS update_platillos;
DROP FUNCTION IF EXISTS insert_into_bebidas;
DROP FUNCTION IF EXISTS update_bebidas;

--drop types
DROP TYPE IF EXISTS "OrdenableCategorias";
DROP TYPE IF EXISTS "UsuarioRoles";