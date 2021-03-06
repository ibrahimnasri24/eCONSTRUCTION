USE [master]
GO
/****** Object:  Database [eCONSTRUCT]    Script Date: 26/07/2021 07:51:00 PM ******/
CREATE DATABASE [eCONSTRUCT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eCONSTRUCT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCONSTRUCT.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eCONSTRUCT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCONSTRUCT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eCONSTRUCT] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eCONSTRUCT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eCONSTRUCT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET ARITHABORT OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [eCONSTRUCT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eCONSTRUCT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eCONSTRUCT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eCONSTRUCT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eCONSTRUCT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eCONSTRUCT] SET  MULTI_USER 
GO
ALTER DATABASE [eCONSTRUCT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eCONSTRUCT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eCONSTRUCT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eCONSTRUCT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eCONSTRUCT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eCONSTRUCT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [eCONSTRUCT] SET QUERY_STORE = OFF
GO
USE [eCONSTRUCT]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[TaskID] [int] NOT NULL,
	[WorkerID] [int] NOT NULL,
	[AmountPaid] [money] NOT NULL,
	[PaymentDate] [date] NOT NULL,
 CONSTRAINT [Payments_PK] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC,
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workforce]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workforce](
	[WorkerID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[HoursWorked] [int] NULL,
	[HourlyRate] [money] NULL,
	[TaskRate] [money] NULL,
 CONSTRAINT [Workforce_PK] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC,
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](30) NOT NULL,
	[Email] [varchar](100) NULL,
	[Gender] [varchar](10) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[OtherDetails] [varchar](200) NULL,
	[Image] [image] NULL,
	[AdressID] [int] NOT NULL,
 CONSTRAINT [Persons_PK] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[WorkerID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Field] [varchar](50) NOT NULL,
	[Company] [varchar](50) NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [Workers_PK] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Workers_Persons_AK] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NULL,
	[Field] [varchar](50) NOT NULL,
	[TaskName] [varchar](50) NOT NULL,
	[InitiationDate] [date] NULL,
	[TerminationDate] [date] NULL,
	[EstimatedDuration] [int] NOT NULL,
	[ActualDuration] [int] NULL,
	[PhaseID] [int] NOT NULL,
	[WorkerID] [int] NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [Tasks_PK] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MyPayments]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[MyPayments] AS
SELECT Image, CONCAT(FirstName, ' ', LastName) AS txtName, Workers.WorkerID, Tasks.TaskID, TaskName, AmountPaid, PaymentDate, HourlyRate , HoursWorked , TaskRate
FROM Persons, Workers, Tasks, Payments, Workforce
WHERE Persons.PersonID = Workers.PersonID
AND Tasks.TaskID = Payments.TaskID
AND Workers.WorkerID = Payments.WorkerID
AND Workforce.TaskID  = Tasks.TaskID
AND Workforce.WorkerID  = Workers.WorkerID
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AdressID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[Building] [varchar](50) NULL,
	[Latitude] [varchar](20) NULL,
	[Longitude] [varchar](20) NULL,
 CONSTRAINT [Addresses_PK] PRIMARY KEY CLUSTERED 
(
	[AdressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machinery]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machinery](
	[MachineID] [int] IDENTITY(1,1) NOT NULL,
	[CostPerHour] [money] NOT NULL,
	[ExtraDetails] [varchar](100) NULL,
	[GuideLink] [varchar](100) NULL,
	[MachineName] [varchar](50) NOT NULL,
	[Field] [varchar](50) NOT NULL,
	[Image] [image] NULL,
	[SuppliersID] [int] NOT NULL,
 CONSTRAINT [Machinery_PK] PRIMARY KEY CLUSTERED 
(
	[MachineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MachineryOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineryOrdered](
	[MachineID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[DurationOfRent] [int] NOT NULL,
 CONSTRAINT [MachineryOrdered_PK] PRIMARY KEY CLUSTERED 
(
	[MachineID] ASC,
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [varchar](50) NOT NULL,
	[CostPerUnit] [money] NOT NULL,
	[ExpirationDate] [date] NULL,
	[ExtraDetails] [varchar](100) NULL,
	[Unit] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[Image] [image] NULL,
	[Field] [varchar](50) NOT NULL,
	[SuppliersID] [int] NOT NULL,
 CONSTRAINT [Materials_PK] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialsOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialsOrdered](
	[MaterialID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [MaterialsOrdered_PK] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC,
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phases]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phases](
	[PhaseID] [int] IDENTITY(1,1) NOT NULL,
	[PhaseName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [Phases_PK] PRIMARY KEY CLUSTERED 
(
	[PhaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[InitiationDate] [date] NOT NULL,
	[TerminationDate] [date] NULL,
	[DueDate] [date] NULL,
	[ProjectType] [varchar](20) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[SiteID] [int] NOT NULL,
 CONSTRAINT [Projects_PK] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sites]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sites](
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [varchar](50) NOT NULL,
	[Area] [int] NOT NULL,
	[PricePerMeterSquared] [money] NULL,
	[AdressID] [int] NOT NULL,
 CONSTRAINT [Sites_PK] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Sites_Addresses_AK] UNIQUE NONCLUSTERED 
(
	[AdressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SiteName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SuppliersID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[ContactTitle] [varchar](50) NULL,
	[Phone] [varchar](30) NOT NULL,
	[Fax] [varchar](30) NULL,
	[Website] [varchar](50) NULL,
 CONSTRAINT [Suppliers_PK] PRIMARY KEY CLUSTERED 
(
	[SuppliersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[CostPerHour] [money] NOT NULL,
	[ExtraDetails] [varchar](100) NULL,
	[GuideLink] [varchar](100) NULL,
	[VehicleName] [varchar](50) NOT NULL,
	[Field] [varchar](50) NOT NULL,
	[Image] [image] NULL,
	[SuppliersID] [int] NOT NULL,
 CONSTRAINT [Vehicles_PK] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiclesOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiclesOrdered](
	[VehicleID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[DurationOfRent] [int] NOT NULL,
 CONSTRAINT [VehiclesOrdered_PK] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC,
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Machinery]  WITH CHECK ADD  CONSTRAINT [Machinery_Suppliers_FK] FOREIGN KEY([SuppliersID])
REFERENCES [dbo].[Suppliers] ([SuppliersID])
GO
ALTER TABLE [dbo].[Machinery] CHECK CONSTRAINT [Machinery_Suppliers_FK]
GO
ALTER TABLE [dbo].[MachineryOrdered]  WITH CHECK ADD  CONSTRAINT [MachineryOrdered_Machinery_FK] FOREIGN KEY([MachineID])
REFERENCES [dbo].[Machinery] ([MachineID])
GO
ALTER TABLE [dbo].[MachineryOrdered] CHECK CONSTRAINT [MachineryOrdered_Machinery_FK]
GO
ALTER TABLE [dbo].[MachineryOrdered]  WITH CHECK ADD  CONSTRAINT [MachineryOrdered_Tasks0_FK] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[MachineryOrdered] CHECK CONSTRAINT [MachineryOrdered_Tasks0_FK]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [Materials_Suppliers_FK] FOREIGN KEY([SuppliersID])
REFERENCES [dbo].[Suppliers] ([SuppliersID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [Materials_Suppliers_FK]
GO
ALTER TABLE [dbo].[MaterialsOrdered]  WITH CHECK ADD  CONSTRAINT [MaterialsOrdered_Materials_FK] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Materials] ([MaterialID])
GO
ALTER TABLE [dbo].[MaterialsOrdered] CHECK CONSTRAINT [MaterialsOrdered_Materials_FK]
GO
ALTER TABLE [dbo].[MaterialsOrdered]  WITH CHECK ADD  CONSTRAINT [MaterialsOrdered_Tasks0_FK] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[MaterialsOrdered] CHECK CONSTRAINT [MaterialsOrdered_Tasks0_FK]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [Payments_Tasks_FK] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [Payments_Tasks_FK]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [Payments_Workers_FK] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Workers] ([WorkerID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [Payments_Workers_FK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Persons_Addresses_FK] FOREIGN KEY([AdressID])
REFERENCES [dbo].[Addresses] ([AdressID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Persons_Addresses_FK]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [Projects_Sites_FK] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [Projects_Sites_FK]
GO
ALTER TABLE [dbo].[Sites]  WITH CHECK ADD  CONSTRAINT [Sites_Addresses_FK] FOREIGN KEY([AdressID])
REFERENCES [dbo].[Addresses] ([AdressID])
GO
ALTER TABLE [dbo].[Sites] CHECK CONSTRAINT [Sites_Addresses_FK]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_Phases_FK] FOREIGN KEY([PhaseID])
REFERENCES [dbo].[Phases] ([PhaseID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_Phases_FK]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_Projects1_FK] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_Projects1_FK]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_Workers0_FK] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Workers] ([WorkerID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_Workers0_FK]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [Vehicles_Suppliers_FK] FOREIGN KEY([SuppliersID])
REFERENCES [dbo].[Suppliers] ([SuppliersID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [Vehicles_Suppliers_FK]
GO
ALTER TABLE [dbo].[VehiclesOrdered]  WITH CHECK ADD  CONSTRAINT [VehiclesOrdered_Tasks0_FK] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[VehiclesOrdered] CHECK CONSTRAINT [VehiclesOrdered_Tasks0_FK]
GO
ALTER TABLE [dbo].[VehiclesOrdered]  WITH CHECK ADD  CONSTRAINT [VehiclesOrdered_Vehicles_FK] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
GO
ALTER TABLE [dbo].[VehiclesOrdered] CHECK CONSTRAINT [VehiclesOrdered_Vehicles_FK]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [Workers_Persons_FK] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [Workers_Persons_FK]
GO
ALTER TABLE [dbo].[Workforce]  WITH CHECK ADD  CONSTRAINT [Workforce_Tasks_FK] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[Workforce] CHECK CONSTRAINT [Workforce_Tasks_FK]
GO
ALTER TABLE [dbo].[Workforce]  WITH CHECK ADD  CONSTRAINT [Workforce_Workers_FK] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Workers] ([WorkerID])
GO
ALTER TABLE [dbo].[Workforce] CHECK CONSTRAINT [Workforce_Workers_FK]
GO
/****** Object:  StoredProcedure [dbo].[addAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- address 
CREATE PROCEDURE [dbo].[addAddress]
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50),
	@Latitude varchar(20),
	@Longitude varchar(20)
	AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Addresses (Country, City, Street, Building, Latitude,Longitude)
	VALUES (@Country, @City, @Street, @Building, @Latitude,@Longitude)
END
GO
/****** Object:  StoredProcedure [dbo].[addMachine]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addMachine]    Script Date: 07/06/2021 07:29:58 PM ******/
--Machine
CREATE PROCEDURE [dbo].[addMachine]
	-- Add the parameters for the stored procedure here
	
        @MachineName  Varchar (50),
		@Field		  Varchar (50),
		@Image		  Image,
        @CostPerHour  Money  ,
        @ExtraDetails Varchar (100) ,
        @GuideLink    Varchar (100) ,
        @SuppliersID  Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Machinery (MachineName, Field, Image, CostPerHour ,ExtraDetails ,GuideLink,SuppliersID)
	VALUES (@MachineName, @Field, @Image, @CostPerHour ,@ExtraDetails ,@GuideLink,@SuppliersID)
END
GO
/****** Object:  StoredProcedure [dbo].[addMachineOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addMachineOrdered]    Script Date: 07/06/2021 07:30:19 PM ******/
--Machine Ordered
CREATE PROCEDURE [dbo].[addMachineOrdered]
	-- Add the parameters for the stored procedure here
	    @MachineID      Int  ,
        @TaskID         Int,
        @DurationOfRent Int
     
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO MachineryOrdered (MachineID,TaskID,DurationOfRent)
	VALUES (@MachineID,@TaskID,@DurationOfRent)
END
GO
/****** Object:  StoredProcedure [dbo].[addMaterial]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addMaterial]    Script Date: 07/06/2021 07:30:28 PM ******/
--Material
CREATE PROCEDURE [dbo].[addMaterial]
	-- Add the parameters for the stored procedure here
		@MaterialName  Varchar (50),
		@Field		  Varchar (50),
		@Image		  Image,
        @CostPerUnit    Money,
        @ExpirationDate Date  ,
        @ExtraDetails   Varchar (100) ,
        @Unit           Varchar (50)  ,
        @Category       Varchar (50)  ,
        @SuppliersID    Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Materials (MaterialName, Field, Image, CostPerUnit,ExpirationDate,ExtraDetails ,Unit , Category  ,SuppliersID)
	VALUES (@MaterialName, @Field, @Image, @CostPerUnit,@ExpirationDate,@ExtraDetails ,@Unit,@Category,@SuppliersID)
END
GO
/****** Object:  StoredProcedure [dbo].[addMaterialOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addMaterialOrdered]    Script Date: 07/06/2021 07:30:43 PM ******/
--Material ordered
CREATE PROCEDURE [dbo].[addMaterialOrdered]
	-- Add the parameters for the stored procedure here
	    
        @MaterialID		  int,
		@TaskID			  int,
		@Quantity         Float
      
     
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO MaterialsOrdered (MaterialID, TaskID, Quantity)
	VALUES (@MaterialID, @TaskID, @Quantity)
END
GO
/****** Object:  StoredProcedure [dbo].[addPayment]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addPayment]    Script Date: 07/06/2021 07:30:58 PM ******/
CREATE PROCEDURE [dbo].[addPayment]
	-- Add the parameters for the stored procedure here

	    @TaskID int ,
		@WorkerID Int,
	    @AmountPaid  Money  ,
        @PaymentDate Date 
     
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Payments(TaskID, WorkerID,AmountPaid,PaymentDate )
	VALUES (@TaskID,@WorkerID,@AmountPaid,@PaymentDate)
END
GO
/****** Object:  StoredProcedure [dbo].[addPerson]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addPerson]    Script Date: 07/06/2021 07:31:07 PM ******/
--Person
CREATE PROCEDURE [dbo].[addPerson]
	-- Add the parameters for the stored procedure here
	
        @FirstName    Varchar (50)  ,
        @MiddleName   Varchar (100) ,
        @LastName     Varchar (50)  ,
        @PhoneNumber  Varchar (30) ,
        @Email        Varchar (100) ,
        @Gender       Varchar (10) ,
        @DateOfBirth  Date  ,
        @OtherDetails Varchar (200) ,
		@Image		  Image,
        @AdressID     Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Persons (FirstName,MiddleName,LastName,PhoneNumber,Email,Gender,DateOfBirth,OtherDetails, Image,AdressID)
	VALUES (@FirstName,@MiddleName,@LastName,@PhoneNumber,@Email,@Gender,@DateOfBirth,@OtherDetails, @Image,@AdressID)
END
GO
/****** Object:  StoredProcedure [dbo].[addPersonWithAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addPersonWithAddress]    Script Date: 18/07/2021 01:12:34 PM ******/
CREATE PROCEDURE [dbo].[addPersonWithAddress]
	--Address
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50),
	--Person
	@FirstName    Varchar (50)  ,
    @MiddleName   Varchar (100) ,
    @LastName     Varchar (50)  ,
    @PhoneNumber  Varchar (30) ,
    @Email        Varchar (100) ,
    @Gender       Varchar (10) ,
    @DateOfBirth  Date  ,
    @OtherDetails Varchar (200) ,
	@Image Image,
	@PersonID int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Addresses (Country, City, Street, Building)
	VALUES (@Country, @City, @Street, @Building)
	DECLARE @AddressID int
	SET @AddressID = SCOPE_IDENTITY()
	
	INSERT INTO Persons (FirstName,MiddleName,LastName,PhoneNumber,Email,Gender,DateOfBirth,OtherDetails, Image,AdressID)
	VALUES (@FirstName,@MiddleName,@LastName,@PhoneNumber,@Email,@Gender,@DateOfBirth,@OtherDetails, @Image,@AddressID)
	SET @PersonID = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[addPhase]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/****** Object:  StoredProcedure [dbo].[addPhase]    Script Date: 07/06/2021 07:31:25 PM ******/
CREATE PROCEDURE [dbo].[addPhase]
	-- Add the parameters for the stored procedure here
	    
       @PhaseName   Varchar (50) ,
       @Description Varchar (200)
      
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Phases ( PhaseName, Description )
	VALUES ( @PhaseName, @Description)
END
GO
/****** Object:  StoredProcedure [dbo].[addProject]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addProject]    Script Date: 07/06/2021 07:31:35 PM ******/
--Project
CREATE PROCEDURE [dbo].[addProject]
	-- Add the parameters for the stored procedure here
	@ProjectName varchar(50),
	@InitiationDate Date,
	@TerminationDate Date,
	@DueDate Date,
	@ProjectType varchar(20),
	@Description varchar(500),
	@SiteID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Projects (ProjectName, InitiationDate, TerminationDate, DueDate,ProjectType, Description, SiteID)
	VALUES (@ProjectName, @InitiationDate, @TerminationDate, @DueDate, @ProjectType, @Description, @SiteID)
END
GO
/****** Object:  StoredProcedure [dbo].[addSite]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addSite]    Script Date: 07/06/2021 07:31:44 PM ******/
--Site
CREATE PROCEDURE [dbo].[addSite]
    @SiteName				 Varchar (50),
	@Area					 int,
	@PricePerMeterSquared    Money ,
    @AdressID				 Int 
	AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Sites (SiteName, Area, PricePerMeterSquared, AdressID)
	VALUES (@SiteName, @Area, @PricePerMeterSquared, @AdressID)
END
GO
/****** Object:  StoredProcedure [dbo].[addSiteAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addSiteAddress]    Script Date: 07/06/2021 07:31:50 PM ******/
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addSiteAddress]
	-- Add the parameters for the stored procedure here
	@SiteName Varchar (50),
    @Area int,
	@PricePerMeterSquared Money ,
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Latitude varchar(20),
	@Longitude varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Addresses (Country, City, Street, Latitude,Longitude)
	VALUES (@Country, @City, @Street, @Latitude,@Longitude)
	DECLARE @AddressID int
	SET @AddressID = SCOPE_IDENTITY()
	INSERT INTO Sites (SiteName, Area, PricePerMeterSquared,AdressID)
	VALUES (@SiteName, @Area, @PricePerMeterSquared, @AddressID)
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[addSupplier]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addSupplier]    Script Date: 07/06/2021 07:31:55 PM ******/
CREATE PROCEDURE [dbo].[addSupplier]
	-- Add the parameters for the stored procedure here
	    @CompanyName  Varchar (50)  ,
        @ContactName  Varchar (50),
        @ContactTitle Varchar (50) ,
        @Phone        Varchar (30) ,
        @Fax          Varchar (30) ,
        @Website      Varchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Suppliers (CompanyName, ContactName , ContactTitle, Phone  , Fax ,Website)
	VALUES (@CompanyName, @ContactName , @ContactTitle, @Phone  , @Fax ,@Website)
END
GO
/****** Object:  StoredProcedure [dbo].[addTask]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addTask]
	-- Add the parameters for the stored procedure here
	    @Description       Varchar (500) ,
        @Field             Varchar (50) ,
        @TaskName          Varchar (50) ,
        @InitiationDate    Date ,
        @EstimatedDuration Int  ,
        @PhaseID           Int  ,
        @ProjectID         Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Tasks (  Description  ,Field ,TaskName  ,InitiationDate ,EstimatedDuration ,PhaseID, ProjectID  )
	VALUES ( @Description  ,@Field ,@TaskName   ,@InitiationDate  ,@EstimatedDuration ,@PhaseID, @ProjectID)
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[addVehicle]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addVehicle]    Script Date: 07/06/2021 07:32:28 PM ******/
--Vehicle
CREATE PROCEDURE [dbo].[addVehicle]
	-- Add the parameters for the stored procedure here
		@VehicleName  Varchar (50),
        @Field        Varchar (50),
		@Image		  Image,
        @CostPerHour  Money  ,
        @ExtraDetails Varchar (100) ,
        @GuideLink    Varchar (100) ,
        @SuppliersID  Int 
      
     
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Vehicles (VehicleName, Field, Image, CostPerHour ,ExtraDetails ,GuideLink ,SuppliersID  )
	VALUES (@VehicleName, @Field, @Image, @CostPerHour ,@ExtraDetails ,@GuideLink ,@SuppliersID)
END
GO
/****** Object:  StoredProcedure [dbo].[addVehicleOrdered]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addVehicleOrdered]    Script Date: 07/06/2021 07:32:51 PM ******/
--Vehicle Ordered
CREATE PROCEDURE [dbo].[addVehicleOrdered]
	-- Add the parameters for the stored procedure here
	    @VehicleID int,
		@TaskID         Int,
        @DurationOfRent Int
      
      
     
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO VehiclesOrdered (VehicleID,TaskID,DurationOfRent)
	VALUES (@VehicleID,@TaskID,@DurationOfRent)
END
GO
/****** Object:  StoredProcedure [dbo].[addWorker]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addWorker]    Script Date: 07/06/2021 07:32:59 PM ******/
--worker
CREATE PROCEDURE [dbo].[addWorker]
	-- Add the parameters for the stored procedure here
	
        @Title        Varchar (50)  ,
        @Field Varchar (50)  ,
        @Company Varchar(50),
		@PersonID Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Workers (Title  ,Field ,Company,PersonID)
	VALUES (@Title  ,@Field ,@Company,@PersonID)
END
GO
/****** Object:  StoredProcedure [dbo].[addWorkerWithPersonWithAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[addWorkerWithPersonWithAddress]    Script Date: 18/07/2021 01:14:31 PM ******/
CREATE PROCEDURE [dbo].[addWorkerWithPersonWithAddress]

	--Worker
	@Title      Varchar (50),
    @Field		Varchar (50),
    @Company	Varchar(50),

	--Person
	@FirstName    Varchar (50)  ,
    @MiddleName   Varchar (100) ,
    @LastName     Varchar (50)  ,
    @PhoneNumber  Varchar (30) ,
    @Email        Varchar (100) ,
    @Gender       Varchar (10) ,
    @DateOfBirth  Date  ,
    @OtherDetails Varchar (200) ,
	@Image Image,

	--Address
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @PersonID	Int
	EXEC [dbo].[addPersonWithAddress]	
										@Country	 ,
										@City		 ,
										@Street		 ,
										@Building	 ,
										@FirstName   ,
										@MiddleName  ,
										@LastName    ,
										@PhoneNumber ,
										@Email       ,
										@Gender      ,
										@DateOfBirth ,
										@OtherDetails,
										@Image       ,
										@PersonID output;

	EXEC [dbo].[addWorker]				@Title   , 
   										@Field	 ,
										@Company ,
										@PersonID;
END
GO
/****** Object:  StoredProcedure [dbo].[addWorkforce]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addWorkforce]
	-- Add the parameters for the stored procedure here
	@WorkerID int,
	@TaskID int,
	@HourlyRate Money,
	@TaskRate Money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Workforce(WorkerID, TaskID, HourlyRate, TaskRate)
	VALUES(@WorkerID, @TaskID, @HourlyRate, @TaskRate)
END
GO
/****** Object:  StoredProcedure [dbo].[editAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editAddress]
	-- Add the parameters for the stored procedure here
	@AddressID int,
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50),
	@Latitude varchar(20),
	@Longitude varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Addresses
	SET Country = @Country, City = @City, Street = @Street, Building = @Building, Latitude = @Latitude,Longitude = @Longitude
	WHERE AdressID = @AddressID
END
GO
/****** Object:  StoredProcedure [dbo].[editMachine]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editMachine]
	-- Add the parameters for the stored procedure here
		@MachineID		int,
		@MachineName  Varchar (50),
		@Field		  Varchar (50),
		@Image		  Image,
        @CostPerHour  Money  ,
        @ExtraDetails Varchar (100) ,
        @GuideLink    Varchar (100) ,
        @SuppliersID  Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE Machinery

	SET  MachineName = @MachineName
		,Field = @Field
		,Image = @Image
		,CostPerHour = @CostPerHour
		,ExtraDetails= @ExtraDetails
		,GuideLink= @GuideLink
		,SuppliersID = @SuppliersID
	
	WHERE MachineID = @MachineID
END
GO
/****** Object:  StoredProcedure [dbo].[editMaterial]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editMaterial]
	-- Add the parameters for the stored procedure here
		@MaterialID		int,
	    @MaterialName  Varchar (50),
		@Field		  Varchar (50),
		@Image		  Image,
        @CostPerUnit    Money,
        @ExpirationDate Date  ,
        @ExtraDetails   Varchar (100) ,
        @Unit           Varchar (50)  ,
        @Category       Varchar (50)  ,
        @SuppliersID    Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE Materials

	SET  MaterialName= @MaterialName
		,Field = @Field
		,Image = @Image
		,CostPerUnit = @CostPerUnit
		,ExtraDetails= @ExtraDetails
		,SuppliersID = @SuppliersID
		,Unit = @Unit
        ,Category= @Category
		, ExpirationDate = @ExpirationDate
	WHERE MaterialID = @MaterialID
END
GO
/****** Object:  StoredProcedure [dbo].[editPerson]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editPerson]
	-- Add the parameters for the stored procedure here
		@PersonID	  int,
        @FirstName    Varchar (50)  ,
        @MiddleName   Varchar (100) ,
        @LastName     Varchar (50)  ,
        @PhoneNumber  Varchar (30) ,
        @Email        Varchar (100) ,
        @Gender       Varchar (10) ,
        @DateOfBirth  Date  ,
        @OtherDetails Varchar (200) ,
		@Image		  Image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Persons
	SET FirstName = @FirstName
		,MiddleName = @MiddleName
		,LastName = @LastName
		,PhoneNumber = @PhoneNumber
		,Email= @Email
		,Gender= @Gender
		,DateOfBirth = @DateOfBirth
		,OtherDetails = @OtherDetails
		,Image = @Image
	WHERE PersonID = @PersonID
END
GO
/****** Object:  StoredProcedure [dbo].[editPersonWithAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editPersonWithAddress] 
	-- Add the parameters for the stored procedure here
	@PersonID int,
	--Address
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50),
	--Person
	@FirstName    Varchar (50)  ,
    @MiddleName   Varchar (100) ,
    @LastName     Varchar (50)  ,
    @PhoneNumber  Varchar (30) ,
    @Email        Varchar (100) ,
    @Gender       Varchar (10) ,
    @DateOfBirth  Date  ,
    @OtherDetails Varchar (200) ,
	@Image Image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @AddressID int
	SET @AddressID = ISNULL((SELECT AdressID FROM Persons WHERE PersonID = @PersonID),0)
	EXEC [dbo].[editAddress]			@AddressID	 ,
										@Country	 ,
										@City		 ,
										@Street		 ,
										@Building	 ,
										NULL,
										NULL
	EXEC [dbo].[editPerson]				@PersonID	 ,
										@FirstName   ,
										@MiddleName  ,
										@LastName    ,
										@PhoneNumber ,
										@Email       ,
										@Gender      ,
										@DateOfBirth ,
										@OtherDetails,
										@Image       
END
GO
/****** Object:  StoredProcedure [dbo].[editSupplier]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editSupplier]
	-- Add the parameters for the stored procedure here
		@SuppliersID int,
	    @CompanyName  Varchar (50)  ,
        @ContactName  Varchar (50),
        @ContactTitle Varchar (50) ,
        @Phone        Varchar (30) ,
        @Fax          Varchar (30) ,
        @Website      Varchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Suppliers
	SET
	     CompanyName  = @CompanyName
        ,ContactName  = @ContactName
        ,ContactTitle = @ContactTitle
        ,Phone        = @Phone      
        ,Fax          = @Fax        
        ,Website      = @Website
	WHERE SuppliersID = @SuppliersID
END
GO
/****** Object:  StoredProcedure [dbo].[editTask]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editTask]
	-- Add the parameters for the stored procedure here
		@TaskID			   int ,
	    @Description       Varchar (500) ,
        @Field             Varchar (50) ,
        @TaskName          Varchar (50) ,
        @InitiationDate    Date ,
        @EstimatedDuration Int  ,
        @PhaseID           Int  ,
        @ProjectID         Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Tasks
	SET
		Description = @Description
		,Field = @Field
		,TaskName = @TaskName
		,InitiationDate = @InitiationDate
		,EstimatedDuration = @EstimatedDuration
		,PhaseID = @PhaseID
		,ProjectID = @ProjectID
	WHERE TaskID = @TaskID
END
GO
/****** Object:  StoredProcedure [dbo].[editVehicle]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editVehicle]
	-- Add the parameters for the stored procedure here
		@VehicleID	int,
	    @VehicleName  Varchar (50),
        @Field        Varchar (50),
		@Image		  Image,
        @CostPerHour  Money  ,
        @ExtraDetails Varchar (100) ,
        @GuideLink    Varchar (100) ,
        @SuppliersID  Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE Vehicles 

	SET  VehicleName= @vehicleName
		,Field = @Field
		,Image = @Image
		,CostPerHour = @CostPerHour
		,ExtraDetails= @ExtraDetails
		,GuideLink= @GuideLink
		,SuppliersID = @SuppliersID
		
	
	WHERE VehicleID = @VehicleID
END
GO
/****** Object:  StoredProcedure [dbo].[editWorker]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editWorker]
	-- Add the parameters for the stored procedure here
		@WorkerID int,
        @Title        Varchar (50)  ,
        @Field Varchar (50)  ,
        @Company Varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Workers
	SET Title = @Title ,Field = @Field,Company = @Company
	WHERE WorkerID = @WorkerID
END
GO
/****** Object:  StoredProcedure [dbo].[editWorkerWithPersonWithAddress]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editWorkerWithPersonWithAddress]
	-- Add the parameters for the stored procedure here
	@WorkerID int,
	--Address
    @Country varchar(50),
	@City  varchar(50),
	@Street varchar(50),
	@Building varchar(50),
	
	--Person
	@FirstName    Varchar (50)  ,
    @MiddleName   Varchar (100) ,
    @LastName     Varchar (50)  ,
    @PhoneNumber  Varchar (30) ,
    @Email        Varchar (100) ,
    @Gender       Varchar (10) ,
    @DateOfBirth  Date  ,
    @OtherDetails Varchar (200) ,
	@Image Image,

	--Worker
	@Title      Varchar (50),
    @Field		Varchar (50),
    @Company	Varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @PersonID int
	SET @PersonID = ISNULL((SELECT PersonID FROM Workers WHERE WorkerID = @WorkerID),0)

	EXEC [dbo].[editPersonWithAddress]  @PersonID	 ,
										@Country	 ,
										@City		 ,
										@Street		 ,
										@Building	 ,
										@FirstName   ,
										@MiddleName  ,
										@LastName    ,
										@PhoneNumber ,
										@Email       ,
										@Gender      ,
										@DateOfBirth ,
										@OtherDetails,
										@Image   
										
	EXEC [dbo].[editWorker]				@WorkerID	 ,
										@Title		 ,
										@Field		 ,
										@Company
END
GO
/****** Object:  StoredProcedure [dbo].[editWorkforce]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editWorkforce]
	-- Add the parameters for the stored procedure here
	@WorkerID int,
	@TaskID int,
	@HourlyRate Money,
	@HoursWorked int,
	@TaskRate Money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Workforce
	SET 
		HourlyRate = @HourlyRate
		,HoursWorked = @HoursWorked
		,TaskRate = @TaskRate
	WHERE WorkerID = @WorkerID AND TaskID = @TaskID
END
GO
/****** Object:  StoredProcedure [dbo].[findTasksBetweenTwoDates]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[findTasksBetweenTwoDates] 
	-- Add the parameters for the stored procedure here
	@Date1 Date,
	@Date2 Date,
	@ProjectID int,
	@Field varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@ProjectID = 0) BEGIN
		IF(@Field = 'ALL') BEGIN
			SELECT *
			FROM Tasks
			WHERE @Date1 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR  @Date2 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR InitiationDate BETWEEN @Date1 AND @Date2
			OR DATEADD(DAY, EstimatedDuration -1 , InitiationDate) BETWEEN @Date1 AND @Date2;
			PRINT 1;
		END
		ELSE BEGIN
			SELECT *
			FROM Tasks
			WHERE Field = @Field 
			AND (@Date1 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR  @Date2 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR InitiationDate BETWEEN @Date1 AND @Date2
			OR DATEADD(DAY, EstimatedDuration-1, InitiationDate) BETWEEN @Date1 AND @Date2);
			PRINT @Field;
		END
	END
	ELSE BEGIN
		IF(@Field = 'ALL') BEGIN
			SELECT *
			FROM Tasks
			WHERE  ProjectID = @ProjectID
			AND (@Date1 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR  @Date2 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR InitiationDate BETWEEN @Date1 AND @Date2
			OR DATEADD(DAY, EstimatedDuration-1, InitiationDate) BETWEEN @Date1 AND @Date2);
			PRINT 3;
		END
		ELSE BEGIN
			SELECT *
			FROM Tasks
			WHERE Field = @Field
			AND ProjectID = @ProjectID
			AND (@Date1 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR  @Date2 BETWEEN InitiationDate AND DATEADD(DAY, EstimatedDuration-1, InitiationDate)
			OR InitiationDate BETWEEN @Date1 AND @Date2
			OR DATEADD(DAY, EstimatedDuration-1, InitiationDate) BETWEEN @Date1 AND @Date2);
			PRINT 4
			Print @ProjectID;
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[findWorkersOnTask]    Script Date: 26/07/2021 07:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[findWorkersOnTask] 
	-- Add the parameters for the stored procedure here
	@TaskID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT WorkerID FROM Workforce WHERE TaskID = @TaskID
END
GO
USE [master]
GO
ALTER DATABASE [eCONSTRUCT] SET  READ_WRITE 
GO
