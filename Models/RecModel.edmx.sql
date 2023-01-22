
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2022 09:51:51
-- Generated from EDMX file: C:\Users\maiss\Desktop\testest - Copie\Models\RecModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-testest-20221203115104];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Reponse_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reponse] DROP CONSTRAINT [FK_Reponse_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test_Question] DROP CONSTRAINT [FK_Table_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test_Question] DROP CONSTRAINT [FK_Table_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_TestResultat_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultat_TestSet] DROP CONSTRAINT [FK_TestResultat_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUsersResultat_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultat_TestSet] DROP CONSTRAINT [FK_AspNetUsersResultat_Test];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[Reponse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reponse];
GO
IF OBJECT_ID(N'[dbo].[Test]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Test];
GO
IF OBJECT_ID(N'[dbo].[Test_Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Test_Question];
GO
IF OBJECT_ID(N'[dbo].[Resultat_TestSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resultat_TestSet];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL,
    [DateNaissance] datetime  NULL,
    [Discriminator] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Question'
CREATE TABLE [dbo].[Question] (
    [Id] int  NOT NULL,
    [texte] nvarchar(50)  NULL,
    [noteTotale] decimal(18,0)  NULL
);
GO

-- Creating table 'Reponse'
CREATE TABLE [dbo].[Reponse] (
    [Id] int  NOT NULL,
    [texte] nvarchar(50)  NULL,
    [correcte] binary(50)  NULL,
    [Question_id] int  NULL
);
GO

-- Creating table 'Test'
CREATE TABLE [dbo].[Test] (
    [Id] int  NOT NULL,
    [nbrQuestion] int  NULL,
    [titreTest] nvarchar(50)  NULL,
    [duree] float  NULL
);
GO

-- Creating table 'Test_Question'
CREATE TABLE [dbo].[Test_Question] (
    [Id] int  NOT NULL,
    [Test_id] int  NULL,
    [Question_id] int  NULL
);
GO

-- Creating table 'Resultat_Test'
CREATE TABLE [dbo].[Resultat_Test] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [note] nvarchar(max)  NOT NULL,
    [date_affectation] nvarchar(max)  NOT NULL,
    [date_expiration] nvarchar(max)  NOT NULL,
    [TestId] int  NOT NULL,
    [AspNetUsersId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [PK_Question]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reponse'
ALTER TABLE [dbo].[Reponse]
ADD CONSTRAINT [PK_Reponse]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Test'
ALTER TABLE [dbo].[Test]
ADD CONSTRAINT [PK_Test]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Test_Question'
ALTER TABLE [dbo].[Test_Question]
ADD CONSTRAINT [PK_Test_Question]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Resultat_Test'
ALTER TABLE [dbo].[Resultat_Test]
ADD CONSTRAINT [PK_Resultat_Test]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [Question_id] in table 'Reponse'
ALTER TABLE [dbo].[Reponse]
ADD CONSTRAINT [FK_Reponse_Question]
    FOREIGN KEY ([Question_id])
    REFERENCES [dbo].[Question]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reponse_Question'
CREATE INDEX [IX_FK_Reponse_Question]
ON [dbo].[Reponse]
    ([Question_id]);
GO

-- Creating foreign key on [Question_id] in table 'Test_Question'
ALTER TABLE [dbo].[Test_Question]
ADD CONSTRAINT [FK_Table_Question]
    FOREIGN KEY ([Question_id])
    REFERENCES [dbo].[Question]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_Question'
CREATE INDEX [IX_FK_Table_Question]
ON [dbo].[Test_Question]
    ([Question_id]);
GO

-- Creating foreign key on [Test_id] in table 'Test_Question'
ALTER TABLE [dbo].[Test_Question]
ADD CONSTRAINT [FK_Table_Test]
    FOREIGN KEY ([Test_id])
    REFERENCES [dbo].[Test]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_Test'
CREATE INDEX [IX_FK_Table_Test]
ON [dbo].[Test_Question]
    ([Test_id]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [TestId] in table 'Resultat_Test'
ALTER TABLE [dbo].[Resultat_Test]
ADD CONSTRAINT [FK_TestResultat_Test]
    FOREIGN KEY ([TestId])
    REFERENCES [dbo].[Test]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestResultat_Test'
CREATE INDEX [IX_FK_TestResultat_Test]
ON [dbo].[Resultat_Test]
    ([TestId]);
GO

-- Creating foreign key on [AspNetUsersId] in table 'Resultat_Test'
ALTER TABLE [dbo].[Resultat_Test]
ADD CONSTRAINT [FK_AspNetUsersResultat_Test]
    FOREIGN KEY ([AspNetUsersId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsersResultat_Test'
CREATE INDEX [IX_FK_AspNetUsersResultat_Test]
ON [dbo].[Resultat_Test]
    ([AspNetUsersId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------