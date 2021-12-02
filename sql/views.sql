create view "PrecioOrdenablesUi" as
select p."Clave", "Precio", "FechaInicio", "FechaFin", "Nombre", "Categoria"
from "PrecioOrdenables" p
join "Ordenables" o
on p."Clave" = o."Clave";

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

create or replace function update_bebidas()
returns trigger as $$
begin
    update "Ordenables"
    set
        "Nombre" = new."Nombre"
        , "Imagen" = new."Imagen"
    where "Clave" = new."Clave";
    update "DetalleBebidas"
    set
        "Contenido" = new."Contenido"
        , "Rellenable" = new."Rellenable"
    where "Clave" = new."Clave";
    return new;
end;
$$ language plpgsql;
create trigger update_bebidas instead of update on "Bebidas"
    for each row execute function update_bebidas();

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

create or replace function update_platillos()
returns trigger as $$
begin
    update "Ordenables"
    set
        "Nombre" = new."Nombre"
        , "Imagen" = new."Imagen"
    where "Clave" = new."Clave";
    update "DetallePlatillos"
    set
        "Descripción" = new."Descripción"
        , "Vegetariano" = new."Vegetariano"
    where "Clave" = new."Clave";
    return new;
end;
$$ language plpgsql;
create trigger update_platillos instead of update on "Platillos"
    for each row execute function update_platillos();