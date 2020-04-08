CREATE DATABASE [Ips];
USE  [Ips]

CREATE TABLE [dbo].[Persona](
	[Identificacion] [nvarchar](10) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](50) NULL,
	[ValorHospital] [numeric](18, 0) NULL,
	[Edad] [numeric](18, 0) NULL,
	[Pulsacion] [numeric](18, 0) NULL,
) 
GO

COMMIT