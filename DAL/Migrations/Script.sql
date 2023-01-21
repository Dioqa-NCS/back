CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

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

CREATE TABLE `AspNetRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `marque` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_marque` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Permissions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Permissions` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `rolecompte` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_rolecompte` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `servicesupplementaire` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `prix` decimal(5,2) NULL,
    CONSTRAINT `PK_servicesupplementaire` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `statuttransport` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `couleurHex` char(7) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_statuttransport` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `tarif` (
    `id` int NOT NULL AUTO_INCREMENT,
    `intervalKmMin` int NOT NULL,
    `intervalKmMax` int NOT NULL,
    `prixAllerSimple` decimal(6,2) NULL,
    `prixAllerRetour` decimal(6,2) NULL,
    CONSTRAINT `PK_tarif` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

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

CREATE TABLE `typeentreprise` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_typeentreprise` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `typemoteur` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_typemoteur` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `typevehicule` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nom` char(1) CHARACTER SET utf8mb4 NOT NULL,
    `description` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `coefficiant` int NOT NULL,
    CONSTRAINT `PK_typevehicule` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` int NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

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

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` int NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderKey` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` int NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserRoles` (
    `UserId` int NOT NULL,
    `RoleId` int NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserTokens` (
    `UserId` int NOT NULL,
    `LoginProvider` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ComptePermission` (
    `PermissionCollectionId` int NOT NULL,
    `UserCollectionId` int NOT NULL,
    CONSTRAINT `PK_ComptePermission` PRIMARY KEY (`PermissionCollectionId`, `UserCollectionId`),
    CONSTRAINT `FK_ComptePermission_AspNetUsers_UserCollectionId` FOREIGN KEY (`UserCollectionId`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ComptePermission_Permissions_PermissionCollectionId` FOREIGN KEY (`PermissionCollectionId`) REFERENCES `Permissions` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

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

CREATE TABLE `servicesupplementairetransport` (
    `idTransport` int NOT NULL,
    `idSupplement` int NOT NULL,
    `nom` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `prix` decimal(5,2) NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`idTransport`, `idSupplement`),
    CONSTRAINT `serviceSupplementaireTransport_ibfk_1` FOREIGN KEY (`idTransport`) REFERENCES `transport` (`id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `idCompte` ON `adresse` (`idCompte`);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE INDEX `idRoleCompte` ON `AspNetUsers` (`idRoleCompte`);

CREATE INDEX `idTypeEntreprise` ON `AspNetUsers` (`idTypeEntreprise`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE INDEX `IX_ComptePermission_UserCollectionId` ON `ComptePermission` (`UserCollectionId`);

CREATE INDEX `idAdresseDebut` ON `transport` (`idAdresseDebut`);

CREATE INDEX `idAdresseFin` ON `transport` (`idAdresseFin`);

CREATE INDEX `idCompte1` ON `transport` (`idCompte`);

CREATE INDEX `idStatutTransport` ON `transport` (`idStatutTransport`);

CREATE INDEX `idVehiculeLivraison` ON `transport` (`idVehiculeLivraison`);

CREATE INDEX `idVehiculeReprise` ON `transport` (`idVehiculeReprise`);

CREATE INDEX `idCompte2` ON `vehicule` (`idCompte`);

CREATE INDEX `idTypeMoteur` ON `vehicule` (`idTypeMoteur`);

CREATE INDEX `idTypeVehicule` ON `vehicule` (`idTypeVehicule`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230118173926_initialisatonBDD', '6.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE `AspNetUsers` ADD `Name` longtext CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230119105021_test ajout d''un name', '6.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE `AspNetUsers` DROP COLUMN `Name`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230119105443_suppName', '6.0.13');

COMMIT;

START TRANSACTION;

DROP TABLE `ComptePermission`;

DROP TABLE `Permissions`;

CREATE TABLE `IdentityRole` (
    `Id` varchar(95) CHARACTER SET utf8mb4 NOT NULL,
    `CompteId` int NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `NormalizedName` longtext CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_IdentityRole` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_IdentityRole_AspNetUsers_CompteId` FOREIGN KEY (`CompteId`) REFERENCES `AspNetUsers` (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
VALUES (1, 'd0849396-c9bb-4a01-b4f4-1e5f9507564d', 'Administrateur', NULL);
INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
VALUES (2, '186815cf-e165-4ee7-8de9-f484988ced5e', 'Client', NULL);

INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (1, '#323E40', 'En attente de validation');
INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (2, '#F2A922', 'Planifié');
INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (3, '#D98014', 'En cours');
INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (4, '#367334', 'Terminé');
INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (5, '#A62929', 'Annulé');
INSERT INTO `statuttransport` (`id`, `couleurHex`, `nom`)
VALUES (6, '#BF926B', 'Expiré');

INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (1, 'EL / EIRL');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (2, 'EURL');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (3, 'SARL');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (4, 'SA');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (5, 'SAS / SASU');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (6, 'SNC');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (7, 'Scop');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (8, 'SCA');
INSERT INTO `typeentreprise` (`id`, `nom`)
VALUES (9, 'SCS');

CREATE INDEX `IX_IdentityRole_CompteId` ON `IdentityRole` (`CompteId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230121153936_SeedingDatabase', '6.0.13');

COMMIT;

START TRANSACTION;

UPDATE `AspNetRoles` SET `ConcurrencyStamp` = 'd45fe6af-6e1b-46f6-ae74-146048f1a11b'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `AspNetRoles` SET `ConcurrencyStamp` = '46ca547b-ae33-484d-b765-f7844b303662'
WHERE `Id` = 2;
SELECT ROW_COUNT();


INSERT INTO `rolecompte` (`id`, `nom`)
VALUES (1, 'Administrateur');
INSERT INTO `rolecompte` (`id`, `nom`)
VALUES (2, 'Client');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230121174612_SeedingRolCompte', '6.0.13');

COMMIT;

START TRANSACTION;

UPDATE `AspNetRoles` SET `ConcurrencyStamp` = 'bef4b560-3a92-479c-b888-1c5cf3ae5bda', `NormalizedName` = 'ADMINISTRATEUR'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `AspNetRoles` SET `ConcurrencyStamp` = '1b379714-f68f-4b7e-b4af-b9e827cf42a0', `NormalizedName` = 'CLIENT'
WHERE `Id` = 2;
SELECT ROW_COUNT();


INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230121175147_FixSeedIdentityRole', '6.0.13');

COMMIT;

