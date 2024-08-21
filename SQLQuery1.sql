CREATE TABLE [dbo].[Class] (
    [ClassId] [int] IDENTITY(1,1) NOT NULL,
    [ClassName] [nvarchar](20) NOT NULL,
    [TeacherId] [int] NOT NULL,
    [SubjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED ([ClassId] ASC),
FOREIGN KEY (TeacherId) REFERENCES [dbo].[Teacher](TeacherId)
) ON [PRIMARY]


CREATE TABLE [dbo].[ClassStudent] (
    [ClassId] [int] NOT NULL,
    [StudentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED ([ClassId] ASC, [StudentId] ASC),
FOREIGN KEY (StudentId) REFERENCES [dbo].[Student](StudentId),
FOREIGN KEY (ClassId) REFERENCES [dbo].[Class](ClassId)
) ON [PRIMARY]

CREATE TABLE [dbo].[Feedback] (
    [FeedbackId] [int] IDENTITY(1,1) NOT NULL,
    [StudentId] [int] NOT NULL,
    [TeacherId] [int] NOT NULL,
    [ClassId] [int] NOT NULL,
    [Rating] [int] NULL,
	[FeedbackText] [nvarchar](max) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
PRIMARY KEY CLUSTERED ([FeedbackId] ASC),
FOREIGN KEY (StudentId) REFERENCES [dbo].[Student](StudentId),
FOREIGN KEY (TeacherId) REFERENCES [dbo].[Teacher](TeacherId),
FOREIGN KEY (ClassId, StudentId) REFERENCES [dbo].[ClassStudent](ClassId, StudentId)
) ON [PRIMARY]



-- Bảng Class
CREATE TABLE [dbo].[Class] (
    [ClassId] [int] IDENTITY(1,1) NOT NULL,
    [ClassName] [nvarchar](20)  NOT NULL,
    [TeacherId] [int] NOT NULL,
    [SubjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED ([ClassId] ASC),
FOREIGN KEY (TeacherId) REFERENCES [dbo].[Teacher](TeacherId),
FOREIGN KEY (SubjectId) REFERENCES [dbo].[Subject](SubjectId)
) ON [PRIMARY]
GO

-- Bảng ClassStudent
CREATE TABLE [dbo].[ClassStudent] (
    [ClassId] [int] NOT NULL,
    [StudentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED ([ClassId] ASC, [StudentId] ASC),
FOREIGN KEY (ClassId) REFERENCES [dbo].[Class](ClassId),
FOREIGN KEY (StudentId) REFERENCES [dbo].[Student](StudentId)
) ON [PRIMARY]
GO

-- Bảng Feedback
CREATE TABLE [dbo].[Feedback] (
    [FeedbackId] [int] IDENTITY(1,1) NOT NULL,
    [StudentId] [int] NOT NULL,
    [ClassId] [int] NOT NULL,
    [Rating] [int] NULL,
	[FeedbackText] [nvarchar](max) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
PRIMARY KEY CLUSTERED ([FeedbackId] ASC),
FOREIGN KEY (StudentId) REFERENCES [dbo].[Student](StudentId),
FOREIGN KEY (ClassId) REFERENCES [dbo].[Class](ClassId)
) ON [PRIMARY]
GO
