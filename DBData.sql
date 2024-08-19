USE [Project_PRN_B5_1]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [ActiveCode]) VALUES (N'0614bb48-f675-4ec2-ab2b-2ad844a5b8e4', N'hoangdung1412003@gmail.com', N'HOANGDUNG1412003@GMAIL.COM', N'hoangdung1412003@gmail.com', N'HOANGDUNG1412003@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGnEaaEAJQ71D84rFuqDGoKoS+69Ujqc58/arrXhavstGXstkAhhk6lJZ5UgV4b1mw==', N'CPXIAAE7JTXLS4JBL4Z5NWWV5EDVR4YZ', N'44fac09e-ebd7-4cd3-8272-c7eb466fa73c', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [ActiveCode]) VALUES (N'5d9af95b-98ff-4a78-b48b-60a5b30c5dc7', N'dung@gmail.com', N'DUNG@GMAIL.COM', N'dung@gmail.com', N'DUNG@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJMMzeAWxsO9v3Aln7V9dvzSvVbTstkPNqlKfjXfMJElShd7YN8geuo5nHzdEWuf6w==', N'SDWFJIAPM6XDGYFYBH2NYWIKJDTEPLOH', N'abd83a6a-f8b1-494d-b7a7-cf8ff16a5410', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [ActiveCode]) VALUES (N'967e8155-0d67-4dee-a634-9363adb6afa1', N'string', N'STRING', N'string', N'STRING', 0, N'AQAAAAEAACcQAAAAEIsMgS9vvD9QGUhvaQyCN1URhA3JFrZ14FKmOLVl841wpRPaIYsYuV4Kn3Bpve0Vzw==', N'7F7DOMXXHNPKXJ23OFOZOICS4K7XBGAN', N'9595ec2b-97ed-47fa-8917-c7eae92ab99a', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [ActiveCode]) VALUES (N'f01cb77e-f7b5-41d6-8c92-9aedd3111d17', N'dunghoangf7.yhd@gmail.com', N'DUNGHOANGF7.YHD@GMAIL.COM', N'dunghoangf7.yhd@gmail.com', N'DUNGHOANGF7.YHD@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFpw1tm0niloCKTTSdgTrfNDU5vLr7VyaucZhdT94wwkmXyu/DGxAcpZxur9oVUWjw==', N'M3WIZ5M57FKJ5B3CZ43EEBAJZ27QSAKG', N'b2526515-bd15-4fe7-85bc-8a2b41a2a89a', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [ActiveCode]) VALUES (N'fa58e488-af9b-4520-b8ee-23eab01964c1', N'hoangdung141203@gmail.com', N'HOANGDUNG141203@GMAIL.COM', N'hoangdung141203@gmail.com', N'HOANGDUNG141203@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEhKLotHc+yoJKDqfkA1cvaYKHAvkfKUd1hb8qm1N9hozjY+M1Hv5LHKUmLJWAcsFg==', N'4P6R6TGMNLK2OLKXCXLTSN7WRHKS6KUC', N'7ed21e11-229e-4cad-9c77-2e7833c8ff6f', NULL, 0, 0, NULL, 1, 0, N'IdentityUser', NULL)
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (1, N'Mathematics')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (2, N'Physics')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (3, N'Chemistry')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (4, N'Biology')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (5, N'History')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (6, N'Geography')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (7, N'English')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (8, N'Computer Science')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (9, N'Physical Education')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName]) VALUES (10, N'Art')
GO
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (1, N'Professor Smith', 45, 1, N'0614bb48-f675-4ec2-ab2b-2ad844a5b8e4')
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (2, N'Professor Johnson', 50, 2, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (3, N'Professor Williams', 40, 3, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (4, N'Professor Brown', 38, 4, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (5, N'Professor Jones', 42, 5, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (6, N'Professor Garcia', 48, 6, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (7, N'Professor Miller', 36, 7, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (8, N'Professor Davis', 44, 8, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (9, N'Professor Martinez', 39, 9, NULL)
GO
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Age], [SubjectId], [AccountId]) VALUES (10, N'Professor Hernandez', 47, 10, NULL)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (1, N'Alice', 20, 1, N'0614bb48-f675-4ec2-ab2b-2ad844a5b8e4')
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (2, N'Bob', 22, 0, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (3, N'Charlie', 19, 1, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (4, N'David', 21, 1, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (5, N'Eve', 20, 0, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (6, N'Frank', 23, 1, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (7, N'Grace', 18, 0, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (8, N'Hannah', 22, 1, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (9, N'Ivy', 21, 0, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [IsRegularStudent], [AccountId]) VALUES (10, N'Jack', 19, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Evaluation] ON 
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (1, 85, N'Good performance', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (2, 90, N'Excellent work', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (3, 78, N'Needs improvement', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (4, 88, N'Well done', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (5, 92, N'Outstanding', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (6, 75, N'Satisfactory', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (7, 80, N'Good effort', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (8, 89, N'Great understanding', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (9, 76, N'Can do better', NULL)
GO
INSERT [dbo].[Evaluation] ([EvaluationId], [Grade], [AdditionExplanation], [StudentId]) VALUES (10, 91, N'Very good', NULL)
GO
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentDetails] ON 
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (1, N'123 Elm St', N'N/A', 1)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (2, N'456 Oak St', N'Part-time job', 2)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (3, N'789 Pine St', N'Sports team', 3)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (4, N'321 Maple St', N'N/A', 4)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (5, N'654 Cedar St', N'Music club', 5)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (6, N'987 Birch St', N'N/A', 6)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (7, N'147 Walnut St', N'Volunteer work', 7)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (8, N'258 Willow St', N'N/A', 8)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (9, N'369 Cherry St', N'N/A', 9)
GO
INSERT [dbo].[StudentDetails] ([StudentDetailsId], [Address], [AdditionalInformation], [StudentId]) VALUES (10, N'741 Fir St', N'Student council', 10)
GO
SET IDENTITY_INSERT [dbo].[StudentDetails] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240818195318_InitialIdentityMigration', N'6.0.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240818200133_InitialIdentityMigration1', N'6.0.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240818225345_RefreshToken', N'6.0.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240819042012_StudentForeignKey', N'6.0.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240819105918_ActiveCode', N'6.0.32')
GO
