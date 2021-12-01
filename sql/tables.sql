CREATE TABLE "Usuarios" (
    "Clave" UUID PRIMARY KEY,
    "NombreCorto" CHARACTER VARYING(15),
    "Nombre" CHARACTER VARYING(50) NOT NULL,
    "Activo" BOOLEAN NOT NULL,
    "Roles" "UsuarioRoles"[]
);

CREATE TABLE "Ordenables" (
    "Clave" UUID UNIQUE NOT NULL,
    "Nombre" CHARACTER VARYING(50) UNIQUE NOT NULL,
    "Imagen" TEXT,
    "Categoria" "OrdenableCategorias" NOT NULL
);

CREATE TABLE "Bebidas" (
    "Clave" UUID CONSTRAINT "Bebidas_pkey" PRIMARY KEY,
    "Contenido" INTEGER NOT NULL,
    "Rellenable" BOOLEAN NOT NULL,
    CONSTRAINT "Bebidas_Ordenables_Clave_fkey" FOREIGN KEY("Clave") REFERENCES "Ordenables"("Clave")
);

CREATE TABLE "Platillos" (
    "Clave" UUID CONSTRAINT "Platillos_pkey" PRIMARY KEY,
    "Descripción" TEXT,
    "Vegetariano" BOOLEAN NOT NULL,
    CONSTRAINT "Platillos_Ordenables_Clave_fkey" FOREIGN KEY("Clave") REFERENCES "Ordenables"("Clave")
);

CREATE TABLE "PrecioOrdenables" (
    "Clave" UUID NOT NULL,
    "Precio" MONEY NOT NULL,
    "FechaInicio" DATE NOT NULL,
    "FechaFin" DATE,
    CONSTRAINT "Precio_Ordenables_Clave_fkey" FOREIGN KEY("Clave") REFERENCES "Ordenables"("Clave")
);

CREATE VIEW "vBebidas" AS
select p."Clave", "Nombre", "Precio", "Contenido", "Rellenable"
from (
    select "Clave", "Precio"
    from "PrecioOrdenables"
    where "FechaInicio" <= current_date
    and ("FechaFin" >= current_date or "FechaFin" is null)
) p JOIN (
    select *
    from "Ordenables"
    where "Categoria" = 'bebidas'
) o JOIN "Bebidas" d
ON p."Clave" = o."Clave"
and p."Clave" = d."Clave"
