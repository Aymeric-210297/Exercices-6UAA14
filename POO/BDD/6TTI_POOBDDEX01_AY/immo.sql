-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: immo
-- ------------------------------------------------------
-- Server version	5.7.36-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `biens`
--

DROP TABLE IF EXISTS `biens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biens` (
  `bienId` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `taille` int(255) DEFAULT NULL,
  `prix` int(255) DEFAULT NULL,
  `ville` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `userId` int(11) NOT NULL,
  `description` text COLLATE utf8_unicode_ci,
  `chambres` int(11) DEFAULT NULL,
  `imageBien` int(11) DEFAULT NULL,
  PRIMARY KEY (`bienId`),
  KEY `userId` (`userId`),
  KEY `imageBien` (`imageBien`),
  CONSTRAINT `biens_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `utilisateurs` (`id`),
  CONSTRAINT `biens_ibfk_2` FOREIGN KEY (`imageBien`) REFERENCES `images` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biens`
--

LOCK TABLES `biens` WRITE;
/*!40000 ALTER TABLE `biens` DISABLE KEYS */;
INSERT INTO `biens` VALUES (1,'Villa St Maurice',250,210000,'Gembloux',1,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam fringilla nulla non volutpat aliquet. Etiam gravida urna venenatis viverra fringilla. Donec varius risus eu pretium semper. Curabitur urna mauris, bibendum at maximus id, lacinia vehicula nisi. Ut a nisi finibus massa mollis imperdiet. Quisque at dictum mi, eu sollicitudin lectus. Fusce suscipit quam non leo rutrum pretium. Nunc convallis vestibulum neque, nec fringilla ex volutpat vitae. Cras nec cursus arcu. Nam vulputate porttitor commodo. Quisque iaculis libero neque, quis sollicitudin nunc accumsan eget. Nunc interdum odio ac urna ultricies, ut sollicitudin mi consectetur. Nunc in dictum lorem, eget varius dolor.',5,NULL),(3,'Immeuble de fortune',136,520000,'Charleroi',2,'In sodales elit ac orci dictum pulvinar. Praesent eu odio sed erat mattis malesuada. Morbi mattis justo metus, sit amet laoreet lacus viverra eget. Vestibulum vitae euismod mi. Curabitur blandit condimentum tristique. Sed fringilla massa vitae convallis suscipit. Fusce urna justo, volutpat malesuada erat in, auctor fringilla velit. Curabitur rutrum dui sit amet odio ultrices iaculis. Nunc semper posuere odio, sit amet maximus velit euismod id. Fusce id mauris ultricies, faucibus justo vel, finibus lorem. Mauris at leo nec eros congue rhoncus. Nullam sodales cursus dolor, in cursus sapien posuere quis. In a felis scelerisque, aliquet ex sed, ornare leo. Sed finibus purus elit, imperdiet semper neque faucibus et.',2,43),(4,'Villa bella',300,310000,'Bruxelles',2,'Morbi eget justo pellentesque, lobortis elit quis, molestie nibh. Nulla eget gravida purus. Cras malesuada nunc lacus, eu varius dui euismod at. Phasellus pulvinar efficitur dolor, ut tincidunt turpis eleifend in. Aliquam posuere convallis tortor sed rutrum. Sed porta pretium condimentum. Maecenas nec ullamcorper nulla. Suspendisse et libero et ante pretium malesuada id vitae mi. Morbi gravida mauris in nunc vestibulum sollicitudin. Fusce a est quam',4,NULL),(16,'Cabane en bois près d\'un lac',250,156000,'Ardenne',2,'teger rutrum ex eu nisl efficitur, vel consectetur neque aliquet. Quisque congue vulputate pellentesque. Sed tristique malesuada quam, ornare congue turpis luctus eget. Maecenas at condimentum ante. Donec condimentum lobortis risus. Nullam maximus, nibh et sagittis porttitor, velit diam faucibus felis, in pharetra metus quam in ligula. Duis fringilla et erat hendrerit rutrum. Etiam pellentesque tortor lorem, id dapibus nulla egestas ac. Sed eu fermentum mi. Praesent a sodales justo, quis hendrerit arcu. Aliquam in leo vel quam facilisis rhoncus. Nunc id neque elit. Curabitur odio est, tincidunt non ultrices non, fermentum in nunc.',3,NULL),(29,'test',4,5,'test',2,'test',4,NULL);
/*!40000 ALTER TABLE `biens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `biens_options`
--

DROP TABLE IF EXISTS `biens_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biens_options` (
  `bienId` int(11) NOT NULL,
  `optionId` int(11) NOT NULL,
  PRIMARY KEY (`bienId`,`optionId`),
  KEY `optionId` (`optionId`),
  CONSTRAINT `biens_options_ibfk_1` FOREIGN KEY (`bienId`) REFERENCES `biens` (`bienId`),
  CONSTRAINT `biens_options_ibfk_2` FOREIGN KEY (`optionId`) REFERENCES `options` (`optionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biens_options`
--

LOCK TABLES `biens_options` WRITE;
/*!40000 ALTER TABLE `biens_options` DISABLE KEYS */;
INSERT INTO `biens_options` VALUES (1,1),(3,1),(4,1),(3,3),(4,3),(16,4);
/*!40000 ALTER TABLE `biens_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `image` varchar(80) COLLATE utf8_unicode_ci NOT NULL,
  `FK_bienId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bienId` (`FK_bienId`),
  CONSTRAINT `images_ibfk_1` FOREIGN KEY (`FK_bienId`) REFERENCES `biens` (`bienId`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES (33,'8713cabane.jpg','images/DB/8713cabane.jpg',29),(34,'2276villa.jpg','images/DB/2276villa.jpg',29),(43,'2213maison bois.jpg','images/DB/2213maison bois.jpg',3),(44,'2169chambre.jpg','images/DB/2169chambre.jpg',3),(45,'4584salon.jpg','images/DB/4584salon.jpg',3);
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `options`
--

DROP TABLE IF EXISTS `options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `options` (
  `optionId` int(11) NOT NULL AUTO_INCREMENT,
  `optionNom` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`optionId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `options`
--

LOCK TABLES `options` WRITE;
/*!40000 ALTER TABLE `options` DISABLE KEYS */;
INSERT INTO `options` VALUES (1,'Citerne à mazout'),(2,'Gaz'),(3,'Eau de ville'),(4,'Ascenseur');
/*!40000 ALTER TABLE `options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomUser` varchar(25) NOT NULL,
  `prenomUser` varchar(25) NOT NULL,
  `loginUser` varchar(25) NOT NULL,
  `passWordUser` varchar(25) NOT NULL,
  `role` varchar(255) DEFAULT 'user',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
INSERT INTO `utilisateurs` VALUES (1,'Haddock','Capitaine','alert','ofeu','user'),(2,'Dupontelle','Alphonso','test','test','user'),(3,'Castafiore','Bianca','ris','belle','user'),(4,'Tournesol','Triphon','vous','dites','user'),(9,'ben','dmh','ben','123456','admin');
/*!40000 ALTER TABLE `utilisateurs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-28  9:10:58
