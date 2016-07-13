--This file is missing commands to make it a working sql script. It's just a guideline how to create the database

CREATE TABLE [dbo].[Kouti] (
    [Id]       INT           NOT NULL,
    [Location] NVARCHAR (50) NULL,
    CONSTRAINT [pk_KId] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Proion] (
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_PName] PRIMARY KEY CLUSTERED ([Name] ASC)
);

CREATE TABLE [dbo].[Sxesi] (
    [KoutiId]       INT           NOT NULL,
    [ProionName]    NVARCHAR (50) NOT NULL,
    [KoutiLocation] NVARCHAR (50) NULL,
    CONSTRAINT [pk_SId] PRIMARY KEY CLUSTERED ([KoutiId] ASC, [ProionName] ASC),
    CONSTRAINT [fk_PName] FOREIGN KEY ([ProionName]) REFERENCES [dbo].[Proion] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [fk_KId] FOREIGN KEY ([KoutiId]) REFERENCES [dbo].[Kouti] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
CREATE TRIGGER updLocTrigger ON KOUTI
FOR UPDATE
AS
	DECLARE @Location NVARCHAR(50);
	DECLARE @Id Int;
	SELECT @Location=i.Location from inserted i;
	SELECT @Id=i.Id from inserted i;

	UPDATE Sxesi SET KoutiLocation=@Location WHERE KoutiId=@Id;

