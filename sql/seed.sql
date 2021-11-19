INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('036368e5-d0e6-40ba-bcab-fb19d6bddd95','Alansin','Alan Cristian Ramos Pérez',true,'{"mesero"}');

INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('6bc3649e-196b-4920-a14b-aff290aec9f0','Cloe','Valentina Uresti',true,'{"administrador"}');

INSERT INTO "Ordenables"
("Clave", "Nombre", "Precio", "Categoria")
VALUES('4d85b2d3-1abe-46cd-95f0-60846dbe4b78', 'Naranjada', 45, 'bebidas');
INSERT INTO "Bebidas"
("Clave", "Contenido", "Rellenable")
VALUES('4d85b2d3-1abe-46cd-95f0-60846dbe4b78', 450, true);

INSERT INTO "Ordenables"
("Clave", "Nombre", "Precio", "Categoria")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 'Limonada', 45, 'bebidas');
INSERT INTO "Bebidas"
("Clave", "Contenido", "Rellenable")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 450, true);

INSERT INTO "Ordenables"
("Clave", "Nombre", "Precio", "Categoria")
VALUES('972b9231-202e-426e-8c2d-3fbd539c78f5', 'Jugo de naranja', 55, 'bebidas');
INSERT INTO "Bebidas"
("Clave", "Contenido", "Rellenable")
VALUES('972b9231-202e-426e-8c2d-3fbd539c78f5', 330, true);