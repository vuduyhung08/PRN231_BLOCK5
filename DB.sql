USE [master]
GO
/****** Object:  Database [BL5_Database_School]    Script Date: 8/14/2024 11:54:17 AM ******/
CREATE DATABASE [BL5_Database_School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BL5_Database_School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BL5_Database_School.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BL5_Database_School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BL5_Database_School_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BL5_Database_School] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BL5_Database_School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BL5_Database_School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BL5_Database_School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BL5_Database_School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BL5_Database_School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BL5_Database_School] SET ARITHABORT OFF 
GO
ALTER DATABASE [BL5_Database_School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BL5_Database_School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BL5_Database_School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BL5_Database_School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BL5_Database_School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BL5_Database_School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BL5_Database_School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BL5_Database_School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BL5_Database_School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BL5_Database_School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BL5_Database_School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BL5_Database_School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BL5_Database_School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BL5_Database_School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BL5_Database_School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BL5_Database_School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BL5_Database_School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BL5_Database_School] SET RECOVERY FULL 
GO
ALTER DATABASE [BL5_Database_School] SET  MULTI_USER 
GO
ALTER DATABASE [BL5_Database_School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BL5_Database_School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BL5_Database_School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BL5_Database_School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BL5_Database_School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BL5_Database_School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BL5_Database_School', N'ON'
GO
ALTER DATABASE [BL5_Database_School] SET QUERY_STORE = OFF
GO
USE [BL5_Database_School]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[EvaluationId] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NOT NULL,
	[AdditionExplanation] [nvarchar](100) NULL,
	[StudentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Age] [int] NULL,
	[IsRegularStudent] [bit] NULL,
	[AccountId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDetails]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDetails](
	[StudentDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[AdditionalInformation] [nvarchar](50) NULL,
	[StudentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 8/14/2024 11:54:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Age] [int] NULL,
	[SubjectId] [int] NULL,
	[AccountId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (1, N'alice@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (2, N'bob@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (3, N'charlie@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (4, N'david@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (5, N'eve@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (6, N'frank@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (7, N'grace@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (8, N'hannah@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (9, N'ivy@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (10, N'jack@example.com', N'password123', 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (12, N'admin@gmail.com', N'password123', 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [Type]) VALUES (13, N'teacher1@gmail.com', N'password123', 3)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (1, 85, N'Good performance', 1)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (2, 90, N'Excellent work', 2)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (3, 78, N'Needs improvement', 3)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (4, 88, N'Well done', 4)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (5, 92, N'Outstanding', 5)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (6, 75, N'Satisfactory', 6)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (7, 80, N'Good effort', 7)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (8, 89, N'Great understanding', 8)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (9, 76, N'Can do better', 9)
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (10, 91, N'Very good', 10)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (1, N'Alice', 20, 1, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (2, N'Bob', 22, 0, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (3, N'Charlie', 19, 1, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (4, N'David', 21, 1, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (5, N'Eve', 20, 0, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (6, N'Frank', 23, 1, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (7, N'Grace', 18, 0, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (8, N'Hannah', 22, 1, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (9, N'Ivy', 21, 0, NULL)
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (10, N'Jack', 19, 1, NULL)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentDetails] ON 

INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (1, N'123 Elm St', N'N/A', 1)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (2, N'456 Oak St', N'Part-time job', 2)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (3, N'789 Pine St', N'Sports team', 3)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (4, N'321 Maple St', N'N/A', 4)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (5, N'654 Cedar St', N'Music club', 5)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (6, N'987 Birch St', N'N/A', 6)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (7, N'147 Walnut St', N'Volunteer work', 7)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (8, N'258 Willow St', N'N/A', 8)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (9, N'369 Cherry St', N'N/A', 9)
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (10, N'741 Fir St', N'Student council', 10)
SET IDENTITY_INSERT [dbo].[StudentDetails] OFF
GO
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (1, 1)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (1, 3)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (2, 2)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (2, 4)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (3, 5)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (4, 6)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (5, 7)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (6, 8)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (7, 9)
INSERT [dbo].[StudentSubject] ([StudentId], [SubjectId]) VALUES (8, 10)
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (1, N'Mathematics')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (2, N'Physics')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (3, N'Chemistry')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (4, N'Biology')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (5, N'History')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (6, N'Geography')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (7, N'English')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (8, N'Computer Science')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (9, N'Physical Education')
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (10, N'Art')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (1, N'Professor Smith', 45, 1, 1)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (2, N'Professor Johnson', 50, 2, 2)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (3, N'Professor Williams', 40, 3, 3)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (4, N'Professor Brown', 38, 4, 4)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (5, N'Professor Jones', 42, 5, 5)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (6, N'Professor Garcia', 48, 6, 6)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (7, N'Professor Miller', 36, 7, 7)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (8, N'Professor Davis', 44, 8, 8)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (9, N'Professor Martinez', 39, 9, 9)
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (10, N'Professor Hernandez', 47, 10, 10)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Account]
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_Student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Subject]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Account]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Subject]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [CK_Type_Check] CHECK  (([Type]>=(1) AND [Type]<=(3)))
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [CK_Type_Check]
GO
USE [master]
GO
ALTER DATABASE [BL5_Database_School] SET  READ_WRITE 
GO
