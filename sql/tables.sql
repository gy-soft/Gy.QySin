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

CREATE TABLE "DetalleBebidas" (
    "Clave" UUID CONSTRAINT "Bebidas_pkey" PRIMARY KEY,
    "Contenido" INTEGER NOT NULL,
    "Rellenable" BOOLEAN NOT NULL,
    CONSTRAINT "Bebidas_Ordenables_Clave_fkey" FOREIGN KEY("Clave") REFERENCES "Ordenables"("Clave")
);

CREATE TABLE "DetallePlatillos" (
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

CREATE VIEW "Bebidas" AS
SELECT p."Clave", "Nombre", "Imagen", "Precio", "Contenido", "Rellenable"
FROM (
    select "Clave", "Precio"
    from "PrecioOrdenables"
    where "FechaInicio" <= current_date
    and ("FechaFin" >= current_date or "FechaFin" is null)
) p JOIN (
    select *
    from "Ordenables"
    where "Categoria" = 'bebidas'
) o ON p."Clave" = o."Clave"
JOIN "DetalleBebidas" d
ON p."Clave" = d."Clave";

CREATE VIEW "Platillos" AS
SELECT p."Clave", "Nombre", "Imagen", "Precio", "Descripción", "Vegetariano"
FROM (
    select "Clave", "Precio"
    from "PrecioOrdenables"
    where "FechaInicio" <= current_date
    and ("FechaFin" >= current_date or "FechaFin" is null)
) p JOIN (
    select *
    from "Ordenables"
    where "Categoria" = 'platillos'
) o ON p."Clave" = o."Clave"
JOIN "DetallePlatillos" d
ON p."Clave" = d."Clave";

create or replace function insert_into_bebidas()
returns trigger as $$
begin
    insert into "Ordenables"("Clave", "Nombre", "Imagen", "Categoria")
    values(new."Clave", new."Nombre", new."Imagen", 'bebidas');
    insert into "DetalleBebidas"("Clave", "Contenido", "Rellenable")
    values (new."Clave", new."Contenido", new."Rellenable");
    return new;
end;
$$ language plpgsql;
create trigger insert_into_bebidas instead of insert on "Bebidas"
    for each row execute function insert_into_bebidas();

create or replace function insert_into_platillos()
returns trigger as $$
begin
    insert into "Ordenables"("Clave", "Nombre", "Imagen", "Categoria")
    values(new."Clave", new."Nombre", new."Imagen", 'platillos');
    insert into "DetallePlatillos"("Clave", "Descripción", "Vegetariano")
    values (new."Clave", new."Descripción", new."Vegetariano");
    return new;
end;
$$ language plpgsql;
create trigger insert_into_platillos instead of insert on "Platillos"
    for each row execute function insert_into_platillos();