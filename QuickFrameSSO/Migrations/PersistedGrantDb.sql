CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `DeviceCodes` (
    `UserCode` varchar(200) NOT NULL,
    `DeviceCode` varchar(200) NOT NULL,
    `SubjectId` varchar(200) NULL,
    `SessionId` varchar(100) NULL,
    `ClientId` varchar(200) NOT NULL,
    `Description` varchar(200) NULL,
    `CreationTime` datetime(6) NOT NULL,
    `Expiration` datetime(6) NOT NULL,
    `Data` longtext NOT NULL,
    CONSTRAINT `PK_DeviceCodes` PRIMARY KEY (`UserCode`)
);

CREATE TABLE `PersistedGrants` (
    `Key` varchar(200) NOT NULL,
    `Type` varchar(50) NOT NULL,
    `SubjectId` varchar(200) NULL,
    `SessionId` varchar(100) NULL,
    `ClientId` varchar(200) NOT NULL,
    `Description` varchar(200) NULL,
    `CreationTime` datetime(6) NOT NULL,
    `Expiration` datetime(6) NULL,
    `ConsumedTime` datetime(6) NULL,
    `Data` longtext NOT NULL,
    CONSTRAINT `PK_PersistedGrants` PRIMARY KEY (`Key`)
);

CREATE UNIQUE INDEX `IX_DeviceCodes_DeviceCode` ON `DeviceCodes` (`DeviceCode`);

CREATE INDEX `IX_DeviceCodes_Expiration` ON `DeviceCodes` (`Expiration`);

CREATE INDEX `IX_PersistedGrants_Expiration` ON `PersistedGrants` (`Expiration`);

CREATE INDEX `IX_PersistedGrants_SubjectId_ClientId_Type` ON `PersistedGrants` (`SubjectId`, `ClientId`, `Type`);

CREATE INDEX `IX_PersistedGrants_SubjectId_SessionId_Type` ON `PersistedGrants` (`SubjectId`, `SessionId`, `Type`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210112235634_CreatePersistedGrant_MySql', '3.1.8');

