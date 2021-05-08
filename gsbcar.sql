-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 06 avr. 2020 à 08:36
-- Version du serveur :  10.4.10-MariaDB
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `gsbcar`
--

-- --------------------------------------------------------

--
-- Structure de la table `intervention`
--

DROP TABLE IF EXISTS `intervention`;
CREATE TABLE IF NOT EXISTS `intervention` (
  `inter_id` int(11) NOT NULL AUTO_INCREMENT,
  `inter_type` varchar(50) NOT NULL,
  `inter_date` date NOT NULL,
  `inter_cout` double NOT NULL,
  `voit_id` int(11) NOT NULL,
  `inter_desc` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`inter_id`),
  KEY `Intervention_Vehicule_FK` (`voit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `intervention`
--

INSERT INTO `intervention` (`inter_id`, `inter_type`, `inter_date`, `inter_cout`, `voit_id`, `inter_desc`) VALUES
(1, 'Réparations', '2020-08-09', 10, 1, 'Bougies cassées'),
(2, 'Vidange', '2020-04-05', 80, 5, 'Vidange mensuelle'),
(3, 'Entretien', '2020-04-05', 11, 5, 'Nettoyage'),
(4, 'Accident', '2020-04-05', 0, 5, 'Sortie de route');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE IF NOT EXISTS `reservation` (
  `res_id` int(11) NOT NULL AUTO_INCREMENT,
  `res_dateDebut` date NOT NULL,
  `res_dateFin` date NOT NULL,
  `res_etatD` varchar(50) NOT NULL,
  `res_etatF` varchar(50) NOT NULL,
  `res_kmD` int(11) NOT NULL,
  `res_kmF` int(11) NOT NULL,
  `res_destination` varchar(100) NOT NULL,
  `res_depenses` double NOT NULL,
  `res_justificatif` varchar(100) NOT NULL,
  `sal_id` int(11) NOT NULL,
  `voit_id` int(11) NOT NULL,
  PRIMARY KEY (`res_id`),
  KEY `Reservation_Salarie_FK` (`sal_id`),
  KEY `Reservation_Vehicule0_FK` (`voit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `salarie`
--

DROP TABLE IF EXISTS `salarie`;
CREATE TABLE IF NOT EXISTS `salarie` (
  `sal_id` int(11) NOT NULL AUTO_INCREMENT,
  `sal_nom` varchar(50) NOT NULL,
  `sal_prenom` varchar(50) NOT NULL,
  `sal_login` varchar(50) NOT NULL,
  `sal_mdp` varchar(50) NOT NULL,
  `sal_admin` varchar(3) NOT NULL,
  PRIMARY KEY (`sal_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `salarie`
--

INSERT INTO `salarie` (`sal_id`, `sal_nom`, `sal_prenom`, `sal_login`, `sal_mdp`, `sal_admin`) VALUES
(1, 'Chevalot', 'Lucas', 'lchevalot', '0550002D', 'Oui');

-- --------------------------------------------------------

--
-- Structure de la table `vehicule`
--

DROP TABLE IF EXISTS `vehicule`;
CREATE TABLE IF NOT EXISTS `vehicule` (
  `voit_id` int(11) NOT NULL AUTO_INCREMENT,
  `voit_marque` varchar(50) NOT NULL,
  `voit_modele` varchar(50) NOT NULL,
  `voit_imma` varchar(15) NOT NULL,
  `voit_conso` double DEFAULT NULL,
  `voit_autono` double DEFAULT NULL,
  `voit_tpscharg` int(11) DEFAULT NULL,
  `voit_type` varchar(20) NOT NULL,
  `voit_dateachat` date NOT NULL,
  `voit_interrev` int(11) NOT NULL,
  `voit_prixachat` double NOT NULL,
  `voit_loyer` double NOT NULL,
  `voit_etat` varchar(30) NOT NULL,
  `voit_puissance` int(5) DEFAULT NULL,
  `voit_kilom` int(10) DEFAULT NULL,
  `voit_disp` int(1) DEFAULT NULL,
  PRIMARY KEY (`voit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `vehicule`
--

INSERT INTO `vehicule` (`voit_id`, `voit_marque`, `voit_modele`, `voit_imma`, `voit_conso`, `voit_autono`, `voit_tpscharg`, `voit_type`, `voit_dateachat`, `voit_interrev`, `voit_prixachat`, `voit_loyer`, `voit_etat`, `voit_puissance`, `voit_kilom`, `voit_disp`) VALUES
(1, 'Mercedes', 'A160', 'HD-AFJ-SD', 6.9, 0, 0, 'Essence', '2019-10-16', 1, 1500, 0, 'Occasion', 0, 200000, 0),
(5, 'Peugeot', '106 ColorLine', 'CQ-070-FW', 6.9, 0, 0, 'Essence', '2020-03-13', 3, 1100, 0, 'Occasion', 0, 163000, 0);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `intervention`
--
ALTER TABLE `intervention`
  ADD CONSTRAINT `Intervention_Vehicule_FK` FOREIGN KEY (`voit_id`) REFERENCES `vehicule` (`voit_id`);

--
-- Contraintes pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `Reservation_Salarie_FK` FOREIGN KEY (`sal_id`) REFERENCES `salarie` (`sal_id`),
  ADD CONSTRAINT `Reservation_Vehicule0_FK` FOREIGN KEY (`voit_id`) REFERENCES `vehicule` (`voit_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
