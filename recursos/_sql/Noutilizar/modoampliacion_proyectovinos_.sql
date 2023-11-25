-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-12-2022 a las 13:18:58
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
-- Base de datos: `proyectovinos;`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `articulovino`
--

CREATE TABLE `articulovino` (
  `id_articulovino` int(11) NOT NULL,
  `id_clase` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(20) NOT NULL,
  `ano` int(11) NOT NULL,
  `cantidad` decimal(3,2) NOT NULL,
  `id_volumen` int(11) NOT NULL,
  `id_valoracioncalidad` int(11) NOT NULL,
  `id_variedaduvas` int(11) NOT NULL,
  `id_temperatura` int(11) NOT NULL,
  `id_maridaje` int(11) NOT NULL,
  `id_mesesbarrica` int(11) NOT NULL,
  `preciocoste` decimal(4,2) NOT NULL,
  `precioventa` decimal(4,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `articulovino`
--

INSERT INTO `articulovino` (`id_articulovino`, `id_clase`, `nombre`, `descripcion`, `ano`, `cantidad`, `id_volumen`, `id_valoracioncalidad`, `id_variedaduvas`, `id_temperatura`, `id_maridaje`, `id_mesesbarrica`, `preciocoste`, `precioventa`) VALUES
(1, 9, 'PUENTE PIEDRA', 'Crianza Magnum', 2018, '9.99', 2, 1, 1, 1, 1, 1, '12.55', '17.90');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clase`
--

CREATE TABLE `clase` (
  `id_clase` int(11) NOT NULL,
  `nombre` enum('TINTO','BLANCO','ROSADO','ESPUMOSO','GENEROSO') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clase`
--

INSERT INTO `clase` (`id_clase`, `nombre`) VALUES
(2, 'BLANCO'),
(3, 'ROSADO'),
(4, 'ESPUMOSO'),
(5, 'GENEROSO'),
(9, 'TINTO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `maridaje`
--

CREATE TABLE `maridaje` (
  `id_maridaje` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `maridaje`
--

INSERT INTO `maridaje` (`id_maridaje`, `descripcion`) VALUES
(1, 'Carnes de Ternera y Guisos de Ternera'),
(2, 'Reposteria, Foie, Quesos Azules y Arroces');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mesesbarrica`
--

CREATE TABLE `mesesbarrica` (
  `id_mesesbarrica` int(11) NOT NULL,
  `descripcion` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `mesesbarrica`
--

INSERT INTO `mesesbarrica` (`id_mesesbarrica`, `descripcion`) VALUES
(1, '12 meses'),
(2, '14 meses');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `temperatura`
--

CREATE TABLE `temperatura` (
  `id_temperatura` int(11) NOT NULL,
  `descripcionvalores` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `temperatura`
--

INSERT INTO `temperatura` (`id_temperatura`, `descripcionvalores`) VALUES
(1, '6-8º');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `valoracioncalidad`
--

CREATE TABLE `valoracioncalidad` (
  `id_valoracioncalidad` int(11) NOT NULL,
  `descripcion` enum('80-84','85-89','90-94','95-100') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `valoracioncalidad`
--

INSERT INTO `valoracioncalidad` (`id_valoracioncalidad`, `descripcion`) VALUES
(1, '80-84'),
(2, '85-89'),
(3, '90-94'),
(4, '95-100');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `variedaduvas`
--

CREATE TABLE `variedaduvas` (
  `id_variedaduvas` int(11) NOT NULL,
  `variedad` enum('Tintas','Blancas','Mezcla') NOT NULL,
  `descripcion` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `variedaduvas`
--

INSERT INTO `variedaduvas` (`id_variedaduvas`, `variedad`, `descripcion`) VALUES
(1, 'Tintas', 'Tempranillo'),
(2, '', 'Tempranillo y Garnacha'),
(3, 'Blancas', 'Viura');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `volumen`
--

CREATE TABLE `volumen` (
  `id_volumen` int(11) NOT NULL,
  `nombre` varchar(10) NOT NULL,
  `medicion` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `volumen`
--

INSERT INTO `volumen` (`id_volumen`, `nombre`, `medicion`) VALUES
(1, 'Litros', 'L.'),
(2, 'Centilitro', 'cc.');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `articulovino`
--
ALTER TABLE `articulovino`
  ADD PRIMARY KEY (`id_articulovino`),
  ADD KEY `id_clase` (`id_clase`),
  ADD KEY `id_volumen` (`id_volumen`),
  ADD KEY `id_valoracioncalidad` (`id_valoracioncalidad`),
  ADD KEY `id_variedaduvas` (`id_variedaduvas`),
  ADD KEY `id_temperatura` (`id_temperatura`),
  ADD KEY `id_maridaje` (`id_maridaje`),
  ADD KEY `id_mesesbarrica` (`id_mesesbarrica`);

--
-- Indices de la tabla `clase`
--
ALTER TABLE `clase`
  ADD PRIMARY KEY (`id_clase`);

--
-- Indices de la tabla `maridaje`
--
ALTER TABLE `maridaje`
  ADD PRIMARY KEY (`id_maridaje`);

--
-- Indices de la tabla `mesesbarrica`
--
ALTER TABLE `mesesbarrica`
  ADD PRIMARY KEY (`id_mesesbarrica`);

--
-- Indices de la tabla `temperatura`
--
ALTER TABLE `temperatura`
  ADD PRIMARY KEY (`id_temperatura`);

--
-- Indices de la tabla `valoracioncalidad`
--
ALTER TABLE `valoracioncalidad`
  ADD PRIMARY KEY (`id_valoracioncalidad`);

--
-- Indices de la tabla `variedaduvas`
--
ALTER TABLE `variedaduvas`
  ADD PRIMARY KEY (`id_variedaduvas`);

--
-- Indices de la tabla `volumen`
--
ALTER TABLE `volumen`
  ADD PRIMARY KEY (`id_volumen`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `articulovino`
--
ALTER TABLE `articulovino`
  MODIFY `id_articulovino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `clase`
--
ALTER TABLE `clase`
  MODIFY `id_clase` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `maridaje`
--
ALTER TABLE `maridaje`
  MODIFY `id_maridaje` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `mesesbarrica`
--
ALTER TABLE `mesesbarrica`
  MODIFY `id_mesesbarrica` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `temperatura`
--
ALTER TABLE `temperatura`
  MODIFY `id_temperatura` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `valoracioncalidad`
--
ALTER TABLE `valoracioncalidad`
  MODIFY `id_valoracioncalidad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `variedaduvas`
--
ALTER TABLE `variedaduvas`
  MODIFY `id_variedaduvas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `volumen`
--
ALTER TABLE `volumen`
  MODIFY `id_volumen` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `articulovino`
--
ALTER TABLE `articulovino`
  ADD CONSTRAINT `articulovino_ibfk_1` FOREIGN KEY (`id_clase`) REFERENCES `clase` (`id_clase`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_2` FOREIGN KEY (`id_volumen`) REFERENCES `volumen` (`id_volumen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_3` FOREIGN KEY (`id_valoracioncalidad`) REFERENCES `valoracioncalidad` (`id_valoracioncalidad`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_4` FOREIGN KEY (`id_variedaduvas`) REFERENCES `variedaduvas` (`id_variedaduvas`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_5` FOREIGN KEY (`id_temperatura`) REFERENCES `temperatura` (`id_temperatura`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_6` FOREIGN KEY (`id_maridaje`) REFERENCES `maridaje` (`id_maridaje`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articulovino_ibfk_7` FOREIGN KEY (`id_mesesbarrica`) REFERENCES `mesesbarrica` (`id_mesesbarrica`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
