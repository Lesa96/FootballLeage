﻿/*
Deployment script for BazaZaLigu

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BazaZaLigu"
:setvar DefaultFilePrefix "BazaZaLigu"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[LogUser]...';


GO
CREATE TABLE [dbo].[LogUser] (
    [id_usera]       INT          NOT NULL,
    [username_usera] VARCHAR (30) NULL,
    [password_usera] VARCHAR (30) NULL,
    [role_usera]     VARCHAR (30) NULL,
    CONSTRAINT [user_pk] PRIMARY KEY CLUSTERED ([id_usera] ASC)
);


GO
PRINT N'Update complete.';


GO