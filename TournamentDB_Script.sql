-- Creating the Match table and it's relationship
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfMatch] [datetime] NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[TournamentId] [int] NOT NULL,
	[Team1Id] [int] NOT NULL,
	[Team2Id] [int] NOT NULL,
 CONSTRAINT [PK__Match__3214EC070F3AEAA5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD FOREIGN KEY([Team1Id])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [Match_fk0] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [Match_fk0]
GO


--Creating  the Player table and it's relationship
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Nationality] [varchar](100) NOT NULL,
	[Age] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [Player_fk0] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [Player_fk0]
GO


--Creating the Team table and it's relationship
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--Creating the User table and it's relationship
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Role] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--Creating the Tournament table and it's relationship
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tournament](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TournamentName] [varchar](100) NOT NULL,
	[PrizePool] [varchar](100) NOT NULL,
	[EntryFee] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[TournamentType] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Tourname__3214EC0730533A52] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [Tournament_fk0] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tournament] CHECK CONSTRAINT [Tournament_fk0]
GO


--Creating the Nationality table
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nationality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Creating the Location table
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--Modifying the table and relationship of Match
USE [Tournament]
GO

ALTER TABLE [dbo].[Match] DROP COLUMN [Location]
GO

ALTER TABLE [dbo].[Match] ADD [LocationId] [int] NOT NULL
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [Match_fk1] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [Match_fk1]
GO


--Modifying the table and relationship of Player
USE [Tournament]
GO

ALTER TABLE [dbo].[Player] DROP COLUMN [Nationality]
GO

ALTER TABLE [dbo].[Player]	DROP COLUMN [Age]
GO

ALTER TABLE [dbo].[Player] ADD [NationalityId] [int] NOT NULL
GO

ALTER TABLE [dbo].[Player] ADD [DateOfBirth] [datetime] NOT NULL
GO

ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [Player_fk1] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationality] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [Player_fk1]
GO

-- Creating the TournamentType table
USE [Tournament]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TournamentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Modifying the Tournament table and establishing the relationship
USE [Tournament]
GO

ALTER TABLE [dbo].[Tournament] DROP COLUMN [TournamentType]
GO

ALTER TABLE [dbo].[Tournament] ADD [TournamentTypeId] [int] NOT NULL
GO

ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [Tournament_fk1] FOREIGN KEY([TournamentTypeId])
REFERENCES [dbo].[TournamentType] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tournament] CHECK CONSTRAINT [Tournament_fk1]
GO

-- Adding relationship between Match.Team2Id and Team.Id
USE [Tournament]
GO

ALTER TABLE [dbo].[Match] WITH CHECK ADD CONSTRAINT [Match_fk2] FOREIGN KEY([Team2Id])
REFERENCES [dbo].[Team] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [Match_fk2]
GO

--Adding Salt column in User Table
ALTER TABLE [dbo].[User] ADD [Salt] [varchar](100) NOT NULL
GO