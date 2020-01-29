Create database [DemoWebAppDB]
GO
USE [DemoWebAppDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Developers] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Age]      INT           NOT NULL,
    [JobTitle] NVARCHAR (50) NOT NULL
);


