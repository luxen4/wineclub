-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-12-2023 a las 02:01:18
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.0.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `wineclub`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `articulo`
--

CREATE TABLE `articulo` (
  `id_articulo` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `id_tipouva` int(11) NOT NULL,
  `id_clasevino` int(11) NOT NULL,
  `id_proveedor` int(11) NOT NULL,
  `id_catalogacion` int(11) NOT NULL,
  `id_denominacion` int(11) NOT NULL,
  `id_empaquetado` int(11) NOT NULL,
  `id_formatocontenido` int(11) NOT NULL,
  `minalmacen` int(11) NOT NULL,
  `maxalmacen` int(11) NOT NULL,
  `mintienda` int(11) NOT NULL,
  `maxtienda` int(11) NOT NULL,
  `preciocompramin` decimal(4,2) NOT NULL,
  `preciocompramax` decimal(4,2) NOT NULL,
  `precioventamin` decimal(4,2) NOT NULL,
  `precioventamax` decimal(4,2) NOT NULL,
  `nombreimagen` varchar(50) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `articulo`
--

INSERT INTO `articulo` (`id_articulo`, `ref`, `id_tipouva`, `id_clasevino`, `id_proveedor`, `id_catalogacion`, `id_denominacion`, `id_empaquetado`, `id_formatocontenido`, `minalmacen`, `maxalmacen`, `mintienda`, `maxtienda`, `preciocompramin`, `preciocompramax`, `precioventamin`, `precioventamax`, `nombreimagen`, `activo`) VALUES
(1, 'ART00001', 1, 1, 1, 1, 1, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00001.jpg', '1'),
(2, 'ART00002', 1, 1, 1, 18, 1, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00002.jpg', '1'),
(3, 'ART00003', 1, 2, 6, 5, 2, 1, 7, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00003.jpg', '1'),
(4, 'ART00004', 17, 5, 4, 10, 8, 1, 8, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00004.jpg', '1'),
(5, 'ART00005', 1, 1, 3, 4, 2, 1, 9, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00005.jpg', '1'),
(6, 'ART00006', 8, 2, 4, 1, 8, 1, 8, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00006.jpg', '1'),
(7, 'ART00007', 1, 3, 5, 7, 2, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00007.jpg', '1'),
(8, 'ART00008', 17, 1, 2, 4, 2, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00008.jpg', '1'),
(9, 'ART00009', 1, 2, 5, 7, 2, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00009.jpg', '1'),
(10, 'ART00010', 3, 2, 7, 12, 2, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00010.jpg', '1'),
(11, 'ART00011', 5, 3, 9, 7, 2, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00011.jpg', '0'),
(12, 'ART00012', 17, 1, 10, 9, 1, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00012.jpg', '0'),
(13, 'ART00013', 14, 2, 15, 12, 15, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00013.jpg', '0'),
(14, 'ART00014', 19, 1, 16, 14, 15, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00014.jpg', '0'),
(15, 'ART00015', 23, 4, 17, 13, 3, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00015.jpg', '0'),
(16, 'ART00016', 2, 4, 12, 16, 13, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00016.jpg', '0'),
(17, 'ART00017', 18, 1, 13, 17, 14, 1, 3, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00017.jpg', '0'),
(18, 'ART00018', 1, 1, 5, 18, 2, 2, 2, 5, 25, 5, 10, '0.00', '0.00', '0.00', '0.00', 'art00018.jpg', '0'),
(19, 'ART00019', 1, 1, 18, 6, 2, 5, 12, 10, 20, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00019.jpg', '0'),
(20, 'ART00020', 1, 1, 18, 6, 16, 5, 13, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00020.jpg', '0'),
(21, 'ART00021', 1, 1, 18, 6, 16, 5, 14, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00021.jpg', '0'),
(22, 'ART00022', 1, 1, 19, 6, 3, 4, 15, 15, 50, 5, 50, '0.00', '0.00', '0.00', '0.00', 'art00022.jpg', '0'),
(23, 'ART00023', 1, 2, 20, 6, 17, 4, 15, 15, 50, 5, 50, '0.00', '0.00', '0.00', '0.00', 'art00023.jpg', '0'),
(24, 'ART00024', 24, 2, 21, 19, 18, 6, 17, 50, 100, 5, 12, '0.00', '0.00', '0.00', '0.00', 'art00024.jpg', '0'),
(25, 'ART00025', 25, 5, 22, 20, 19, 1, 3, 10, 20, 5, 20, '0.00', '0.00', '0.00', '0.00', 'art00025.jpg', '0'),
(28, 'ART00028', 1, 3, 23, 15, 20, 6, 17, 10, 20, 10, 20, '0.00', '0.00', '0.00', '0.00', 'art00028.jpg', '0'),
(29, 'ART00059', 26, 2, 24, 7, 21, 1, 19, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00059.jpg', '0'),
(30, 'ART00030', 27, 2, 25, 6, 22, 6, 17, 50, 100, 5, 15, '0.00', '0.00', '0.00', '0.00', 'art00030.jpg', '0'),
(31, 'ART00031', 22, 3, 26, 7, 23, 9, 17, 5, 25, 5, 10, '0.00', '0.00', '0.00', '0.00', 'art00031.jpg', '0'),
(32, 'ART00032', 28, 4, 12, 6, 24, 10, 20, 10, 100, 10, 25, '0.00', '0.00', '0.00', '0.00', 'art00032.jpg', '0'),
(33, 'ART00033', 29, 1, 21, 6, 23, 6, 17, 15, 50, 5, 50, '0.00', '0.00', '0.00', '0.00', 'art00033.jpg', '0'),
(34, 'ART00034', 29, 3, 21, 6, 23, 6, 17, 5, 100, 5, 100, '0.00', '0.00', '0.00', '0.00', 'art00034.jpg', '0'),
(35, 'ART00035', 5, 3, 9, 7, 2, 1, 3, 10, 75, 5, 75, '0.00', '0.00', '0.00', '0.00', 'art00035.jpg', '0'),
(36, 'ART00036', 14, 3, 13, 13, 14, 5, 12, 10, 75, 5, 25, '0.00', '0.00', '0.00', '0.00', 'art00036.jpg', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bajaexistencias`
--

CREATE TABLE `bajaexistencias` (
  `id_bajaexistencias` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `id_empleado` int(11) NOT NULL,
  `id_ubicacion` int(11) NOT NULL,
  `id_lineacompraproveedor` int(11) NOT NULL,
  `unidades` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bajaexistencias`
--

INSERT INTO `bajaexistencias` (`id_bajaexistencias`, `ref`, `id_empleado`, `id_ubicacion`, `id_lineacompraproveedor`, `unidades`, `fecha`) VALUES
(1, 'BAJEXIS1', 1, 1, 8, 4, '2023-09-27 22:59:45'),
(2, 'BAJEXIS2', 1, 1, 8, 4, '2023-09-27 23:03:30'),
(3, 'BAJEXIS3', 1, 1, 8, 4, '2023-09-27 23:06:04'),
(4, 'BAJEXIS4', 1, 2, 8, 4, '2023-09-27 23:06:24'),
(5, 'BAJEXIS5', 2, 1, 10, 2, '2023-10-22 21:27:37');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `catalogacion`
--

CREATE TABLE `catalogacion` (
  `id_catalogacion` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(20) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `catalogacion`
--

INSERT INTO `catalogacion` (`id_catalogacion`, `ref`, `nombre`, `activo`) VALUES
(1, 'CAT1', 'Reserva 2017', '1'),
(2, 'CAT2', 'Gran Reserva 2014', '1'),
(3, 'CAT3', 'Verdejo 2021', '1'),
(4, 'CAT4', 'Crianza 2019', '1'),
(5, 'CAT5', 'SEMIDULCE *C.V.C.', '0'),
(6, 'CAT6', 'Joven', '1'),
(7, 'CAT7', '2021', '1'),
(9, 'CAT9', '2019', '1'),
(10, 'CAT10', 'Clasico 2022', '1'),
(11, 'CAT11', 'Crianza Magnum 2018', '0'),
(12, 'CAT12', 'Chardonnay 2020', '1'),
(13, 'CAT13', 'Frizzante Moscato', '1'),
(14, 'CAT14', 'D.O. Jerez', '1'),
(15, 'CAT15', 'Carta Rosé', '1'),
(16, 'CAT16', 'Cava Ice', '0'),
(17, 'CAT17', 'Vermut Rojo', '0'),
(18, 'CAT18', 'Gran Reserva 2015', '1'),
(19, 'CAT19', 'Semidulce', '0'),
(20, 'CAT20', 'Walnut Brown', '1'),
(21, 'CAT21', 'GRAN DUQUE DE ALBA', '1'),
(22, 'CAT22', 'ROSÉ WINE', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clasevino`
--

CREATE TABLE `clasevino` (
  `id_clasevino` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(15) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clasevino`
--

INSERT INTO `clasevino` (`id_clasevino`, `ref`, `nombre`, `activo`) VALUES
(1, 'CLS1', 'TINTO', '1'),
(2, 'CLS2', 'BLANCO', '1'),
(3, 'CLS3', 'ROSADO', '1'),
(4, 'CLS4', 'ESPUMOSO', '1'),
(5, 'CLS5', 'GENEROSO', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compraproveedor`
--

CREATE TABLE `compraproveedor` (
  `id_compraproveedor` int(11) NOT NULL,
  `id_empleado` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `fechacompra` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `compraproveedor`
--

INSERT INTO `compraproveedor` (`id_compraproveedor`, `id_empleado`, `ref`, `fechacompra`) VALUES
(1, 1, 'CPRO1', '2023-09-27 09:45:06'),
(2, 1, 'CPRO2', '2023-10-27 10:03:28'),
(3, 1, 'CPRO3', '2023-11-27 11:19:02'),
(4, 1, 'CPRO4', '2023-12-27 11:44:27'),
(5, 1, 'CPRO5', '2023-08-28 10:02:39'),
(6, 1, 'CPRO6', '2023-10-01 20:53:55'),
(7, 1, 'CPRO7', '2023-10-02 15:10:49'),
(8, 1, 'CPRO8', '2023-10-22 21:31:38'),
(9, 1, 'CPRO9', '2023-10-29 18:56:19'),
(10, 1, 'CPRO10', '2023-10-29 18:56:28'),
(11, 1, 'CPRO11', '2023-10-29 19:01:18'),
(12, 1, 'CPRO12', '2023-12-13 02:08:25'),
(17, 1, 'CPRO17', '2023-12-15 00:24:42'),
(18, 1, 'CPRO18', '2023-12-15 00:25:00'),
(19, 1, 'CPRO19', '2023-12-15 00:39:36'),
(20, 1, 'CPRO20', '2023-12-15 00:46:04');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `denominacion`
--

CREATE TABLE `denominacion` (
  `id_denominacion` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(30) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `denominacion`
--

INSERT INTO `denominacion` (`id_denominacion`, `ref`, `nombre`, `activo`) VALUES
(1, 'DEN1', 'D.O. Ribera del Duero', '0'),
(2, 'DEN2', 'D.O. Ca Rioja', '0'),
(3, 'DEN3', 'D.O. Valdepeñas', '1'),
(4, 'DEN4', 'D.O. Bierzo', '0'),
(5, 'DEN5', 'D.O. Cariñena', '1'),
(6, 'DEN6', 'D.O. Ribeiro', '1'),
(7, 'DEN7', 'D.O. La Mancha', '1'),
(8, 'DEN8', 'D.O. Ca Rueda', '1'),
(9, 'DEN9', 'D.O. Jumilla', '0'),
(10, 'DEN10', 'D.O. Somontano', '0'),
(12, 'DEN12', 'D.O. Toro', '0'),
(13, 'DEN13', 'D.O. Cava', '1'),
(14, 'DEN14', 'D.O. Jerez', '0'),
(15, 'DEN15', 'Pedro Ximenez', '1'),
(16, 'DEN16', 'Vinos de España Tinto', '1'),
(17, 'DEN17', 'D.O. Protegida Cebreros', '1'),
(18, 'DEN18', 'D.O. Cataluña', '1'),
(19, 'DEN19', 'Jerez-Xérès-Sherry', '1'),
(20, 'DEN20', 'D. O. Cigales', '0'),
(21, 'DEN21', 'D.O. Chianti DOCG', '1'),
(22, 'DEN22', 'D.O. Campo de Borja', '0'),
(23, 'DEN23', 'Sin Denominación', '0'),
(24, 'DEN24', 'Cava Rosado Brut', '1'),
(25, 'DEN25', 'D. O. Rueda', '1'),
(26, 'DEN26', 'Jerez', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `devolucionproveedor`
--

CREATE TABLE `devolucionproveedor` (
  `id_devolucionproveedor` int(11) NOT NULL,
  `id_empleado` int(11) NOT NULL,
  `id_lineacompraproveedor` int(11) NOT NULL,
  `unidades` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `devolucionproveedor`
--

INSERT INTO `devolucionproveedor` (`id_devolucionproveedor`, `id_empleado`, `id_lineacompraproveedor`, `unidades`, `fecha`) VALUES
(1, 1, 8, 10, '2023-09-28 15:30:10');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `devolucionsocio`
--

CREATE TABLE `devolucionsocio` (
  `id_devolucionsocio` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `id_ventasocio` int(11) NOT NULL,
  `id_lineaventasocio` int(11) NOT NULL,
  `unidades` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `devolucionsocio`
--

INSERT INTO `devolucionsocio` (`id_devolucionsocio`, `ref`, `id_ventasocio`, `id_lineaventasocio`, `unidades`, `fecha`) VALUES
(1, 'DEVSOC1', 1, 2, 2, '2023-09-28 21:10:50'),
(2, 'DEVSOC2', 5, 11, 4, '2023-10-23 13:02:48'),
(3, 'DEVSOC3', 5, 11, 3, '2023-10-23 13:03:13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empaquetado`
--

CREATE TABLE `empaquetado` (
  `id_empaquetado` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empaquetado`
--

INSERT INTO `empaquetado` (`id_empaquetado`, `ref`, `nombre`, `activo`) VALUES
(1, 'EMP1', 'Botella', '1'),
(2, 'EMP2', 'Caja 6 Botellas', '1'),
(4, 'EMP4', 'Brick', '1'),
(5, 'EMP5', 'Bag in Box', '1'),
(6, 'EMP6', 'Lata', '1'),
(7, 'EMP7', 'Caja 24 latas', '0'),
(9, 'EMP9', 'Caja 12 latas', '0'),
(10, 'EMP10', 'Pack 3 Botellitas', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `id_empleado` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(20) NOT NULL,
  `apellido1` varchar(50) NOT NULL,
  `apellido2` varchar(50) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `email` varchar(45) NOT NULL,
  `sexo` enum('Hombre','Mujer') NOT NULL,
  `fechanacimiento` date DEFAULT NULL,
  `usuario` varchar(15) NOT NULL,
  `contrasena` varchar(65) NOT NULL,
  `id_rollempleado` int(11) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`id_empleado`, `ref`, `nombre`, `apellido1`, `apellido2`, `telefono`, `email`, `sexo`, `fechanacimiento`, `usuario`, `contrasena`, `id_rollempleado`, `activo`) VALUES
(1, 'EMP1', 'Adrián', 'Laya', 'García', '637117965', 'superlaya50@gmail.com', 'Hombre', '1982-06-16', 'adrian', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 1, '1'),
(2, 'EMP2', 'Gemma', 'Mago', 'Martínez', '000000001', 'gemma@gmail.com', 'Mujer', '1980-06-16', 'gemma', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 2, '1'),
(4, 'EMP4', 'Borja', 'García', 'Barquín', '000000003', 'borja@gmail.com', 'Hombre', '2000-01-24', 'borja', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 3, '1'),
(5, 'EMP5', 'Aoito', 'Pérez', 'Martínez', '606999999', 'aoito@aoito.com', 'Hombre', '1970-04-26', 'aoito', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 3, '1'),
(6, 'EMP6', 'Eduardo', 'Hormilla', 'Urraca', '000000001', 'edu@gmail.com', 'Hombre', '2023-12-10', 'eduardo', '6QRNJHgiEptBfbMM4eaHEFkCctQ=', 3, '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `formatocontenido`
--

CREATE TABLE `formatocontenido` (
  `id_formatocontenido` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `nombre` varchar(15) NOT NULL,
  `contenido` varchar(15) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `formatocontenido`
--

INSERT INTO `formatocontenido` (`id_formatocontenido`, `ref`, `nombre`, `contenido`, `activo`) VALUES
(1, 'CON1', 'Benjamín', '187.5 cc', '1'),
(2, 'CON2', '3/8', '375 cc', '1'),
(3, 'CON3', 'Estandar 3/4', '750 cc', '1'),
(6, 'CON6', 'Réhoboam', '4.5 L', '1'),
(7, 'CON7', 'Mathusalem', '6 L', '0'),
(8, 'CON8', 'Salmanazar', '9 L', '0'),
(9, 'CON9', 'Balthasar', '12 L', '1'),
(10, 'CON10', 'Nabuchodonosor', '15 L', '0'),
(11, 'CON11', 'Salomón', '18 L', '1'),
(12, 'CON12', '15L', 'ssd', '1'),
(13, 'CON13', '3L', 'uio', '1'),
(14, 'CON14', '5L', 'aaa', '1'),
(15, 'CON15', '1L', 'eeee', '1'),
(16, 'CON16', 'Magnum', '1.5L', '1'),
(17, 'CON17', '250 ml.', '250 ml. ', '1'),
(18, 'CON18', '700 ml.', '700 ml.', '1'),
(19, 'CON19', 'Fiasco', '0.75 lt.', '0'),
(20, 'CON20', '300 ml.', '300 ml.', '1'),
(21, 'CON21', 'gfbfg', '', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lineacompraproveedor`
--

CREATE TABLE `lineacompraproveedor` (
  `id_lineacompraproveedor` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `id_compraproveedor` int(11) NOT NULL,
  `id_articulo` int(11) NOT NULL,
  `existencias` int(11) NOT NULL,
  `preciocoste` decimal(7,2) NOT NULL,
  `precioventa` decimal(7,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lineacompraproveedor`
--

INSERT INTO `lineacompraproveedor` (`id_lineacompraproveedor`, `ref`, `id_compraproveedor`, `id_articulo`, `existencias`, `preciocoste`, `precioventa`) VALUES
(1, 'LCP1', 1, 1, 100, '9.50', '11.49'),
(2, 'LCP2', 2, 2, 100, '16.50', '19.49'),
(3, 'LCP3', 3, 13, 100, '2.00', '3.57'),
(4, 'LCP4', 3, 10, 100, '7.50', '12.35'),
(5, 'LCP5', 3, 12, 100, '32.50', '39.35'),
(6, 'LCP6', 3, 16, 100, '6.50', '9.70'),
(7, 'LCP7', 4, 5, 100, '6.00', '8.95'),
(8, 'LCP8', 4, 3, 100, '5.50', '7.30'),
(9, 'LCP9', 4, 15, 100, '1.10', '2.09'),
(10, 'LCP10', 5, 1, 50, '1.00', '2.49'),
(11, 'LCP11', 6, 35, 100, '4.00', '6.94'),
(12, 'LCP12', 7, 1, 75, '5.00', '9.01'),
(13, 'LCP13', 8, 30, 10, '3.00', '4.00'),
(14, 'LCP14', 9, 19, 8, '2.00', '4.99'),
(15, 'LCP15', 11, 19, 25, '2.00', '3.09'),
(16, 'LCP16', 12, 6, 100, '1.00', '2.00'),
(17, 'LCP17', 17, 1, 3, '2.00', '4.00'),
(18, 'LCP18', 18, 1, 2, '3.00', '6.00'),
(19, 'LCP19', 19, 3, 8, '3.00', '8.00'),
(20, 'LCP20', 20, 5, 3, '5.00', '4.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lineaventasocio`
--

CREATE TABLE `lineaventasocio` (
  `id_lineaventasocio` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `id_ventasocio` int(11) NOT NULL,
  `id_compraproveedor` int(11) NOT NULL,
  `id_articulo` int(11) NOT NULL,
  `unidades` int(11) NOT NULL,
  `precioVenta` decimal(4,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lineaventasocio`
--

INSERT INTO `lineaventasocio` (`id_lineaventasocio`, `ref`, `id_ventasocio`, `id_compraproveedor`, `id_articulo`, `unidades`, `precioVenta`) VALUES
(1, 'LVP1', 1, 2, 1, 7, '12.49'),
(2, 'LVP2', 1, 2, 2, 6, '19.49'),
(3, 'LVP3', 2, 3, 2, 3, '19.49'),
(4, 'LVP4', 2, 3, 13, 2, '3.57'),
(5, 'LVP5', 2, 3, 10, 6, '8.90'),
(6, 'LVP6', 2, 3, 12, 1, '39.35'),
(7, 'LVP7', 2, 3, 16, 2, '9.70'),
(8, 'LVP8', 3, 4, 1, 2, '2.49'),
(9, 'LVP9', 3, 4, 3, 4, '7.30'),
(10, 'LVP10', 4, 8, 30, 4, '4.00'),
(11, 'LVP11', 5, 2, 1, 7, '12.49'),
(12, 'LVP12', 5, 2, 2, 4, '19.49'),
(13, 'LVP13', 6, 3, 12, 3, '39.35'),
(14, 'LVP14', 7, 3, 12, 1, '39.35'),
(15, 'LVP15', 8, 4, 15, 1, '2.09'),
(16, 'LVP16', 9, 3, 12, 1, '39.35'),
(17, 'LVP17', 10, 3, 12, 1, '39.35'),
(18, 'LVP18', 11, 3, 16, 1, '9.70'),
(19, 'LVP19', 12, 3, 12, 1, '39.35'),
(20, 'LVP20', 13, 3, 12, 1, '39.35'),
(21, 'LVP21', 14, 3, 12, 1, '39.35'),
(22, 'LVP22', 15, 3, 16, 1, '9.70'),
(23, 'LVP23', 16, 4, 15, 1, '2.09'),
(24, 'LVP24', 17, 3, 16, 1, '9.70'),
(25, 'LVP25', 18, 4, 15, 1, '2.09'),
(26, 'LVP26', 19, 3, 16, 1, '9.70'),
(27, 'LVP27', 20, 3, 12, 1, '39.35'),
(28, 'LVP28', 21, 1, 1, 1, '11.49'),
(29, 'LVP29', 22, 2, 1, 1, '11.49'),
(30, 'LVP30', 23, 2, 1, 2, '2.49'),
(31, 'LVP31', 23, 2, 2, 3, '19.49'),
(32, 'LVP32', 24, 2, 3, 2, '7.30'),
(33, 'LVP33', 24, 2, 2, 3, '19.49'),
(34, 'LVP34', 25, 2, 2, 3, '19.49'),
(35, 'LVP35', 26, 2, 2, 2, '19.49'),
(36, 'LVP36', 27, 2, 2, 3, '19.49'),
(37, 'LVP37', 28, 9, 2, 2, '19.49'),
(38, 'LVP38', 28, 9, 19, 3, '4.99'),
(39, 'LVP39', 29, 11, 19, 3, '3.09'),
(40, 'LVP40', 30, 11, 19, 2, '3.09'),
(41, 'LVP41', 31, 5, 1, 6, '2.49'),
(42, 'LVP42', 32, 5, 1, 6, '2.49'),
(43, 'LVP43', 33, 9, 1, 5, '2.49'),
(44, 'LVP44', 34, 5, 1, 3, '2.49'),
(45, 'LVP45', 35, 5, 1, 2, '2.49'),
(46, 'LVP46', 36, 5, 1, 3, '2.49'),
(47, 'LVP47', 37, 5, 1, 2, '11.49'),
(48, 'LVP48', 37, 5, 1, 4, '2.49'),
(49, 'LVP49', 39, 12, 6, 2, '2.00'),
(50, 'LVP50', 40, 12, 12, 2, '39.35'),
(51, 'LVP51', 40, 12, 15, 3, '2.09'),
(52, 'LVP52', 40, 12, 6, 2, '2.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `id_proveedor` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `nombre` varchar(25) NOT NULL,
  `direccion` varchar(80) NOT NULL,
  `localidad` varchar(25) NOT NULL,
  `provincia` varchar(25) NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `email` varchar(65) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`id_proveedor`, `ref`, `nombre`, `direccion`, `localidad`, `provincia`, `telefono`, `email`, `activo`) VALUES
(1, 'PRO1', 'PAGOS DEL REY', 'C. Somillo (Paraje La Balsa), 01309', 'Bilar', 'Álava', '945600693', 'https://www.altosderioja.com/', '1'),
(2, 'PRO2', 'MARQUÉS DE CÁCERES', 'Av. Fuenmayor, 11, 26350', 'Cenicero', 'La Rioja', '941454000', 'admin@marquesdecaceres.com', '1'),
(3, 'PRO3', 'VIÑA POMAL', 'C. Estación, s/n, 26200', 'Haro', 'La Rioja', '941310147', 'http://www.bodegasbilbainas.com/', '1'),
(4, 'PRO4', 'SANZ', 'Ctra. N-VI km 170,5', 'Rueda', 'Valladolid', '983868100', 'vinossanz@vinossanz.com', '1'),
(5, 'PRO5', 'CUNE', 'Carretera de Logroño – Laguardia Km 4,8, 01300', 'Laguardia', 'Álava', '945625255', 'rgpd@cvne.com', '1'),
(6, 'PRO6', 'RAMÓN BILBAO', 'Av. Santo Domingo de la Calzada, 34, 26200', 'Haro', 'La Rioja', '941310316', 'bodegasramonbilbao.es', '1'),
(7, 'PRO7', 'MARQUÉS DE RISCAL', 'Calle Torrea, 1', 'Eltziego', 'Álava', '945 60 60 00', 'marquesderiscal@marriott.com', '1'),
(8, 'PRO8', 'Bodega y Viñedos Milénico', '*', 'San Martín de Rubiales, 0', 'Burgos', '+ 34 695 382848', 'milenico@milenico.com', '0'),
(9, 'PRO9', 'CAMPO VIEJO', 'Cam. de Lapuebla de Labarca, 50, 26007', 'Logroño', 'La Rioja', '941279900', 'campoviejo.com', '1'),
(10, 'PRO10', 'Emilio Moro SL', '*', '*', '*', '*', '*', '0'),
(12, 'PRO12', 'FREIXENET, S.A.', '*', '*', '*', '*', '*', '1'),
(13, 'PRO13', 'LUSTRAU', '*', '*', '*', '*', '*', '0'),
(14, 'PRO14', 'PUENTE DE PIEDRA', '*', '**', '*', '*', '*', '0'),
(15, 'PRO15', 'VALL DE JUY', '*', '*', '*', '*', '*', '1'),
(16, 'PRO16', 'GONZALEZ BYASS', '*', '*', '*', '*', '*', '1'),
(17, 'PRO17', 'FELIX SOLIS. S.L.', 'Autovía del Sur, Km. 199, 13300', 'VALDEPEÑAS', 'Ciudad Real', '*', '*', '1'),
(18, 'PRO18', 'LOS CORZOS', '*', '*', '*', '*', '*', '1'),
(19, 'PRO19', 'GARCÍA CARRIÓN', '*', '*', '*', '*', '*', '1'),
(20, 'PRO20', 'CUMBRES DE GREDOS', '*', '*', '*', '*', '*', '1'),
(21, 'PRO21', 'BACH EXTRÍSIMO', '*', '*', '*', '*', '*', '1'),
(22, 'PRO22', 'Bodegas Williams & Humber', '*', '*', '**', '*', '*', '1'),
(23, 'PRO23', 'BODEGAS PEÑASCAL S.A', '*', '*', '*', '*', '*', '1'),
(24, 'PRO24', 'Castelli del Grevepesa Ca', '*', '*', '*', '*', '*', '1'),
(25, 'PRO25', 'Bodegas Aragonesas', 'Carr. de Magallón a la Almunia, S/N,', 'Fuendejalón', 'Zaragoza', '976 86 21 53', 'enoturismo@bodegasaragonesas.com', '0'),
(26, 'PRO26', 'BORN ROSÉ Barcelona', '*', '*', '*', '*', '*', '1'),
(27, 'PRO27', 'CAMPO VIEJOs', 'Cam. de Lapuebla de Labarca, 50, 26007', 'Logroño', 'La Rioja', '941279900', 'campoviejo.com', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rollempleado`
--

CREATE TABLE `rollempleado` (
  `id_rollempleado` int(11) NOT NULL,
  `ref` varchar(10) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `rollempleado`
--

INSERT INTO `rollempleado` (`id_rollempleado`, `ref`, `nombre`, `activo`) VALUES
(1, 'Roll1', 'Dueño', '1'),
(2, 'Roll2', 'Encargado', '1'),
(3, 'Roll3', 'Dependiente', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `socio`
--

CREATE TABLE `socio` (
  `id_socio` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(20) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `provincia` varchar(50) NOT NULL,
  `sexo` enum('Hombre','Mujer') NOT NULL,
  `nif` varchar(12) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `email` varchar(25) NOT NULL,
  `recibir_info` enum('Si','No') NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `socio`
--

INSERT INTO `socio` (`id_socio`, `ref`, `nombre`, `apellidos`, `localidad`, `provincia`, `sexo`, `nif`, `telefono`, `email`, `recibir_info`, `activo`) VALUES
(1, 'SOC1', 'Jorge', 'Martinez Corada', 'Logroño', 'La Rioja', 'Hombre', '33333333-R', '606000001', 'corada@gmail.com', 'Si', '0'),
(2, 'SOC2', 'Javier', 'Hernán Martínez', 'Logroño', 'La Rioja', 'Hombre', '22222222-R', '606000002', 'hernan@gmail.com', 'Si', '1'),
(3, 'SOC3', 'Tirso', 'Salazar Arregui', 'Logroño', 'La Rioja', 'Hombre', '33333333-A', '606000003', 'tirso@gmail.com', 'No', '0'),
(4, 'SOC4', 'Álvaro Javier', 'García Álvarez', 'Logroño', 'La Rioja', 'Hombre', '44444444-G', '606000004', 'alvaro@gmail.com', 'Si', '1'),
(5, 'SOC5', 'Raul', 'Moreno Espinosa', 'Santander', 'Cantabria', 'Hombre', '55555555-M', '606000005', 'raul@gmail.com', 'Si', '1'),
(6, 'CLS6', 'Paco', 'Omaita Moranco', 'Écija', 'Sevilla', 'Hombre', '16600000W', '606999888', 'paco@gmail.com', 'Si', '1'),
(7, '', '', '', 'Écija', 'Sevilla', 'Hombre', '16600000W', '606999888', 'paco@gmail.com', 'Si', '1'),
(8, 'CLS8', 'Paco', 'Omaita Moranco', 'Écija', 'Sevilla', 'Hombre', '16600000W', '606999888', 'paco@gmail.com', 'Si', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipouva`
--

CREATE TABLE `tipouva` (
  `id_tipouva` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(50) NOT NULL,
  `id_variedaduva` int(11) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipouva`
--

INSERT INTO `tipouva` (`id_tipouva`, `ref`, `nombre`, `id_variedaduva`, `activo`) VALUES
(1, 'TU1', 'Tempranillo', 1, '0'),
(2, 'TU2', 'Garnacha', 1, '1'),
(3, 'TU3', 'Mencía', 1, '1'),
(4, 'TU4', 'Monastrell', 1, '0'),
(5, 'TU5', 'Cabernet Sauvignon', 1, '1'),
(6, 'TU6', 'Merlot', 1, '1'),
(7, 'TU7', 'Syrah', 1, '0'),
(8, 'TU8', 'Verdejo', 2, '1'),
(9, 'TU9', 'Alvariño', 2, '1'),
(10, 'TU10', 'Godello', 2, '0'),
(11, 'TU11', 'Viura', 2, '0'),
(12, 'TU12', 'Sauvignon', 2, '0'),
(13, 'TU13', 'Macabeo', 2, '0'),
(14, 'TU14', 'Chardonnay', 2, '1'),
(15, 'TU15', 'Riesling', 2, '0'),
(17, 'TU17', 'Tempranillo, Graciano y Mazuelo', 1, '1'),
(18, 'TU18', 'Palomino y Pedro Ximenez', 1, '1'),
(19, 'TU19', 'Pedro Ximenez', 1, '1'),
(22, 'TU22', 'Garnacha y Tempranillo', 1, '1'),
(23, 'TU23', 'Moscatel', 2, '0'),
(24, 'TU24', 'Xarel-lo, Parellada, Macabeo y Muscat', 2, '1'),
(25, 'TU25', 'Palomino, Pedro Ximénez y Moscatel', 1, '1'),
(26, 'TU26', 'Sangiovese (85%) Merlot (10%) Otras Uvas Frutos ro', 1, '0'),
(27, 'TU27', 'Chardonnay y Viura', 2, '1'),
(28, 'TU28', 'Trepat', 1, '0'),
(29, 'TU29', 'cabernet sauvignon merlot tempranillo', 1, '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ubicacion`
--

CREATE TABLE `ubicacion` (
  `id_ubicacion` int(11) NOT NULL,
  `nombre` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ubicacion`
--

INSERT INTO `ubicacion` (`id_ubicacion`, `nombre`) VALUES
(1, 'Almacén'),
(2, 'Tienda');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ubicacionlineacompraproveedor`
--

CREATE TABLE `ubicacionlineacompraproveedor` (
  `id_ubicacionlinearcompraproveedor` int(11) NOT NULL,
  `id_ubicacion` int(11) NOT NULL,
  `id_lineacompraproveedor` int(11) NOT NULL,
  `id_articulo` int(11) NOT NULL,
  `existencias` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ubicacionlineacompraproveedor`
--

INSERT INTO `ubicacionlineacompraproveedor` (`id_ubicacionlinearcompraproveedor`, `id_ubicacion`, `id_lineacompraproveedor`, `id_articulo`, `existencias`) VALUES
(1, 1, 1, 1, 33),
(2, 2, 1, 1, 0),
(123, 1, 2, 2, 73),
(124, 2, 2, 2, 0),
(125, 1, 3, 13, 73),
(126, 2, 3, 13, 25),
(127, 1, 4, 10, 75),
(128, 2, 4, 10, 19),
(129, 1, 5, 12, 79),
(130, 2, 5, 12, 8),
(131, 1, 6, 16, 75),
(132, 2, 6, 16, 19),
(133, 1, 7, 5, 100),
(134, 2, 7, 5, 0),
(135, 1, 8, 3, 32),
(136, 2, 8, 3, 22),
(137, 1, 9, 15, 75),
(138, 2, 9, 15, 19),
(141, 1, 10, 1, 125),
(142, 2, 10, 1, 0),
(143, 1, 11, 35, 82),
(144, 2, 11, 35, 18),
(145, 1, 12, 1, 75),
(146, 2, 12, 1, 0),
(147, 1, 13, 30, 0),
(148, 2, 13, 30, 8),
(149, 1, 14, 19, 5),
(150, 2, 14, 19, 0),
(151, 1, 15, 19, 20),
(152, 2, 15, 19, 0),
(153, 1, 16, 6, 75),
(154, 2, 16, 6, 21),
(155, 1, 17, 1, 3),
(156, 2, 17, 1, 0),
(157, 1, 18, 1, 0),
(158, 2, 18, 1, 0),
(159, 1, 19, 3, 5),
(160, 2, 19, 3, 3),
(161, 1, 20, 5, 3),
(162, 2, 20, 5, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `variedaduva`
--

CREATE TABLE `variedaduva` (
  `id_variedaduva` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `nombre` varchar(20) NOT NULL,
  `activo` enum('0','1') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `variedaduva`
--

INSERT INTO `variedaduva` (`id_variedaduva`, `ref`, `nombre`, `activo`) VALUES
(1, 'VU1', 'Tintas', '1'),
(2, 'VU2', 'Blancas', '1'),
(3, 'VU3', 'rtyrtyrt', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventasocio`
--

CREATE TABLE `ventasocio` (
  `id_ventasocio` int(11) NOT NULL,
  `ref` varchar(10) DEFAULT NULL,
  `id_empleado` int(11) NOT NULL,
  `id_socio` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventasocio`
--

INSERT INTO `ventasocio` (`id_ventasocio`, `ref`, `id_empleado`, `id_socio`, `fecha`) VALUES
(1, 'VSO1', 1, 5, '2023-09-27 10:10:43'),
(2, 'VSO2', 4, 1, '2023-10-01 22:07:59'),
(3, 'VSO3', 4, 5, '2023-10-22 21:30:25'),
(4, 'VSO4', 4, 1, '2023-10-22 21:32:46'),
(5, 'VSO5', 4, 5, '2023-10-23 13:00:35'),
(6, 'VSO6', 4, 5, '2023-10-26 21:45:54'),
(7, 'VSO7', 4, 8, '2023-10-26 22:19:24'),
(8, 'VSO8', 4, 4, '2023-10-26 23:17:36'),
(9, 'VSO9', 4, 4, '2023-10-26 23:38:14'),
(10, 'VSO10', 4, 5, '2023-10-26 23:46:25'),
(11, 'VSO11', 4, 5, '2023-10-26 23:47:54'),
(12, 'VSO12', 4, 5, '2023-10-26 23:51:12'),
(13, 'VSO13', 4, 4, '2023-10-26 23:51:34'),
(14, 'VSO14', 4, 6, '2023-10-26 23:55:48'),
(15, 'VSO15', 4, 5, '2023-10-27 00:00:30'),
(16, 'VSO16', 4, 5, '2023-10-27 00:02:27'),
(17, 'VSO17', 4, 5, '2023-10-27 00:05:51'),
(18, 'VSO18', 4, 5, '2023-10-27 00:06:51'),
(19, 'VSO19', 4, 5, '2023-10-27 00:08:42'),
(20, 'VSO20', 4, 5, '2023-10-28 19:21:30'),
(21, 'VSO21', 4, 5, '2023-10-29 12:04:05'),
(22, 'VSO22', 4, 3, '2023-10-29 12:22:35'),
(23, 'VSO23', 4, 4, '2023-10-29 12:23:55'),
(24, 'VSO24', 4, 6, '2023-10-29 18:44:44'),
(25, 'VSO25', 4, 8, '2023-10-29 18:47:25'),
(26, 'VSO26', 4, 3, '2023-10-29 18:51:16'),
(27, 'VSO27', 4, 1, '2023-10-29 18:52:20'),
(28, 'VSO28', 4, 5, '2023-10-29 18:58:49'),
(29, 'VSO29', 4, 5, '2023-10-29 19:02:01'),
(30, 'VSO30', 4, 5, '2023-10-29 19:05:28'),
(31, 'VSO31', 4, 4, '2023-10-29 19:10:33'),
(32, 'VSO32', 4, 8, '2023-10-29 19:13:30'),
(33, 'VSO33', 4, 3, '2023-10-29 19:42:29'),
(34, 'VSO34', 4, 4, '2023-10-29 19:44:34'),
(35, 'VSO35', 4, 4, '2023-10-29 19:48:21'),
(36, 'VSO36', 4, 1, '2023-10-29 19:50:18'),
(37, 'VSO37', 4, 4, '2023-10-29 20:24:01'),
(38, 'VSO38', 1, 2, '2023-12-13 02:09:05'),
(39, 'VSO39', 1, 3, '2023-12-13 02:12:21'),
(40, 'VSO40', 1, 1, '2023-12-13 02:13:33');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `articulo`
--
ALTER TABLE `articulo`
  ADD PRIMARY KEY (`id_articulo`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_tipouva` (`id_tipouva`),
  ADD KEY `id_clasevino` (`id_clasevino`),
  ADD KEY `id_proveedor` (`id_proveedor`),
  ADD KEY `id_catalogacion` (`id_catalogacion`),
  ADD KEY `id_denominacion` (`id_denominacion`),
  ADD KEY `id_empaquetado` (`id_empaquetado`),
  ADD KEY `id_formatocontenido` (`id_formatocontenido`);

--
-- Indices de la tabla `bajaexistencias`
--
ALTER TABLE `bajaexistencias`
  ADD PRIMARY KEY (`id_bajaexistencias`),
  ADD KEY `id_empleado` (`id_empleado`),
  ADD KEY `id_ubicacion` (`id_ubicacion`),
  ADD KEY `id_lineacompraproveedor` (`id_lineacompraproveedor`);

--
-- Indices de la tabla `catalogacion`
--
ALTER TABLE `catalogacion`
  ADD PRIMARY KEY (`id_catalogacion`),
  ADD UNIQUE KEY `nombre` (`nombre`),
  ADD UNIQUE KEY `ref` (`ref`);

--
-- Indices de la tabla `clasevino`
--
ALTER TABLE `clasevino`
  ADD PRIMARY KEY (`id_clasevino`),
  ADD UNIQUE KEY `nombre` (`nombre`),
  ADD UNIQUE KEY `ref` (`ref`);

--
-- Indices de la tabla `compraproveedor`
--
ALTER TABLE `compraproveedor`
  ADD PRIMARY KEY (`id_compraproveedor`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_empleado` (`id_empleado`);

--
-- Indices de la tabla `denominacion`
--
ALTER TABLE `denominacion`
  ADD PRIMARY KEY (`id_denominacion`),
  ADD UNIQUE KEY `nombre` (`nombre`),
  ADD UNIQUE KEY `ref` (`ref`);

--
-- Indices de la tabla `devolucionproveedor`
--
ALTER TABLE `devolucionproveedor`
  ADD PRIMARY KEY (`id_devolucionproveedor`),
  ADD KEY `id_empleado` (`id_empleado`),
  ADD KEY `id_lineacompraproveedor` (`id_lineacompraproveedor`);

--
-- Indices de la tabla `devolucionsocio`
--
ALTER TABLE `devolucionsocio`
  ADD PRIMARY KEY (`id_devolucionsocio`),
  ADD KEY `id_ventasocio` (`id_ventasocio`),
  ADD KEY `id_lineaventasocio` (`id_lineaventasocio`);

--
-- Indices de la tabla `empaquetado`
--
ALTER TABLE `empaquetado`
  ADD PRIMARY KEY (`id_empaquetado`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`id_empleado`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_rollempleado` (`id_rollempleado`);

--
-- Indices de la tabla `formatocontenido`
--
ALTER TABLE `formatocontenido`
  ADD PRIMARY KEY (`id_formatocontenido`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `lineacompraproveedor`
--
ALTER TABLE `lineacompraproveedor`
  ADD PRIMARY KEY (`id_lineacompraproveedor`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_compraproveedor` (`id_compraproveedor`),
  ADD KEY `id_articulo` (`id_articulo`);

--
-- Indices de la tabla `lineaventasocio`
--
ALTER TABLE `lineaventasocio`
  ADD PRIMARY KEY (`id_lineaventasocio`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_ventasocio` (`id_ventasocio`),
  ADD KEY `id_compraproveedor` (`id_compraproveedor`),
  ADD KEY `id_articulo` (`id_articulo`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`id_proveedor`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `rollempleado`
--
ALTER TABLE `rollempleado`
  ADD PRIMARY KEY (`id_rollempleado`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `socio`
--
ALTER TABLE `socio`
  ADD PRIMARY KEY (`id_socio`),
  ADD UNIQUE KEY `ref` (`ref`);

--
-- Indices de la tabla `tipouva`
--
ALTER TABLE `tipouva`
  ADD PRIMARY KEY (`id_tipouva`),
  ADD UNIQUE KEY `nombre` (`nombre`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_variedaduva` (`id_variedaduva`);

--
-- Indices de la tabla `ubicacion`
--
ALTER TABLE `ubicacion`
  ADD PRIMARY KEY (`id_ubicacion`);

--
-- Indices de la tabla `ubicacionlineacompraproveedor`
--
ALTER TABLE `ubicacionlineacompraproveedor`
  ADD PRIMARY KEY (`id_ubicacionlinearcompraproveedor`),
  ADD KEY `id_ubicacion` (`id_ubicacion`),
  ADD KEY `id_lineacompraproveedor` (`id_lineacompraproveedor`),
  ADD KEY `id_articulo` (`id_articulo`);

--
-- Indices de la tabla `variedaduva`
--
ALTER TABLE `variedaduva`
  ADD PRIMARY KEY (`id_variedaduva`);

--
-- Indices de la tabla `ventasocio`
--
ALTER TABLE `ventasocio`
  ADD PRIMARY KEY (`id_ventasocio`),
  ADD UNIQUE KEY `ref` (`ref`),
  ADD KEY `id_empleado` (`id_empleado`),
  ADD KEY `id_socio` (`id_socio`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `articulo`
--
ALTER TABLE `articulo`
  MODIFY `id_articulo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT de la tabla `bajaexistencias`
--
ALTER TABLE `bajaexistencias`
  MODIFY `id_bajaexistencias` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `catalogacion`
--
ALTER TABLE `catalogacion`
  MODIFY `id_catalogacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de la tabla `clasevino`
--
ALTER TABLE `clasevino`
  MODIFY `id_clasevino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `compraproveedor`
--
ALTER TABLE `compraproveedor`
  MODIFY `id_compraproveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `denominacion`
--
ALTER TABLE `denominacion`
  MODIFY `id_denominacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de la tabla `devolucionproveedor`
--
ALTER TABLE `devolucionproveedor`
  MODIFY `id_devolucionproveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `devolucionsocio`
--
ALTER TABLE `devolucionsocio`
  MODIFY `id_devolucionsocio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `empaquetado`
--
ALTER TABLE `empaquetado`
  MODIFY `id_empaquetado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `id_empleado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `formatocontenido`
--
ALTER TABLE `formatocontenido`
  MODIFY `id_formatocontenido` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `lineacompraproveedor`
--
ALTER TABLE `lineacompraproveedor`
  MODIFY `id_lineacompraproveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT de la tabla `lineaventasocio`
--
ALTER TABLE `lineaventasocio`
  MODIFY `id_lineaventasocio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `id_proveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT de la tabla `rollempleado`
--
ALTER TABLE `rollempleado`
  MODIFY `id_rollempleado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `socio`
--
ALTER TABLE `socio`
  MODIFY `id_socio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `tipouva`
--
ALTER TABLE `tipouva`
  MODIFY `id_tipouva` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT de la tabla `ubicacion`
--
ALTER TABLE `ubicacion`
  MODIFY `id_ubicacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `ubicacionlineacompraproveedor`
--
ALTER TABLE `ubicacionlineacompraproveedor`
  MODIFY `id_ubicacionlinearcompraproveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;

--
-- AUTO_INCREMENT de la tabla `variedaduva`
--
ALTER TABLE `variedaduva`
  MODIFY `id_variedaduva` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `ventasocio`
--
ALTER TABLE `ventasocio`
  MODIFY `id_ventasocio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `articulo`
--
ALTER TABLE `articulo`
  ADD CONSTRAINT `articulo_ibfk_1` FOREIGN KEY (`id_tipouva`) REFERENCES `tipouva` (`id_tipouva`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_2` FOREIGN KEY (`id_clasevino`) REFERENCES `clasevino` (`id_clasevino`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_3` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`id_proveedor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_4` FOREIGN KEY (`id_catalogacion`) REFERENCES `catalogacion` (`id_catalogacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_5` FOREIGN KEY (`id_denominacion`) REFERENCES `denominacion` (`id_denominacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_6` FOREIGN KEY (`id_empaquetado`) REFERENCES `empaquetado` (`id_empaquetado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulo_ibfk_7` FOREIGN KEY (`id_formatocontenido`) REFERENCES `formatocontenido` (`id_formatocontenido`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `bajaexistencias`
--
ALTER TABLE `bajaexistencias`
  ADD CONSTRAINT `bajaexistencias_ibfk_1` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bajaexistencias_ibfk_2` FOREIGN KEY (`id_ubicacion`) REFERENCES `ubicacion` (`id_ubicacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bajaexistencias_ibfk_3` FOREIGN KEY (`id_lineacompraproveedor`) REFERENCES `lineacompraproveedor` (`id_lineacompraproveedor`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `compraproveedor`
--
ALTER TABLE `compraproveedor`
  ADD CONSTRAINT `compraproveedor_ibfk_1` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `devolucionproveedor`
--
ALTER TABLE `devolucionproveedor`
  ADD CONSTRAINT `devolucionproveedor_ibfk_1` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `devolucionproveedor_ibfk_2` FOREIGN KEY (`id_lineacompraproveedor`) REFERENCES `lineacompraproveedor` (`id_lineacompraproveedor`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `devolucionsocio`
--
ALTER TABLE `devolucionsocio`
  ADD CONSTRAINT `devolucionsocio_ibfk_1` FOREIGN KEY (`id_ventasocio`) REFERENCES `ventasocio` (`id_ventasocio`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `devolucionsocio_ibfk_2` FOREIGN KEY (`id_lineaventasocio`) REFERENCES `lineaventasocio` (`id_lineaventasocio`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`id_rollempleado`) REFERENCES `rollempleado` (`id_rollempleado`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `lineacompraproveedor`
--
ALTER TABLE `lineacompraproveedor`
  ADD CONSTRAINT `lineacompraproveedor_ibfk_1` FOREIGN KEY (`id_compraproveedor`) REFERENCES `compraproveedor` (`id_compraproveedor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `lineacompraproveedor_ibfk_2` FOREIGN KEY (`id_articulo`) REFERENCES `articulo` (`id_articulo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `lineaventasocio`
--
ALTER TABLE `lineaventasocio`
  ADD CONSTRAINT `lineaventasocio_ibfk_1` FOREIGN KEY (`id_ventasocio`) REFERENCES `ventasocio` (`id_ventasocio`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `lineaventasocio_ibfk_2` FOREIGN KEY (`id_compraproveedor`) REFERENCES `compraproveedor` (`id_compraproveedor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `lineaventasocio_ibfk_3` FOREIGN KEY (`id_articulo`) REFERENCES `articulo` (`id_articulo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `tipouva`
--
ALTER TABLE `tipouva`
  ADD CONSTRAINT `tipouva_ibfk_1` FOREIGN KEY (`id_variedaduva`) REFERENCES `variedaduva` (`id_variedaduva`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ubicacionlineacompraproveedor`
--
ALTER TABLE `ubicacionlineacompraproveedor`
  ADD CONSTRAINT `ubicacionlineacompraproveedor_ibfk_1` FOREIGN KEY (`id_ubicacion`) REFERENCES `ubicacion` (`id_ubicacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ubicacionlineacompraproveedor_ibfk_2` FOREIGN KEY (`id_lineacompraproveedor`) REFERENCES `lineacompraproveedor` (`id_lineacompraproveedor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ubicacionlineacompraproveedor_ibfk_3` FOREIGN KEY (`id_articulo`) REFERENCES `articulo` (`id_articulo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ventasocio`
--
ALTER TABLE `ventasocio`
  ADD CONSTRAINT `ventasocio_ibfk_1` FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ventasocio_ibfk_2` FOREIGN KEY (`id_socio`) REFERENCES `socio` (`id_socio`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
