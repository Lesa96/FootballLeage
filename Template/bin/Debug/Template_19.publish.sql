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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Creating [dbo].[Igrac]...';


GO
CREATE TABLE [dbo].[Igrac] (
    [id_igraca]          INT          NOT NULL,
    [ime_igraca]         VARCHAR (20) NULL,
    [prezime_igraca]     VARCHAR (30) NULL,
    [vodi_id_trenera]    INT          NULL,
    [vodi_naziv]         VARCHAR (30) NULL,
    [naziv_kluba]        VARCHAR (30) NULL,
    [odigranih_utakmica] INT          NULL,
    [postignutih_golova] INT          NULL,
    [prosek_golova]      FLOAT (53)   NULL,
    CONSTRAINT [igrac_pk] PRIMARY KEY CLUSTERED ([id_igraca] ASC)
);


GO
PRINT N'Creating [dbo].[Ima]...';


GO
CREATE TABLE [dbo].[Ima] (
    [igrac_id_igraca]      INT NOT NULL,
    [menadzer_id_menagera] INT NOT NULL,
    CONSTRAINT [ima_pk] PRIMARY KEY CLUSTERED ([igrac_id_igraca] ASC, [menadzer_id_menagera] ASC)
);


GO
PRINT N'Creating [dbo].[Klub]...';


GO
CREATE TABLE [dbo].[Klub] (
    [naziv]        VARCHAR (30) NOT NULL,
    [grad]         VARCHAR (30) NULL,
    [liga_id_lige] INT          NULL,
    CONSTRAINT [klub_pk] PRIMARY KEY CLUSTERED ([naziv] ASC)
);


GO
PRINT N'Creating [dbo].[Liga]...';


GO
CREATE TABLE [dbo].[Liga] (
    [id_lige]      INT          NOT NULL,
    [naziv_lige]   VARCHAR (30) NULL,
    [drzava_lige]  VARCHAR (30) NULL,
    [broj_klubova] INT          NULL,
    CONSTRAINT [liga_pk] PRIMARY KEY CLUSTERED ([id_lige] ASC)
);


GO
PRINT N'Creating [dbo].[Menadzer]...';


GO
CREATE TABLE [dbo].[Menadzer] (
    [ime_menagera]     VARCHAR (30) NULL,
    [prezime_menagera] VARCHAR (30) NULL,
    [id_menagera]      INT          NOT NULL,
    CONSTRAINT [menadzer_pk] PRIMARY KEY CLUSTERED ([id_menagera] ASC)
);


GO
PRINT N'Creating [dbo].[Navija]...';


GO
CREATE TABLE [dbo].[Navija] (
    [klub_naziv]          VARCHAR (30) NOT NULL,
    [navijac_id_navijaca] INT          NOT NULL,
    CONSTRAINT [navija_pk] PRIMARY KEY CLUSTERED ([klub_naziv] ASC, [navijac_id_navijaca] ASC)
);


GO
PRINT N'Creating [dbo].[Navijac]...';


GO
CREATE TABLE [dbo].[Navijac] (
    [id_navijaca]      INT          NOT NULL,
    [ime_navijaca]     VARCHAR (20) NULL,
    [prezime_navijaca] VARCHAR (30) NULL,
    CONSTRAINT [navijac_pk] PRIMARY KEY CLUSTERED ([id_navijaca] ASC)
);


GO
PRINT N'Creating [dbo].[Obezbedjenje]...';


GO
CREATE TABLE [dbo].[Obezbedjenje] (
    [ime_radnika]     VARCHAR (30) NULL,
    [prezime_radnika] VARCHAR (30) NULL,
    [id_radnika]      INT          NOT NULL,
    CONSTRAINT [obezbedjenje_pk] PRIMARY KEY CLUSTERED ([id_radnika] ASC)
);


GO
PRINT N'Creating [dbo].[Poseduje]...';


GO
CREATE TABLE [dbo].[Poseduje] (
    [klub_naziv]          VARCHAR (30) NOT NULL,
    [stadion_id_stadiona] INT          NOT NULL,
    CONSTRAINT [poseduje_pk] PRIMARY KEY CLUSTERED ([klub_naziv] ASC, [stadion_id_stadiona] ASC)
);


GO
PRINT N'Creating [dbo].[Pripada]...';


GO
CREATE TABLE [dbo].[Pripada] (
    [klub_naziv]          VARCHAR (30) NOT NULL,
    [vlasnik_id_vlasnika] INT          NOT NULL,
    CONSTRAINT [pripada_pk] PRIMARY KEY CLUSTERED ([klub_naziv] ASC, [vlasnik_id_vlasnika] ASC)
);


GO
PRINT N'Creating [dbo].[Sponzor]...';


GO
CREATE TABLE [dbo].[Sponzor] (
    [id_sponzora] INT          NOT NULL,
    [naziv]       VARCHAR (30) NULL,
    CONSTRAINT [Sponzor_PK] PRIMARY KEY CLUSTERED ([id_sponzora] ASC)
);


GO
PRINT N'Creating [dbo].[Sponzorise]...';


GO
CREATE TABLE [dbo].[Sponzorise] (
    [liga_id_lige]        INT NOT NULL,
    [sponzor_id_sponzora] INT NOT NULL,
    CONSTRAINT [Sponzorise_PK] PRIMARY KEY CLUSTERED ([liga_id_lige] ASC, [sponzor_id_sponzora] ASC)
);


GO
PRINT N'Creating [dbo].[Stadion]...';


GO
CREATE TABLE [dbo].[Stadion] (
    [naziv_stadiona] VARCHAR (30) NULL,
    [id_stadiona]    INT          NOT NULL,
    CONSTRAINT [stadion_pk] PRIMARY KEY CLUSTERED ([id_stadiona] ASC)
);


GO
PRINT N'Creating [dbo].[Sudija]...';


GO
CREATE TABLE [dbo].[Sudija] (
    [ime_sudije]          VARCHAR (15) NULL,
    [prezime_sudije]      VARCHAR (20) NULL,
    [id_sudije]           INT          NOT NULL,
    [nacionalnost_sudije] VARCHAR (30) NULL,
    [liga_id_lige]        INT          NULL,
    CONSTRAINT [Sudija_PK] PRIMARY KEY CLUSTERED ([id_sudije] ASC)
);


GO
PRINT N'Creating [dbo].[Trener]...';


GO
CREATE TABLE [dbo].[Trener] (
    [ime_trenera]     VARCHAR (30) NULL,
    [prezime_trenera] VARCHAR (30) NULL,
    [id_trenera]      INT          NOT NULL,
    CONSTRAINT [trener_pk] PRIMARY KEY CLUSTERED ([id_trenera] ASC)
);


GO
PRINT N'Creating [dbo].[Vlasnik]...';


GO
CREATE TABLE [dbo].[Vlasnik] (
    [ime_vlasnika]     VARCHAR (30) NULL,
    [prezime_vlasnika] VARCHAR (30) NULL,
    [id_vlasnika]      INT          NOT NULL,
    CONSTRAINT [vlasnik_pk] PRIMARY KEY CLUSTERED ([id_vlasnika] ASC)
);


GO
PRINT N'Creating [dbo].[Vodi]...';


GO
CREATE TABLE [dbo].[Vodi] (
    [trener_id_trenera] INT          NOT NULL,
    [klub_naziv]        VARCHAR (30) NOT NULL,
    CONSTRAINT [vodi_pk] PRIMARY KEY CLUSTERED ([trener_id_trenera] ASC, [klub_naziv] ASC)
);


GO
PRINT N'Creating [dbo].[Zaposljava]...';


GO
CREATE TABLE [dbo].[Zaposljava] (
    [obezbedjenje_id_radnika]      INT          NOT NULL,
    [poseduje_klub_naziv]          VARCHAR (30) NOT NULL,
    [poseduje_stadion_id_stadiona] INT          NOT NULL,
    CONSTRAINT [zaposljava_pk] PRIMARY KEY CLUSTERED ([obezbedjenje_id_radnika] ASC, [poseduje_klub_naziv] ASC, [poseduje_stadion_id_stadiona] ASC)
);


GO
PRINT N'Creating [dbo].[igrac_vodi_fk]...';


GO
ALTER TABLE [dbo].[Igrac] WITH NOCHECK
    ADD CONSTRAINT [igrac_vodi_fk] FOREIGN KEY ([vodi_id_trenera], [vodi_naziv]) REFERENCES [dbo].[Vodi] ([trener_id_trenera], [klub_naziv]);


GO
PRINT N'Creating [dbo].[igrac_klub_fk]...';


GO
ALTER TABLE [dbo].[Igrac] WITH NOCHECK
    ADD CONSTRAINT [igrac_klub_fk] FOREIGN KEY ([naziv_kluba]) REFERENCES [dbo].[Klub] ([naziv]);


GO
PRINT N'Creating [dbo].[ima_igrac_fk]...';


GO
ALTER TABLE [dbo].[Ima] WITH NOCHECK
    ADD CONSTRAINT [ima_igrac_fk] FOREIGN KEY ([igrac_id_igraca]) REFERENCES [dbo].[Igrac] ([id_igraca]);


GO
PRINT N'Creating [dbo].[ima_menadzer_fk]...';


GO
ALTER TABLE [dbo].[Ima] WITH NOCHECK
    ADD CONSTRAINT [ima_menadzer_fk] FOREIGN KEY ([menadzer_id_menagera]) REFERENCES [dbo].[Menadzer] ([id_menagera]);


GO
PRINT N'Creating [dbo].[klub_liga_fk]...';


GO
ALTER TABLE [dbo].[Klub] WITH NOCHECK
    ADD CONSTRAINT [klub_liga_fk] FOREIGN KEY ([liga_id_lige]) REFERENCES [dbo].[Liga] ([id_lige]);


GO
PRINT N'Creating [dbo].[navija_klub_fk]...';


GO
ALTER TABLE [dbo].[Navija] WITH NOCHECK
    ADD CONSTRAINT [navija_klub_fk] FOREIGN KEY ([klub_naziv]) REFERENCES [dbo].[Klub] ([naziv]);


GO
PRINT N'Creating [dbo].[navija_navijac_fk]...';


GO
ALTER TABLE [dbo].[Navija] WITH NOCHECK
    ADD CONSTRAINT [navija_navijac_fk] FOREIGN KEY ([navijac_id_navijaca]) REFERENCES [dbo].[Navijac] ([id_navijaca]);


GO
PRINT N'Creating [dbo].[poseduje_klub_fk]...';


GO
ALTER TABLE [dbo].[Poseduje] WITH NOCHECK
    ADD CONSTRAINT [poseduje_klub_fk] FOREIGN KEY ([klub_naziv]) REFERENCES [dbo].[Klub] ([naziv]);


GO
PRINT N'Creating [dbo].[poseduje_stadion_fk]...';


GO
ALTER TABLE [dbo].[Poseduje] WITH NOCHECK
    ADD CONSTRAINT [poseduje_stadion_fk] FOREIGN KEY ([stadion_id_stadiona]) REFERENCES [dbo].[Stadion] ([id_stadiona]);


GO
PRINT N'Creating [dbo].[pripada_klub_fk]...';


GO
ALTER TABLE [dbo].[Pripada] WITH NOCHECK
    ADD CONSTRAINT [pripada_klub_fk] FOREIGN KEY ([klub_naziv]) REFERENCES [dbo].[Klub] ([naziv]);


GO
PRINT N'Creating [dbo].[pripada_vlasnik_fk]...';


GO
ALTER TABLE [dbo].[Pripada] WITH NOCHECK
    ADD CONSTRAINT [pripada_vlasnik_fk] FOREIGN KEY ([vlasnik_id_vlasnika]) REFERENCES [dbo].[Vlasnik] ([id_vlasnika]);


GO
PRINT N'Creating [dbo].[sponzorise_liga_fk]...';


GO
ALTER TABLE [dbo].[Sponzorise] WITH NOCHECK
    ADD CONSTRAINT [sponzorise_liga_fk] FOREIGN KEY ([liga_id_lige]) REFERENCES [dbo].[Liga] ([id_lige]);


GO
PRINT N'Creating [dbo].[sponzorise_sponzor_fk]...';


GO
ALTER TABLE [dbo].[Sponzorise] WITH NOCHECK
    ADD CONSTRAINT [sponzorise_sponzor_fk] FOREIGN KEY ([sponzor_id_sponzora]) REFERENCES [dbo].[Sponzor] ([id_sponzora]);


GO
PRINT N'Creating [dbo].[sudija_liga_fk]...';


GO
ALTER TABLE [dbo].[Sudija] WITH NOCHECK
    ADD CONSTRAINT [sudija_liga_fk] FOREIGN KEY ([liga_id_lige]) REFERENCES [dbo].[Liga] ([id_lige]);


GO
PRINT N'Creating [dbo].[vodi_klub_fk]...';


GO
ALTER TABLE [dbo].[Vodi] WITH NOCHECK
    ADD CONSTRAINT [vodi_klub_fk] FOREIGN KEY ([klub_naziv]) REFERENCES [dbo].[Klub] ([naziv]);


GO
PRINT N'Creating [dbo].[vodi_trener_fk]...';


GO
ALTER TABLE [dbo].[Vodi] WITH NOCHECK
    ADD CONSTRAINT [vodi_trener_fk] FOREIGN KEY ([trener_id_trenera]) REFERENCES [dbo].[Trener] ([id_trenera]);


GO
PRINT N'Creating [dbo].[zaposljava_obezbedjenje_fk]...';


GO
ALTER TABLE [dbo].[Zaposljava] WITH NOCHECK
    ADD CONSTRAINT [zaposljava_obezbedjenje_fk] FOREIGN KEY ([obezbedjenje_id_radnika]) REFERENCES [dbo].[Obezbedjenje] ([id_radnika]);


GO
PRINT N'Creating [dbo].[zaposljava_poseduje_fk]...';


GO
ALTER TABLE [dbo].[Zaposljava] WITH NOCHECK
    ADD CONSTRAINT [zaposljava_poseduje_fk] FOREIGN KEY ([poseduje_klub_naziv], [poseduje_stadion_id_stadiona]) REFERENCES [dbo].[Poseduje] ([klub_naziv], [stadion_id_stadiona]);


GO
PRINT N'Creating [dbo].[Prosek]...';


GO
CREATE FUNCTION [dbo].[Prosek]
(
	@param1 int,
	@param2 int
)
RETURNS FLOAT
AS
BEGIN
	RETURN @param1 / @param2
END
GO
PRINT N'Creating [dbo].[SumProcedura]...';


GO
CREATE PROCEDURE [dbo].[SumProcedura]
	
AS
  	SELECT ime_trenera 
	FROM Trener,Vodi
	WHERE Trener.id_trenera = Vodi.trener_id_trenera
	ORDER BY Trener.ime_trenera
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Igrac] WITH CHECK CHECK CONSTRAINT [igrac_vodi_fk];

ALTER TABLE [dbo].[Igrac] WITH CHECK CHECK CONSTRAINT [igrac_klub_fk];

ALTER TABLE [dbo].[Ima] WITH CHECK CHECK CONSTRAINT [ima_igrac_fk];

ALTER TABLE [dbo].[Ima] WITH CHECK CHECK CONSTRAINT [ima_menadzer_fk];

ALTER TABLE [dbo].[Klub] WITH CHECK CHECK CONSTRAINT [klub_liga_fk];

ALTER TABLE [dbo].[Navija] WITH CHECK CHECK CONSTRAINT [navija_klub_fk];

ALTER TABLE [dbo].[Navija] WITH CHECK CHECK CONSTRAINT [navija_navijac_fk];

ALTER TABLE [dbo].[Poseduje] WITH CHECK CHECK CONSTRAINT [poseduje_klub_fk];

ALTER TABLE [dbo].[Poseduje] WITH CHECK CHECK CONSTRAINT [poseduje_stadion_fk];

ALTER TABLE [dbo].[Pripada] WITH CHECK CHECK CONSTRAINT [pripada_klub_fk];

ALTER TABLE [dbo].[Pripada] WITH CHECK CHECK CONSTRAINT [pripada_vlasnik_fk];

ALTER TABLE [dbo].[Sponzorise] WITH CHECK CHECK CONSTRAINT [sponzorise_liga_fk];

ALTER TABLE [dbo].[Sponzorise] WITH CHECK CHECK CONSTRAINT [sponzorise_sponzor_fk];

ALTER TABLE [dbo].[Sudija] WITH CHECK CHECK CONSTRAINT [sudija_liga_fk];

ALTER TABLE [dbo].[Vodi] WITH CHECK CHECK CONSTRAINT [vodi_klub_fk];

ALTER TABLE [dbo].[Vodi] WITH CHECK CHECK CONSTRAINT [vodi_trener_fk];

ALTER TABLE [dbo].[Zaposljava] WITH CHECK CHECK CONSTRAINT [zaposljava_obezbedjenje_fk];

ALTER TABLE [dbo].[Zaposljava] WITH CHECK CHECK CONSTRAINT [zaposljava_poseduje_fk];


GO
PRINT N'Update complete.';


GO
