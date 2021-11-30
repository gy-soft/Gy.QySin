INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('036368e5-d0e6-40ba-bcab-fb19d6bddd95','Alansin','Alan Cristian Ramos Pérez',true,'{"mesero"}');

INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('6bc3649e-196b-4920-a14b-aff290aec9f0','Cloe','Valentina Uresti',true,'{"administrador"}');

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('4d85b2d3-1abe-46cd-95f0-60846dbe4b78', 'Naranjada', 45, 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('4d85b2d3-1abe-46cd-95f0-60846dbe4b78', 450, true);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 'Limonada', 45, 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 450, true);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('0e94c95c-4e05-11ec-9480-67932bb6f9a8', 'Agua de jamaica', 45, 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('0e94c95c-4e05-11ec-9480-67932bb6f9a8', 450, true);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('972b9231-202e-426e-8c2d-3fbd539c78f5', 'Jugo de naranja', 55, 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('972b9231-202e-426e-8c2d-3fbd539c78f5', 330, false);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 'Café americano', 55, 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 330, true);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('a85f763e-4a74-11ec-957d-af9a5847120e', 'Milanesa de res', 120, 'platillos');
INSERT INTO "Platillos" ("Clave", "Vegetariano")
VALUES('a85f763e-4a74-11ec-957d-af9a5847120e', false);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('23c2a080-4a75-11ec-be6c-9f2f00b944c5', 'Milanesa de pollo', 120, 'platillos');
INSERT INTO "Platillos" ("Clave", "Vegetariano")
VALUES('23c2a080-4a75-11ec-be6c-9f2f00b944c5', false);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', 'Chile relleno de queso', 135, 'platillos');
INSERT INTO "Platillos" ("Clave", "Vegetariano")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', true);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Precio", "Categoria")
VALUES('cd5e9346-4e04-11ec-86a5-e7dac512f012', 'Chile relleno de picadillo', 135, 'platillos');
INSERT INTO "Platillos" ("Clave", "Vegetariano")
VALUES('cd5e9346-4e04-11ec-86a5-e7dac512f012', false);