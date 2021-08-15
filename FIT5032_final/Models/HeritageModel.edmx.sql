
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/14/2021 22:20:28
-- Generated from EDMX file: D:\Coding_Monash\P5032\FIT5032_final\FIT5032_final\FIT5032_final\Models\HeritageModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FIT5032_final-20210813113035];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HeritageSet'
CREATE TABLE [dbo].[HeritageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [RouteId] int  NOT NULL
);
GO

-- Creating table 'RouteSet'
CREATE TABLE [dbo].[RouteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UpdatedDate] datetime  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HeritageSet'
ALTER TABLE [dbo].[HeritageSet]
ADD CONSTRAINT [PK_HeritageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RouteSet'
ALTER TABLE [dbo].[RouteSet]
ADD CONSTRAINT [PK_RouteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RouteId] in table 'HeritageSet'
ALTER TABLE [dbo].[HeritageSet]
ADD CONSTRAINT [FK_RouteHeritage]
    FOREIGN KEY ([RouteId])
    REFERENCES [dbo].[RouteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RouteHeritage'
CREATE INDEX [IX_FK_RouteHeritage]
ON [dbo].[HeritageSet]
    ([RouteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------