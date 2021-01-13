CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `ApiResources` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Enabled` tinyint(1) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `DisplayName` varchar(200) NULL,
    `Description` varchar(1000) NULL,
    `AllowedAccessTokenSigningAlgorithms` varchar(100) NULL,
    `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
    `Created` datetime(6) NOT NULL,
    `Updated` datetime(6) NULL,
    `LastAccessed` datetime(6) NULL,
    `NonEditable` tinyint(1) NOT NULL,
    CONSTRAINT `PK_ApiResources` PRIMARY KEY (`Id`)
);

CREATE TABLE `ApiScopes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Enabled` tinyint(1) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `DisplayName` varchar(200) NULL,
    `Description` varchar(1000) NULL,
    `Required` tinyint(1) NOT NULL,
    `Emphasize` tinyint(1) NOT NULL,
    `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
    CONSTRAINT `PK_ApiScopes` PRIMARY KEY (`Id`)
);

CREATE TABLE `Clients` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Enabled` tinyint(1) NOT NULL,
    `ClientId` varchar(200) NOT NULL,
    `ProtocolType` varchar(200) NOT NULL,
    `RequireClientSecret` tinyint(1) NOT NULL,
    `ClientName` varchar(200) NULL,
    `Description` varchar(1000) NULL,
    `ClientUri` varchar(2000) NULL,
    `LogoUri` varchar(2000) NULL,
    `RequireConsent` tinyint(1) NOT NULL,
    `AllowRememberConsent` tinyint(1) NOT NULL,
    `AlwaysIncludeUserClaimsInIdToken` tinyint(1) NOT NULL,
    `RequirePkce` tinyint(1) NOT NULL,
    `AllowPlainTextPkce` tinyint(1) NOT NULL,
    `RequireRequestObject` tinyint(1) NOT NULL,
    `AllowAccessTokensViaBrowser` tinyint(1) NOT NULL,
    `FrontChannelLogoutUri` varchar(2000) NULL,
    `FrontChannelLogoutSessionRequired` tinyint(1) NOT NULL,
    `BackChannelLogoutUri` varchar(2000) NULL,
    `BackChannelLogoutSessionRequired` tinyint(1) NOT NULL,
    `AllowOfflineAccess` tinyint(1) NOT NULL,
    `IdentityTokenLifetime` int NOT NULL,
    `AllowedIdentityTokenSigningAlgorithms` varchar(100) NULL,
    `AccessTokenLifetime` int NOT NULL,
    `AuthorizationCodeLifetime` int NOT NULL,
    `ConsentLifetime` int NULL,
    `AbsoluteRefreshTokenLifetime` int NOT NULL,
    `SlidingRefreshTokenLifetime` int NOT NULL,
    `RefreshTokenUsage` int NOT NULL,
    `UpdateAccessTokenClaimsOnRefresh` tinyint(1) NOT NULL,
    `RefreshTokenExpiration` int NOT NULL,
    `AccessTokenType` int NOT NULL,
    `EnableLocalLogin` tinyint(1) NOT NULL,
    `IncludeJwtId` tinyint(1) NOT NULL,
    `AlwaysSendClientClaims` tinyint(1) NOT NULL,
    `ClientClaimsPrefix` varchar(200) NULL,
    `PairWiseSubjectSalt` varchar(200) NULL,
    `Created` datetime(6) NOT NULL,
    `Updated` datetime(6) NULL,
    `LastAccessed` datetime(6) NULL,
    `UserSsoLifetime` int NULL,
    `UserCodeType` varchar(100) NULL,
    `DeviceCodeLifetime` int NOT NULL,
    `NonEditable` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Clients` PRIMARY KEY (`Id`)
);

CREATE TABLE `IdentityResources` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Enabled` tinyint(1) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `DisplayName` varchar(200) NULL,
    `Description` varchar(1000) NULL,
    `Required` tinyint(1) NOT NULL,
    `Emphasize` tinyint(1) NOT NULL,
    `ShowInDiscoveryDocument` tinyint(1) NOT NULL,
    `Created` datetime(6) NOT NULL,
    `Updated` datetime(6) NULL,
    `NonEditable` tinyint(1) NOT NULL,
    CONSTRAINT `PK_IdentityResources` PRIMARY KEY (`Id`)
);

CREATE TABLE `ApiResourceClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` varchar(200) NOT NULL,
    `ApiResourceId` int NOT NULL,
    CONSTRAINT `PK_ApiResourceClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiResourceClaims_ApiResources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResources` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ApiResourceProperties` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Key` varchar(250) NOT NULL,
    `Value` varchar(2000) NOT NULL,
    `ApiResourceId` int NOT NULL,
    CONSTRAINT `PK_ApiResourceProperties` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiResourceProperties_ApiResources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResources` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ApiResourceScopes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Scope` varchar(200) NOT NULL,
    `ApiResourceId` int NOT NULL,
    CONSTRAINT `PK_ApiResourceScopes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiResourceScopes_ApiResources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResources` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ApiResourceSecrets` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` varchar(1000) NULL,
    `Value` longtext NOT NULL,
    `Expiration` datetime(6) NULL,
    `Type` varchar(250) NOT NULL,
    `Created` datetime(6) NOT NULL,
    `ApiResourceId` int NOT NULL,
    CONSTRAINT `PK_ApiResourceSecrets` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiResourceSecrets_ApiResources_ApiResourceId` FOREIGN KEY (`ApiResourceId`) REFERENCES `ApiResources` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ApiScopeClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` varchar(200) NOT NULL,
    `ScopeId` int NOT NULL,
    CONSTRAINT `PK_ApiScopeClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiScopeClaims_ApiScopes_ScopeId` FOREIGN KEY (`ScopeId`) REFERENCES `ApiScopes` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ApiScopeProperties` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Key` varchar(250) NOT NULL,
    `Value` varchar(2000) NOT NULL,
    `ScopeId` int NOT NULL,
    CONSTRAINT `PK_ApiScopeProperties` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApiScopeProperties_ApiScopes_ScopeId` FOREIGN KEY (`ScopeId`) REFERENCES `ApiScopes` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` varchar(250) NOT NULL,
    `Value` varchar(250) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientClaims_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientCorsOrigins` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Origin` varchar(150) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientCorsOrigins` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientCorsOrigins_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientGrantTypes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `GrantType` varchar(250) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientGrantTypes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientGrantTypes_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientIdPRestrictions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Provider` varchar(200) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientIdPRestrictions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientIdPRestrictions_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientPostLogoutRedirectUris` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PostLogoutRedirectUri` varchar(2000) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientPostLogoutRedirectUris` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientPostLogoutRedirectUris_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientProperties` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Key` varchar(250) NOT NULL,
    `Value` varchar(2000) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientProperties` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientProperties_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientRedirectUris` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RedirectUri` varchar(2000) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientRedirectUris` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientRedirectUris_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientScopes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Scope` varchar(200) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientScopes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientScopes_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ClientSecrets` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` varchar(2000) NULL,
    `Value` longtext NOT NULL,
    `Expiration` datetime(6) NULL,
    `Type` varchar(250) NOT NULL,
    `Created` datetime(6) NOT NULL,
    `ClientId` int NOT NULL,
    CONSTRAINT `PK_ClientSecrets` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ClientSecrets_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `IdentityResourceClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Type` varchar(200) NOT NULL,
    `IdentityResourceId` int NOT NULL,
    CONSTRAINT `PK_IdentityResourceClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_IdentityResourceClaims_IdentityResources_IdentityResourceId` FOREIGN KEY (`IdentityResourceId`) REFERENCES `IdentityResources` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `IdentityResourceProperties` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Key` varchar(250) NOT NULL,
    `Value` varchar(2000) NOT NULL,
    `IdentityResourceId` int NOT NULL,
    CONSTRAINT `PK_IdentityResourceProperties` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_IdentityResourceProperties_IdentityResources_IdentityResourc~` FOREIGN KEY (`IdentityResourceId`) REFERENCES `IdentityResources` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_ApiResourceClaims_ApiResourceId` ON `ApiResourceClaims` (`ApiResourceId`);

CREATE INDEX `IX_ApiResourceProperties_ApiResourceId` ON `ApiResourceProperties` (`ApiResourceId`);

CREATE UNIQUE INDEX `IX_ApiResources_Name` ON `ApiResources` (`Name`);

CREATE INDEX `IX_ApiResourceScopes_ApiResourceId` ON `ApiResourceScopes` (`ApiResourceId`);

CREATE INDEX `IX_ApiResourceSecrets_ApiResourceId` ON `ApiResourceSecrets` (`ApiResourceId`);

CREATE INDEX `IX_ApiScopeClaims_ScopeId` ON `ApiScopeClaims` (`ScopeId`);

CREATE INDEX `IX_ApiScopeProperties_ScopeId` ON `ApiScopeProperties` (`ScopeId`);

CREATE UNIQUE INDEX `IX_ApiScopes_Name` ON `ApiScopes` (`Name`);

CREATE INDEX `IX_ClientClaims_ClientId` ON `ClientClaims` (`ClientId`);

CREATE INDEX `IX_ClientCorsOrigins_ClientId` ON `ClientCorsOrigins` (`ClientId`);

CREATE INDEX `IX_ClientGrantTypes_ClientId` ON `ClientGrantTypes` (`ClientId`);

CREATE INDEX `IX_ClientIdPRestrictions_ClientId` ON `ClientIdPRestrictions` (`ClientId`);

CREATE INDEX `IX_ClientPostLogoutRedirectUris_ClientId` ON `ClientPostLogoutRedirectUris` (`ClientId`);

CREATE INDEX `IX_ClientProperties_ClientId` ON `ClientProperties` (`ClientId`);

CREATE INDEX `IX_ClientRedirectUris_ClientId` ON `ClientRedirectUris` (`ClientId`);

CREATE UNIQUE INDEX `IX_Clients_ClientId` ON `Clients` (`ClientId`);

CREATE INDEX `IX_ClientScopes_ClientId` ON `ClientScopes` (`ClientId`);

CREATE INDEX `IX_ClientSecrets_ClientId` ON `ClientSecrets` (`ClientId`);

CREATE INDEX `IX_IdentityResourceClaims_IdentityResourceId` ON `IdentityResourceClaims` (`IdentityResourceId`);

CREATE INDEX `IX_IdentityResourceProperties_IdentityResourceId` ON `IdentityResourceProperties` (`IdentityResourceId`);

CREATE UNIQUE INDEX `IX_IdentityResources_Name` ON `IdentityResources` (`Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210112235621_CreateConfiguration_MySql', '3.1.8');

