-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 07. 11:47
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `diak`
--

CREATE TABLE `diak` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `iskola` varchar(255) NOT NULL,
  `szazalek` int(3) DEFAULT NULL,
  `verseny_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `diak`
--

INSERT INTO `diak` (`id`, `nev`, `iskola`, `szazalek`, `verseny_id`) VALUES
(1, 'Kovács Péter', 'Fazekas Gimnázium', 80, 1),
(2, 'Nagy Anna', 'Deák Téri Iskola', 92, 2),
(3, 'Tóth Béla', 'Kölcsey Gimnázium', 85, 3),
(4, 'Szabó Márton', 'Radnóti Gimnázium', 78, 1),
(5, 'Kiss Lilla', 'Váci Mihály Iskola', 90, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `verseny`
--

CREATE TABLE `verseny` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `verseny`
--

INSERT INTO `verseny` (`id`, `nev`, `datum`) VALUES
(1, 'OSZTV', '2024-05-10'),
(2, 'EuroSkills', '2025-07-02'),
(3, 'WorldSkills', '2024-07-20');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `diak`
--
ALTER TABLE `diak`
  ADD PRIMARY KEY (`id`),
  ADD KEY `verseny_id` (`verseny_id`);

--
-- A tábla indexei `verseny`
--
ALTER TABLE `verseny`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `diak`
--
ALTER TABLE `diak`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `verseny`
--
ALTER TABLE `verseny`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `diak`
--
ALTER TABLE `diak`
  ADD CONSTRAINT `diak_ibfk_1` FOREIGN KEY (`verseny_id`) REFERENCES `verseny` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
