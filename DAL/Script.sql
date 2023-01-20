CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `adressetransport` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `mailContact` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `telContact` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `nomContact` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `pays` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `ville` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
        `codePostal` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `adresse` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `longitude` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `latitude` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_adressetransport` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetRoles` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `marque` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_marque` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `Permissions` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` longtext CHARACTER SET utf8mb4 NULL,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_Permissions` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `rolecompte` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_rolecompte` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `servicesupplementaire` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `prix` decimal(5,2) NULL,
        CONSTRAINT `PK_servicesupplementaire` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `statuttransport` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `couleurHex` char(7) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_statuttransport` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `tarif` (
        `id` int NOT NULL AUTO_INCREMENT,
        `intervalKmMin` int NOT NULL,
        `intervalKmMax` int NOT NULL,
        `prixAllerSimple` decimal(6,2) NULL,
        `prixAllerRetour` decimal(6,2) NULL,
        CONSTRAINT `PK_tarif` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `ticket` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nomEntreprise` varchar(300) CHARACTER SET utf8mb4 NOT NULL,
        `nom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `prenom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `telephone` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `sujet` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `mail` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `dateHeureEnvoie` datetime NOT NULL,
        `message` varchar(2000) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_ticket` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `typeentreprise` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_typeentreprise` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `typemoteur` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_typemoteur` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `typevehicule` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nom` char(1) CHARACTER SET utf8mb4 NOT NULL,
        `description` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `coefficiant` int NOT NULL,
        CONSTRAINT `PK_typevehicule` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetRoleClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `RoleId` int NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
        `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetUsers` (
        `id` int NOT NULL AUTO_INCREMENT,
        `idRoleCompte` int NOT NULL,
        `idTypeEntreprise` int NOT NULL,
        `nom` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
        `prenom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `mail` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `tel` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `mdp` varchar(300) CHARACTER SET utf8mb4 NOT NULL,
        `nomEntreprise` varchar(300) CHARACTER SET utf8mb4 NOT NULL,
        `refreshToken` varchar(200) CHARACTER SET utf8mb4 NULL,
        `adresseFacturation` varchar(300) CHARACTER SET utf8mb4 NOT NULL,
        `villeFacturation` varchar(300) CHARACTER SET utf8mb4 NOT NULL,
        `codePostalFacturation` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `telFacturation` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `mailFacturation` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `reductionPrix` int NULL DEFAULT '0',
        `estValider` char(1) CHARACTER SET utf8mb4 NULL DEFAULT '0',
        `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
        `EmailConfirmed` tinyint(1) NOT NULL,
        `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
        `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
        `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
        `PhoneNumberConfirmed` tinyint(1) NOT NULL,
        `TwoFactorEnabled` tinyint(1) NOT NULL,
        `LockoutEnd` datetime NULL,
        `LockoutEnabled` tinyint(1) NOT NULL,
        `AccessFailedCount` int NOT NULL,
        CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`id`),
        CONSTRAINT `compte_ibfk_1` FOREIGN KEY (`idRoleCompte`) REFERENCES `rolecompte` (`id`),
        CONSTRAINT `compte_ibfk_2` FOREIGN KEY (`idTypeEntreprise`) REFERENCES `typeentreprise` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `adresse` (
        `id` int NOT NULL AUTO_INCREMENT,
        `idCompte` int NULL,
        `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `mailContact` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `telContact` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `nomContact` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `pays` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `ville` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
        `codePostal` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `adresse` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `longitude` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `latitude` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_adresse` PRIMARY KEY (`id`),
        CONSTRAINT `adresse_ibfk_1` FOREIGN KEY (`idCompte`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetUserClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` int NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
        `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetUserLogins` (
        `LoginProvider` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `ProviderKey` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
        `UserId` int NOT NULL,
        CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
        CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetUserRoles` (
        `UserId` int NOT NULL,
        `RoleId` int NOT NULL,
        CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
        CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `AspNetUserTokens` (
        `UserId` int NOT NULL,
        `LoginProvider` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `Value` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
        CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `ComptePermission` (
        `PermissionCollectionId` int NOT NULL,
        `UserCollectionId` int NOT NULL,
        CONSTRAINT `PK_ComptePermission` PRIMARY KEY (`PermissionCollectionId`, `UserCollectionId`),
        CONSTRAINT `FK_ComptePermission_AspNetUsers_UserCollectionId` FOREIGN KEY (`UserCollectionId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE,
        CONSTRAINT `FK_ComptePermission_Permissions_PermissionCollectionId` FOREIGN KEY (`PermissionCollectionId`) REFERENCES `Permissions` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `vehicule` (
        `id` int NOT NULL AUTO_INCREMENT,
        `idTypeVehicule` int NOT NULL,
        `idTypeMoteur` int NOT NULL,
        `idCompte` int NOT NULL,
        `plaqueImatriculation` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `numeroVIN` char(8) CHARACTER SET utf8mb4 NOT NULL,
        `nomMarque` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `nomModel` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `nomCarburant` varchar(20) CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_vehicule` PRIMARY KEY (`id`),
        CONSTRAINT `vehicule_ibfk_1` FOREIGN KEY (`idTypeVehicule`) REFERENCES `typevehicule` (`id`),
        CONSTRAINT `vehicule_ibfk_2` FOREIGN KEY (`idTypeMoteur`) REFERENCES `typemoteur` (`id`),
        CONSTRAINT `vehicule_ibfk_3` FOREIGN KEY (`idCompte`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `transport` (
        `id` int NOT NULL AUTO_INCREMENT,
        `idCompte` int NOT NULL,
        `idVehiculeLivraison` int NULL,
        `idVehiculeReprise` int NULL,
        `typeTransport` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `idStatutTransport` int NULL DEFAULT '1',
        `idAdresseDebut` int NOT NULL,
        `idAdresseFin` int NOT NULL,
        `dateDebut` date NOT NULL,
        `dateFin` date NOT NULL,
        `commentaire` varchar(1000) CHARACTER SET utf8mb4 NULL,
        `distanceKm` decimal(10,3) NOT NULL,
        `prixTotal` decimal(7,2) NOT NULL,
        `reference` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
        `bonCommande` varchar(80) CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_transport` PRIMARY KEY (`id`),
        CONSTRAINT `transport_ibfk_1` FOREIGN KEY (`idCompte`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE,
        CONSTRAINT `transport_ibfk_2` FOREIGN KEY (`idVehiculeLivraison`) REFERENCES `vehicule` (`id`),
        CONSTRAINT `transport_ibfk_3` FOREIGN KEY (`idVehiculeReprise`) REFERENCES `vehicule` (`id`),
        CONSTRAINT `transport_ibfk_4` FOREIGN KEY (`idStatutTransport`) REFERENCES `statuttransport` (`id`),
        CONSTRAINT `transport_ibfk_5` FOREIGN KEY (`idAdresseDebut`) REFERENCES `adressetransport` (`id`),
        CONSTRAINT `transport_ibfk_6` FOREIGN KEY (`idAdresseFin`) REFERENCES `adressetransport` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE TABLE `servicesupplementairetransport` (
        `idTransport` int NOT NULL,
        `idSupplement` int NOT NULL,
        `nom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `prix` decimal(5,2) NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`idTransport`, `idSupplement`),
        CONSTRAINT `serviceSupplementaireTransport_ibfk_1` FOREIGN KEY (`idTransport`) REFERENCES `transport` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idCompte` ON `adresse` (`idCompte`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idRoleCompte` ON `AspNetUsers` (`idRoleCompte`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idTypeEntreprise` ON `AspNetUsers` (`idTypeEntreprise`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `IX_ComptePermission_UserCollectionId` ON `ComptePermission` (`UserCollectionId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idAdresseDebut` ON `transport` (`idAdresseDebut`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idAdresseFin` ON `transport` (`idAdresseFin`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idCompte1` ON `transport` (`idCompte`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idStatutTransport` ON `transport` (`idStatutTransport`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idVehiculeLivraison` ON `transport` (`idVehiculeLivraison`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idVehiculeReprise` ON `transport` (`idVehiculeReprise`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idCompte2` ON `vehicule` (`idCompte`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idTypeMoteur` ON `vehicule` (`idTypeMoteur`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    CREATE INDEX `idTypeVehicule` ON `vehicule` (`idTypeVehicule`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230118173926_initialisatonBDD') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230118173926_initialisatonBDD', '6.0.13');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230119105021_test ajout d'un name') THEN

    ALTER TABLE `AspNetUsers` ADD `Name` longtext CHARACTER SET utf8mb4 NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230119105021_test ajout d'un name') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230119105021_test ajout d''un name', '6.0.13');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230119105443_suppName') THEN

    ALTER TABLE `AspNetUsers` DROP COLUMN `Name`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20230119105443_suppName') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20230119105443_suppName', '6.0.13');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

