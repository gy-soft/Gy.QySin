INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('036368e5-d0e6-40ba-bcab-fb19d6bddd95','Alansin','Alan Cristian Ramos Pérez',true,'{"mesero"}');

INSERT INTO "Usuarios"
("Clave", "NombreCorto", "Nombre", "Activo", "Roles")
VALUES('6bc3649e-196b-4920-a14b-aff290aec9f0','Cloe','Valentina Uresti',true,'{"administrador"}');

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 'Limonada', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 450, true);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('6c6287bf-055c-4d26-a533-c7d78ef866f3', 38.5, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('0e94c95c-4e05-11ec-9480-67932bb6f9a8', 'Agua de jamaica', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('0e94c95c-4e05-11ec-9480-67932bb6f9a8', 450, true);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('0e94c95c-4e05-11ec-9480-67932bb6f9a8', 38.5, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 'Café americano', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 330, true);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 30, '2021-11-01', '2021-12-31');
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 32.5, '2022-01-01', '2022-01-31');
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('3ec21770-4e04-11ec-95c6-97281991a166', 35, '2022-02-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('3564501e-52d0-11ec-9279-df8a768bc59d', 'Coca-cola', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('3564501e-52d0-11ec-9279-df8a768bc59d', 355, false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('3564501e-52d0-11ec-9279-df8a768bc59d', 18, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('5aa44186-52d0-11ec-beea-5b157d3e29b9', 'Coca-cola light', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('5aa44186-52d0-11ec-beea-5b157d3e29b9', 355, false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('5aa44186-52d0-11ec-beea-5b157d3e29b9', 18, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('8360cdce-52d0-11ec-a593-c3c3fdde367e', 'Sprite', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('8360cdce-52d0-11ec-a593-c3c3fdde367e', 355, false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('8360cdce-52d0-11ec-a593-c3c3fdde367e', 18, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('d26aa9d2-52dd-11ec-b829-135430a773b0', 'Fanta', 'bebidas');
INSERT INTO "Bebidas" ("Clave", "Contenido", "Rellenable")
VALUES('d26aa9d2-52dd-11ec-b829-135430a773b0', 355, false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('d26aa9d2-52dd-11ec-b829-135430a773b0', 18, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('a85f763e-4a74-11ec-957d-af9a5847120e', 'Milanesa de res', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('a85f763e-4a74-11ec-957d-af9a5847120e', 'Con papas y ensalada verde.', false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('a85f763e-4a74-11ec-957d-af9a5847120e', 90, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('23c2a080-4a75-11ec-be6c-9f2f00b944c5', 'Milanesa de pollo', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('23c2a080-4a75-11ec-be6c-9f2f00b944c5', 'Con papas y ensalada verde.', false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('23c2a080-4a75-11ec-be6c-9f2f00b944c5', 90, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', 'Chile relleno de queso', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', 'Con arroz blanco y frijoles.', true);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', 100, '2021-11-01', '2021-11-30');
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('53c87192-4a75-11ec-a2eb-df1c165275d1', 105, '2021-12-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('cd5e9346-4e04-11ec-86a5-e7dac512f012', 'Chile relleno de picadillo', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('cd5e9346-4e04-11ec-86a5-e7dac512f012', 'Con arroz blanco y frijoles.', false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('cd5e9346-4e04-11ec-86a5-e7dac512f012', 105, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('5d299146-52de-11ec-905c-0bd9398be3e3', 'Bistek ranchero', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('5d299146-52de-11ec-905c-0bd9398be3e3', 'Carne de res en salsa verde.', false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('5d299146-52de-11ec-905c-0bd9398be3e3', 90, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('cc6f3c2c-52de-11ec-b9d9-f348fbf8b319', 'Enchiladas de pollo', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('cc6f3c2c-52de-11ec-b9d9-f348fbf8b319', 'En salsa verde o roja.', false);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('cc6f3c2c-52de-11ec-b9d9-f348fbf8b319', 85, '2021-11-01', null);

INSERT INTO "Ordenables" ("Clave", "Nombre", "Categoria")
VALUES('d8b07a6e-52de-11ec-ba69-5f50901cce02', 'Enchildas de queso', 'platillos');
INSERT INTO "Platillos" ("Clave", "Descripción", "Vegetariano")
VALUES('d8b07a6e-52de-11ec-ba69-5f50901cce02', 'En salsa verde o roja.', true);
INSERT INTO "PrecioOrdenables" ("Clave", "Precio", "FechaInicio", "FechaFin")
VALUES('d8b07a6e-52de-11ec-ba69-5f50901cce02', 85, '2021-11-01', null);