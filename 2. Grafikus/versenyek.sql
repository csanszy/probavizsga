-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Már 30. 16:24
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `versenyek`
--

--
-- A tábla adatainak kiíratása `verseny`
--

INSERT INTO `verseny` (`id`, `nev`, `datum`) VALUES
(1, 'OSZTV', '2024-05-10'),
(2, 'EuroSkills', '2024-06-15'),
(3, 'WorldSkills', '2024-07-20');
--
-- A tábla adatainak kiíratása `diak`
--

INSERT INTO `diak` (`id`, `nev`, `iskola`, `szazalek`, `verseny_id`) VALUES
(1, 'Kovács Péter', 'Fazekas Gimnázium', 80, 1),
(2, 'Nagy Anna', 'Deák Téri Iskola', 92, 2),
(3, 'Tóth Béla', 'Kölcsey Gimnázium', 85, 3),
(4, 'Szabó Márton', 'Radnóti Gimnázium', 78, 1),
(5, 'Kiss Lilla', 'Váci Mihály Iskola', 90, 2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;