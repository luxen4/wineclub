drop table if exists variedaduva;       /*1*/
drop table if exists tipouva;           /*2*/ 
drop table if exists clasevino;         /*3*/
drop table if exists proveedor;         /*4*/
drop table if exists catalogacion;      /*5*/
drop table if exists denominacion;      /*6*/
drop table if exists formatoes;         /*7*/
drop table if exists empaquetado;       /*7.5*/
drop table if exists articulo;          /*8*/
drop table if exists socio;             /*9*/
drop table if exists ubicacion;         /*10*/
drop table if exists compraproveedor;         /*11*/
drop table if exists ubicacionarticulo;       /*12*/

drop table ventasocio; /*15*/

/* 1---------------------------------------------------------------Blanca/Tinta--------------*/
CREATE TABLE variedaduva (
    id_variedaduva INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar(10) DEFAULT NULL,
    nombre varchar(20) NOT NULL,
    activo enum ("0","1") not null);

INSERT INTO `variedaduva` (`id_variedaduva`, `ref`, `nombre`, `activo`) VALUES
(1, 'VU1', 'Tintas','1'),
(2, 'VU2', 'Blancas','1');


/* 2-------------------------------------------------------- Variedad de Uva empleada Viura: 100% */
CREATE TABLE tipouva (
    id_tipouva INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) UNIQUE default null,
    nombre varchar(50) UNIQUE NOT NULL,
    id_variedaduva int not null,
    activo enum ("0","1") not null,

    foreign key (id_variedaduva) references variedaduva(id_variedaduva) on update cascade on delete cascade
    );

INSERT INTO tipouva (`id_tipouva`, `ref`, `nombre`, `id_variedaduva`, `activo`) 
VALUES
    (1, 'TU1','Tempranillo', 1, '1'),      /* Bobal, Pinot Noir, Tintorera, Black Muscat, Malbec, Cabernet Franc, Zinfandel, Montepulcian, Petite Syrah, Nebbiolo, Barbera, Sangiovese, Gamay*/
    (2, 'TU2','Garnacha', 1,'1'),
    (3, 'TU3','Mencía', 1,'1'),
    (4, 'TU4','Monastrell', 1,'1'),
    (5, 'TU5','Cabernet Sauvignon', 1,'1'),
    (6, 'TU6','Merlot', 1,'1'),
    (7, 'TU7','Syrah', 1,'1'),

    (8,  'TU8','Verdejo', 2,'1'),         /* Moscatel, Verdil, Merseguera, Malvasía*/
    (9,  'TU9','Alvariño', 2,'1'),
    (10, 'TU10','Godello', 2,'1'),
    (11, 'TU11','Viura', 2,'1'),
    (12, 'TU12','Sauvignon', 2,'1'),
    (13, 'TU13','Macabeo', 2,'1'),
    (14, 'TU14','Chardonnay', 2,'1'),
    (15, 'TU15','Riesling', 2,'1'),
    (16, 'TU16','Pinnot Blanc', 2,'1'),

    (17, 'TU17','Tempranillo, Graciano y Mazuelo', 1,'1')
    ;
/*-----------------------------------------------------------------------------------*/
/* Una tabla intermedia entre clase de vino y tipo de uva empleada */
/* https://neveraespanola.com/mejor-uva-hacer-vino-tinto/ */



/* 3---------------------------------------------------------------Tinto/Blanco/Rosado--------------*/
create table clasevino (
    id_clasevino INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) UNIQUE default null,
    /*nombre enum ("TINTO","BLANCO","ROSADO","ESPUMOSO","GENEROSO") not null*/
    nombre VARCHAR (15) UNIQUE not null,
    activo enum ("0","1") not null
);
INSERT INTO `clasevino` (`id_clasevino`, `ref`, `nombre`, `activo`) VALUES
(1, 'CLS1', 'TINTO','1'),
(2, 'CLS2', 'BLANCO','1'),
(3, 'CLS3', 'ROSADO','1'),
(4, 'CLS4', 'ESPUMOSO','1'),
(5, 'CLS5', 'GENEROSO','1');


/* 4---------------------------------------------------------------Reserva 2017/Gran Reserva 2014--------------*/
create table catalogacion(
    id_catalogacion INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) UNIQUE default null,
    nombre varchar (20) unique not null,
    activo enum ("0","1") not null
    );

INSERT INTO `catalogacion` (`id_catalogacion`, `ref`, `nombre`, `activo`) VALUES
(1, 'CAT1', 'Reserva 2017', '1'),
(2, 'CAT2', 'Gran Reserva 2014', '1'),
(3, 'CAT3', 'Verdejo 2021', '1'),
(4, 'CAT4', 'Crianza 2019', '1'),
(5, 'CAT5', 'SEMIDULCE *C.V.C.', '1'),
(6, 'CAT6', 'Joven', '1'),
(7, 'CAT7', '2021', '1'),
(8, 'CAT8', 'Txakoli 2018', '1');


/* 5---------------------------------------------------------------D.O. Ribera del Duero/D.O. Ca Rioja--------------*/
create table denominacion(
    id_denominacion INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) UNIQUE default null,
    nombre varchar (30) UNIQUE not null,
    activo enum ("0","1") not null
    );

INSERT INTO `denominacion` (`id_denominacion`, `ref`, `nombre`, `activo`) VALUES
(1, 'DEN1', 'D.O. Ribera del Duero','1'),
(2, 'DEN2', 'D.O. Ca Rioja','1'),
(3, 'DEN3', 'D.O. Valdepeñas','1'),
(4, 'DEN4', 'D.O. Bierzo','1'),
(5, 'DEN5', 'D.O. Rueda','1');

/* 6---------------------------------------------------------------Magnum/Tres octavos--------------*/
create table formatocontenido (
    id_formatocontenido INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique not null,
    nombre varchar (15) unique not null,
    contenido varchar (15) not null,
    activo enum ("0","1") not null
    );
    

/*ALTER TABLE formatocontenido ADD activo enum ("0","1") not null AFTER contenido;*/

INSERT INTO `formatocontenido` (`id_formatocontenido`, `ref`, `nombre`, `contenido`, `activo`) VALUES
(1, 'CON1', 'Benjamín', '187.5 cc','1'),
(2, 'CON2', '3/8', '375 cc','1'),
(3, 'CON3', 'Estandar 3/4', '750 cc','1'),
(4, 'CON4', 'Magnum', '1.5 L','1'),
(5, 'CON5', 'Jeroboam', '3.5 L','1'),
(6, 'CON6', 'Réhoboam', '4.5 L','1'),
(7, 'CON7', 'Mathusalem', '6 L','1'),
(8, 'CON8', 'Salmanazar', '9 L','1'),
(9, 'CON9', 'Balthasar', '12 L','1'),
(10, 'CON10', 'Nabuchodonosor', '15 L','1'),
(11, 'CON11', 'Salomón', '18 L','1'),
(12, 'CON12', 'Souverain', '26.25 L','1'),
(13, 'CON13', 'Primat', '27 L','1'),
(14, 'CON14', 'Melchizedec', '30 L','1'),
(15, 'CON15', 'GRANEL', 'GRANEL','1');


/* 7---------------------------------------------------------------Botella, caja de 6 botellas----------------------------*/
create table empaquetado(
    id_empaquetado int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique not null,
    nombre varchar(20) UNIQUE not null,
    activo enum ("0","1") not null
    );

INSERT INTO `empaquetado` (`id_empaquetado`, `ref`, `nombre`, `activo`) VALUES
(1, 'EMP1', 'Botella','1'),
(2, 'EMP2', 'Caja 6 Botellas','1'),
(3, 'EMP3', 'Bag in Box 15L','1'),
(4, 'EMP4', 'Brick-Cartón 1L.','1');




/* 8---------------------------------------------------------------Proveedores: Marqués de Cáceres/CUNE--------------*/
create table proveedor(
    id_proveedor INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique not null,
    nombre varchar (50) UNIQUE not null,
    direccion varchar (50) not null,
    localidad varchar (25) not null,
    provincia varchar (25) not null,
    telefono varchar (15) not null,
    email varchar (65) not null,
    activo enum ("0","1") not null/*,
    nombreimagen varchar (30)*/
    );

INSERT INTO `proveedor` (`id_proveedor`, `ref`, `nombre`, `direccion`, `localidad`, `provincia`, `telefono`, `email`, `activo`) VALUES
(1, 'PRO1', 'ALTOS DE TAMARON', 'C. Somillo (Paraje La Balsa), 01309', 'Bilar', 'Álava', '945600693', 'https://www.altosderioja.com/','1'),
(2, 'PRO2', 'MARQUÉS DE CÁCERES', 'Av. Fuenmayor, 11, 26350', 'Cenicero', 'La Rioja', '941454000', 'admin@marquesdecaceres.com','1'),
(3, 'PRO3', 'VIÑA POMAL', 'C. Estación, s/n, 26200', 'Haro', 'La Rioja', '941310147', 'http://www.bodegasbilbainas.com/','1'),
(4, 'PRO4', 'SANZ', 'Ctra. N-VI km 170,5', 'Rueda', 'Valladolid', '983868100', 'vinossanz@vinossanz.com','1'),
(5, 'PRO5', 'CUNE', 'Carretera de Logroño – Laguardia Km 4,8, 01300', 'Laguardia', 'Álava', '945625255', 'rgpd@cvne.com','1'),
(6, 'PRO6', 'RAMÓN BILBAO', 'Av. Santo Domingo de la Calzada, 34, 26200', 'Haro', 'La Rioja', '941310316', 'bodegasramonbilbao.es','1'),

(10, 'PRO10', 'Bodega y Viñedos Milénico, SL','San Martín de Rubiales, 09317', 'Burgos', 'Castilla y León', '+ 34 695 382848', 'milenico@milenico.com','1')/*estuche*/
;




/*ALTER TABLE proveedor ADD activo enum ("0","1") not null AFTER email;*/


/* 9---------------------------------------------------------------Artículos--------------*/
create table articulo(
    id_articulo INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) /*default null*/ UNIQUE not null,
    /*ref VARCHAR(10) AS (CONCAT('ART','',id_articulo)) STORED,*/
    id_tipouva int not null,
    id_clasevino int not null,
    id_proveedor int not null,
    id_catalogacion int not null,
    id_denominacion int not null,
    id_empaquetado int not null,
    id_formatocontenido  int not null,

    minalmacen int not null,
    maxalmacen int not null,
    mintienda int not null,
    maxtienda int not null,
    nombreimagen varchar (50) not null,
/*
  preciocompramin DECIMAL (4,2) not null,
  preciocompramax DECIMAL (4,2) not null,
  precioventamin DECIMAL (4,2) not null,
  precioventamax DECIMAL (4,2) not null,
*/

    activo enum ("0","1") not null,

    foreign key (id_tipouva) references tipouva(id_tipouva) on update cascade on delete cascade,
    foreign key (id_clasevino) references clasevino(id_clasevino) on update cascade on delete cascade,
    foreign key (id_proveedor) references proveedor(id_proveedor) on update cascade on delete cascade,
    foreign key (id_catalogacion) references catalogacion(id_catalogacion) on update cascade on delete cascade,
    foreign key (id_denominacion) references denominacion(id_denominacion) on update cascade on delete cascade,
    foreign key (id_empaquetado) references empaquetado(id_empaquetado) on update cascade on delete cascade,
    foreign key (id_formatocontenido) references formatocontenido(id_formatocontenido) on update cascade on delete cascade

);



INSERT INTO `articulo` (`id_articulo`, `ref`, `id_tipouva`, `id_clasevino`, `id_proveedor`, `id_catalogacion`, `id_denominacion`, `id_empaquetado`, `id_formatocontenido`, `minalmacen`, `maxalmacen`, `mintienda`, `maxtienda`, `nombreimagen`, `activo`) VALUES
(1, 'ART1', 1, 1, 1, 1, 1, 1, 3, 10, 75, 5, 25, 'art1.jpg',"1"),    /* Altos de Tamarón OK */
(2, 'ART2', 1, 1, 1, 4, 1, 1, 3, 10, 75, 5, 25, 'art2.jpg',"1"),
(3, 'ART3', 1, 2, 6, 5, 2, 1, 7, 10, 75, 5, 25, 'art3.jpg',"1"),
(4, 'ART4', 1, 2, 4, 3, 2, 2, 3, 10, 75, 5, 25, 'art4.jpg',"1"),    /* Sanz */
(5, 'ART5', 1, 1, 3, 4, 2, 1, 9, 10, 75, 5, 25, 'art5.jpg',"1"),    /* Viña Pomal */
(6, 'ART6', 1, 2, 4, 1, 1, 1, 3, 10, 75, 5, 25, 'art6.jpg',"1"),    /* Ramón Bilbao Verdejo */
(7, 'ART7', 1, 3, 5, 6, 2, 1, 3, 10, 75, 5, 25, 'art7.jpg',"1"),    /* Cune Rosado ok */
(8, 'ART8', 17, 1, 2, 4, 2, 1, 3, 10, 75, 5, 75, 'art8.jpg', '1'),    /* Marqués de Cáceres */
(9, 'ART9', 1, 2, 5, 5, 2, 1, 3, 10, 75, 5, 25, 'art9.jpg',"1"),    /* Cune Blanco OK */
(10, 'ART10', 1, 1, 2, 4, 2, 1, 3, 10, 75, 5, 25, 'art10.jpg',"1"); /* Marqués de Riscal*/



  



/* 10---------------------------------------------------------------Ubicaciones: Almacén/Tienda--------------*/
create table ubicacion(
    id_ubicacion int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nombre varchar (15) not null
    );

insert into ubicacion(nombre) 
values
    ("Almacén"),("Tienda");


/* 11---------------------------------------------------------------Dueño, encargado, dependiente--------------*/
create table rollempleado (
    id_rollempleado int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique not null,
    nombre varchar (20) unique not null,
    activo enum ("0","1") not null

);
INSERT INTO `rollempleado` (`id_rollempleado`, `ref`, `nombre`, `activo`) VALUES
(1, 'Roll1', 'Dueño','1'),
(2, 'Roll2', 'Encargado','1'),
(3, 'Roll3', 'Dependiente','1');

/* 12---------------------------------------------------------------Adrián Laya García--------------*/
create table empleado (
    id_empleado int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique,
    nombre varchar (20) not null,
    apellido1 varchar (50) not null,
    apellido2 varchar (50) not null,
    telefono varchar (20) not null,
    email varchar (45) not null,
    sexo enum ("Hombre", "Mujer") not null,
    fechanacimiento DATE,
    usuario varchar (15) not null,
    contrasena varchar (65) not null,
    id_rollempleado int not null,
   /* nombreimagen varchar (30),*/
    activo enum ("0","1") not null,

    foreign key (id_rollempleado) references rollempleado(id_rollempleado) on update cascade on delete cascade
);

INSERT INTO `empleado` (`id_empleado`, `ref`, `nombre`, `apellido1`, `apellido2`, `telefono`, `email`, `sexo`, `fechanacimiento`, `usuario`, `contrasena`, `id_rollempleado`, `activo`) 
VALUES
(1, 'EMP1', 'Adrián', 'Laya', 'García', '637117965', 'superlaya50@gmail.com', 'Hombre', '1982-06-16', 'adrian', '6QRNJHgiEptBfbMM4eaHEFkCctQ=',1,"1"),
(2, 'EMP2', 'Gemma', 'Mago', 'Martínez', '000000001', 'gemma@gmail.com', 'Mujer', '1980-06-16', 'gemma', '6QRNJHgiEptBfbMM4eaHEFkCctQ=',2,"1"),
(3, 'EMP3', 'Eduardo', 'Hormilla', 'Urraca', '000000002', 'hormilla@gmail.com', 'Hombre', '1982-03-09', 'eduardo', '6QRNJHgiEptBfbMM4eaHEFkCctQ=',3,"1"),
(4, 'EMP4', 'Borja', 'García', 'Barquín', '000000003', 'borja@gmail.com', 'Hombre', '2000-01-24', 'borja', '6QRNJHgiEptBfbMM4eaHEFkCctQ=',3,"1"),
(5, 'EMP5', 'Carlos', 'Alcalde', 'Morales', '999999999', 'carlos@gmail.com', 'Hombre', '2023-09-11', 'carlos', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 3, '1');;

/*ALTER TABLE empleado ADD activo enum ("0","1") not null AFTER nombreimagen;*/
/* alter table empleado drop nombreimagen;*/

/* 13---------------------------------------------------------------Compra a Proveedor--------------*/
create table compraproveedor(
    id_compraproveedor int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_empleado int not null,
    ref varchar (10) unique not null,  
    fechacompra Date,

    foreign key (id_empleado) references empleado(id_empleado) on update cascade on delete cascade

    );


INSERT INTO `compraproveedor` (`id_compraproveedor`, `id_empleado`, `ref`, `fechacompra`) 
VALUES
    (1, 1, 'CPRO1', '2023-08-01'),
    (2, 1, 'CPRO2', '2023-08-02'),
    (3, 1, 'CPRO3', '2023-08-03'),
    (4, 1, 'CPRO4', '2023-08-04'),
    (5, 1, 'CPRO5', '2023-08-05'),
    (6, 1, 'CPRO6', '2023-08-06'),
    (7, 1, 'CPRO7', '2023-08-07'),
    (8, 1, 'CPRO8', '2023-08-08'),
    (9, 1, 'CPRO9', '2023-08-09'),
    (10, 1, 'CPR10', '2023-08-10');


/*14*/
create table lineacompraproveedor(
    id_lineacompraproveedor int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique,
    id_compraproveedor int not null,
    id_articulo int not null,
    existencias int not null,
    preciocoste DECIMAL (7,2) not null,
    precioventa DECIMAL (7,2) default 0,   

    foreign key (id_compraproveedor) references compraproveedor(id_compraproveedor) on update cascade on delete cascade,
    foreign key (id_articulo) references articulo(id_articulo) on update cascade on delete cascade
    
    );

INSERT INTO `lineacompraproveedor` (`id_lineacompraproveedor`, `ref`, `id_compraproveedor`, `id_articulo`, `existencias`, `preciocoste`, `precioventa`) VALUES
(1, 'LCP1', 1, 1, 100, '1.94', '3.99'),
(2, 'LCP2', 2, 2, 100, '2.99', '4.99'),
(3, 'LCP3', 3, 3, 100, '2.99', '5.99'),
(4, 'LCP4', 4, 4, 100, '1.99', '3.99'),
(5, 'LCP5', 5, 5, 100, '2.08', '4.08'),
(6, 'LCP6', 6, 6, 100, '8.02', '9.01'),
(7, 'LCP7', 7, 7, 100, '1.99', '3.99'),
/*(8, 'LCP8', 8, 8, 100, '2.08', '4.08'),*/
(9, 'LCP9', 9, 9, 100, '8.02', '9.01'),
(10, 'LCP10', 10, 10, 100, '4.55', '10.65'),
(11, 'LCP11', 1, 1, 100, '4.99', '12.99');



/* 15 mejor */
create table ubicacionlineacompraproveedor(
    id_ubicacionlinearcompraproveedor int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_ubicacion int not null,
    id_lineacompraproveedor int not null,
    id_articulo int not null,
    existencias int not null,

    foreign key (id_ubicacion) references ubicacion(id_ubicacion)on update cascade on delete cascade,
    foreign key (id_lineacompraproveedor) references lineacompraproveedor(id_lineacompraproveedor)on update cascade on delete cascade,
    foreign key (id_articulo) references articulo(id_articulo)on update cascade on delete cascade

    );

INSERT INTO `ubicacionlineacompraproveedor` (`id_ubicacionlinearcompraproveedor`, `id_ubicacion`, `id_lineacompraproveedor`, `id_articulo`, `existencias`) VALUES
(1, 1, 1, 1, 75),
(2, 2, 1, 1, 25),
(3, 1, 2, 2, 75),
(4, 2, 2, 2, 25),
(5, 1, 3, 3, 75),
(6, 2, 3, 3, 25),
(7, 1, 4, 4, 75),
(8, 2, 4, 4, 25),
(9, 1, 5, 5, 75),
(10, 2, 5, 5, 25),
(11, 1, 11, 1, 75),
(12, 2, 11, 1, 25),
(15, 1, 7, 7, 75),
(16, 2, 7, 7, 25),
/*(17, 1, 8, 8, 75),
(18, 2, 8, 8, 75),*/
(19, 1, 9, 9, 75),
(20, 2, 9, 9, 25);

/* 16---------------------------------------------------------------Devolución al Proveedor--------------*/

create table devolucionproveedor(
    id_devolucionproveedor  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_empleado int not null,
   /* id_compraproveedor      int not null,*/
    id_lineacompraproveedor int not null, 
    unidades       int not null,  
    /*fecha         Date,   */
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,  /* Marca la hora*/  

    foreign key (id_empleado) references empleado(id_empleado) on update cascade on delete cascade,
  /*  foreign key (id_compraproveedor) references compraproveedor(id_compraproveedor) on update cascade on delete cascade,*/
    foreign key (id_lineacompraproveedor) references lineacompraproveedor(id_lineacompraproveedor) on update cascade on delete cascade
);



/* 17---------------------------------------------------------------Adrián Laya García-------------- */
create table socio (
    id_socio int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique,
    nombre varchar (20) not null,
    apellidos varchar (50) not null,
    localidad varchar (50) not null,
    provincia varchar (50) not null,
    sexo enum ("Hombre", "Mujer") not null,
    nif varchar (12) not null,
    telefono varchar (12) not null,
    email varchar (25) not null,
    recibir_info enum ("Si","No") not null,
    activo enum ("0","1") not null
  /*  nombreimagen varchar (30)*/
);

/*ALTER TABLE socio AUTO_INCREMENT=55; Desde donde empieza*/

INSERT INTO `socio` (`id_socio`, `ref`, `nombre`, `apellidos`, `localidad`, `provincia`, `sexo`, `nif`, `telefono`, `email`, `recibir_info`,`activo`) VALUES
(1, 'SOC1', 'Jorge', 'Martinez Corada', 'Logroño', 'La Rioja', 'Hombre', '33333333-R', '606000001', 'corada@gmail.com', 'Si','1'),
(2, 'SOC2', 'Javier', 'Hernán Martinez', 'Logroño', 'La Rioja', 'Hombre', '22222222-R', '606000002', 'hernan@gmail.com', 'Si','1'),
(3, 'SOC3', 'Tirso', 'Salazar Arregui', 'Logroño', 'La Rioja', 'Hombre', '33333333-A', '606000003', 'tirso@gmail.com', 'No','1'),
(4, 'SOC4', 'Álvaro Javier', 'García Álvarez', 'Logroño', 'La Rioja', 'Hombre', '44444444-G', '606000004', 'alvaro@gmail.com','Si','1'),
(5, 'SOC5', 'Raul', 'Moreno Espinosa', 'Santander', 'Cantabria', 'Hombre', '55555555-M', '606000005', 'raul@gmail.com', 'Si', '1');

/*ALTER TABLE socio ADD activo enum ("0","1") not null AFTER recibir_info;*/

/* 18----------------------*/
create table ventasocio (
    id_ventasocio int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref         varchar (10) unique,
    id_empleado int not null,
    id_socio    int not null,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,  /* Marca la hora*/   /* Fuente: https://planet.mysql.com/entry/?id=14656 */

    foreign key (id_empleado) references empleado(id_empleado) on update cascade on delete cascade,
    foreign key (id_socio) references socio(id_socio) on update cascade on delete cascade );

INSERT INTO `ventasocio` (`id_ventasocio`, `ref`, `id_empleado`, `id_socio`, `fecha`) VALUES
(1, 'VSO1', 3, 1, '2023-08-23 09:08:13'),
(2, 'VSO2', 3, 2, '2023-08-24 10:08:17'),
(3, 'VSO3', 3, 3, '2023-08-25 11:08:13'),
(4, 'VSO4', 4, 4, '2023-08-26 12:08:17'),
(5, 'VSO5', 4, 5, '2023-08-27 13:08:17');


/* 19----------------------*/

create table lineaventasocio(
    id_lineaventasocio int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) unique,
    id_ventasocio int not null,
    id_compraproveedor int not null,
    id_articulo int not null,
    unidades int not null,
    precioVenta DECIMAL (4,2) not null,

    foreign key (id_ventasocio) references ventasocio(id_ventasocio) on update cascade on delete cascade,
    foreign key (id_compraproveedor) references compraproveedor(id_compraproveedor) on update cascade on delete cascade,
    foreign key (id_articulo) references articulo(id_articulo) on update cascade on delete cascade
    
    );

INSERT INTO `lineaventasocio` (`id_lineaventasocio`, `ref`, `id_ventasocio`, `id_compraproveedor`, `id_articulo`, `unidades`, `precioVenta`) VALUES
(1, 'LCP1', 1, 1, 1, 8, '4.99'),
(2, 'LCP2', 2, 2, 2, 2, '5.99'),
(3, 'LCP3', 3, 3, 3, 4, '6.99'),
(4, 'LCP4', 4, 4, 4, 3, '3.99'),
(5, 'LCP5', 5, 5, 5, 3, '2.99'),
(6, 'LCP6', 1, 6, 6, 6, '5.99'),
(7, 'LCP7', 2, 7, 7, 4, '6.99'),
/*(8, 'LCP8', 3, 8, 8, 6, '7.99'),*/
(9, 'LCP9', 4, 9, 9, 5, '1.99'),
(10, 'LCP10', 5, 10, 10, 7, '2.99'),
(11, 'LCP11', 1, 1, 1, 4, '4.99'),
(12, 'LCP12', 2, 2, 2, 2, '5.99'),
(13, 'LCP13', 3, 3, 3, 3, '6.99'),
(14, 'LCP14', 4, 4, 4, 5, '3.99'),
(15, 'LCP15', 5, 5, 5, 2, '2.99');


/*20*/
create table devolucionSocio(
    id_devolucionsocio  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) default null,
    id_ventasocio      int not null,
    id_lineaventasocio int not null,
    unidades       int not null,  
    /*fecha         Date,  */
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,  /* Marca la hora*/  


    foreign key (id_ventasocio) references ventasocio(id_ventasocio) on update cascade on delete cascade,
    foreign key (id_lineaventasocio) references lineaventasocio(id_lineaventasocio) on update cascade on delete cascade
    );




create table bajaexistencias(
    id_bajaexistencias int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_empleado int not null,
    id_ubicacion int not null,
    id_lineacompraproveedor int not null, 
    unidades       int not null,  
   /* Fecha         Date,  */ 
        fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,  /* Marca la hora*/  

    foreign key (id_empleado) references empleado(id_empleado) on update cascade on delete cascade,
    foreign key (id_ubicacion) references ubicacion(id_ubicacion) on update cascade on delete cascade,
    foreign key (id_lineacompraproveedor) references lineacompraproveedor(id_lineacompraproveedor) on update cascade on delete cascade
);


/* Registro de los movimientos entre zonas 
create table movimientozonas(
    id_movimientozonas int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ref varchar(10) not null,
    id_articulo int not null,
    id_empleado int not null,  
    id_ubicacioninicial int not null,
    id_ubicacionfinal int not null,
    unidades       int not null,  
    motivo varchar(10) not null,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, 

    foreign key (id_articulo) references articulo(id_articulo) on update cascade on delete cascade,
    foreign key (id_empleado) references articulo(id_empleado) on update cascade on delete cascade,
    foreign key (id_ubicacioninicial) references ubicacion(id_ubicacion) on update cascade on delete cascade,
    foreign key (id_ubicacionfinal) references ubicacion(id_ubicacion) on update cascade on delete cascade
);
*/




/*Compramos los estuches*/
/* Los estuches no les metemos nuestras botellas de vino, ya vienen solo con el texto*/

drop table if exists estuche;
create table estuche(
    id_estuche INT AUTO_INCREMENT PRIMARY KEY,
    ref varchar (10) default null,
    nombretitulo varchar (50) not null,
    id_proveedor int not null,
    id_denominacion int not null,
    contenido varchar (150) not null,
    descripcion varchar (150) not null,

    /*contenido varchar (100) not null,
    preciocoste DECIMAL (4,2) not null,
    precioventa DECIMAL (4,2) not null,*/

    foreign key (id_proveedor) references proveedor(id_proveedor) on update cascade on delete cascade,
    foreign key (id_denominacion) references denominacion(id_denominacion) on update cascade on delete cascade

);

insert into estuche (id_estuche,ref,nombretitulo,id_proveedor,id_denominacion,contenido,descripcion,) 
        values (1,"EST1","JUVENTUD Ribera del Duero",1, 1, "Dos Mundos rosado 2020, Mediterraneo 2020, Dos Mundos 2018","Incluye dos vinos jóvenes (rosado y tinto) y un vino con crianza en barrica y botella, pero de duraciones menos largas que los otros tintos. Se resalta el contenido frutal de los vinos. ");



Bodega y Viñedos Milénico, SL
San Martín de Rubiales
09317 BURGOS- SPAIN
Tfn. + 34 695 382848
milenico@milenico.com




ALTER TABLE PROVEEEDOR ADD ref VARCHAR(10) AFTER id_proveedor;
ALTER TABLE articulo ADD rutaimagen VARCHAR(30) AFTER preciocoste;
ALTER TABLE proveedor ADD rutaimagen VARCHAR(30) AFTER nombre;




 ref VARCHAR(10) AS (CONCAT('ART','',id_articulo)) STORED;

 alter table articulo
    modify ref VARCHAR(10) AS (CONCAT('ART','',id_articulo)) STORED;


alter table compraproveedor
  modify fechacompra TIMESTAMP DEFAULT CURRENT_TIMESTAMP not null ON UPDATE CURRENT_TIMESTAMP;


/* ok */
ALTER TABLE formatocontenido CHANGE id_formato  id_formatocontenido INT NOT NULL;
ALTER TABLE articulo CHANGE id_formato  id_formatocontenido INT NOT NULL;



  preciocompramin DECIMAL (4,2) not null,
  preciocompramax DECIMAL (4,2) not null,
  precioventamin DECIMAL (4,2) not null,
  precioventamax DECIMAL (4,2) not null,


ALTER TABLE articulo ADD preciocompramin DECIMAL (4,2) not null AFTER maxtienda;
ALTER TABLE articulo ADD preciocompramax DECIMAL (4,2) not null AFTER preciocompramin;
ALTER TABLE articulo ADD precioventamin  DECIMAL (4,2) not null AFTER preciocompramax;
ALTER TABLE articulo ADD precioventamax  DECIMAL (4,2) not null AFTER precioventamin;