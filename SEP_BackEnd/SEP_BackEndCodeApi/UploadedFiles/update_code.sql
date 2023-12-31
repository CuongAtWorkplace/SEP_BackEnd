USE [DB_SEP490]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[ChatRoomId] [int] IDENTITY(1,1) NOT NULL,
	[ChatRoomName] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[isManagerChat] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ChatRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[NumberStudent] [int] NULL,
	[Topic] [nvarchar](50) NULL,
	[QuizzeId] [int] NULL,
	[Schedule] [nvarchar](255) NULL,
	[Fee] [nvarchar](50) NULL,
	[NumberOfWeek] [nvarchar](50) NULL,
	[NumberPhone] [nvarchar](10) NULL,
	[Description] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [int] NULL,
	[IsDelete] [bit] NULL,
	[TokenClass] [nvarchar](225) NULL,
	[Classname] [nvarchar](225) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[Description] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[Image] [nvarchar](225) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[FromUserId] [int] NULL,
	[Rating] [int] NULL,
	[Description] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[ModifileDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListStudentClass]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListStudentClass](
	[ListStudentInClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ListStudentInClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[LoginHistory] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TimeLog] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[ChatRoomId] [int] NULL,
	[CreateBy] [int] NULL,
	[Content] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[Photo] [varchar](225) NULL,
PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](225) NULL,
	[Description] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationUser]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationUser](
	[NotificationUserId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[NotificationId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Content] [nvarchar](225) NULL,
	[IsReaded] [bit] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[NotificationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[CreateBy] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](225) NULL,
	[ContentPost] [nvarchar](225) NULL,
	[LikeAmout] [int] NULL,
	[Image] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuizzeId] [int] NULL,
	[Question] [nvarchar](225) NULL,
	[Answer] [nvarchar](100) NULL,
	[IsMultiQuestion] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizze]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizze](
	[QuizzeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](225) NULL,
	[CreateBy] [int] NULL,
	[WorkingTime] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[NumberOfQuestion] [int] NULL,
	[QuizzeCategory] [nvarchar](100) NULL,
	[IsDraft] [bit] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizzeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizzeAnswer]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizzeAnswer](
	[QuizzeAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NULL,
	[Answer] [nvarchar](100) NULL,
	[IsCorrect] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizzeAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizzeInClass]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizzeInClass](
	[QuizzeInClass] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NULL,
	[QuizzeId] [int] NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizzeInClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizzeResult]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizzeResult](
	[QuizzeResultId] [int] IDENTITY(1,1) NOT NULL,
	[QuizzeId] [int] NULL,
	[UserId] [int] NULL,
	[Score] [int] NULL,
	[CreateDate] [datetime] NULL,
	[NumberOfTrue] [int] NULL,
	[NumberOfFalse] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizzeResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportUser]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportUser](
	[ReportUserId] [int] IDENTITY(1,1) NOT NULL,
	[FromUser] [int] NULL,
	[ToUser] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Reason] [nvarchar](255) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [nvarchar](200) NULL,
	[Modified] [datetime] NULL,
	[EvidenceImage] [nvarchar](255) NULL,
	[IsChecked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomCallVideo]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomCallVideo](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](100) NULL,
	[TeacherId] [int] NULL,
	[ClassId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusClass]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusClass](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](225) NULL,
	[Email] [nvarchar](225) NULL,
	[Password] [nvarchar](225) NULL,
	[Phone] [nvarchar](12) NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](225) NULL,
	[FeedbackId] [int] NULL,
	[RoleId] [int] NULL,
	[Token] [nvarchar](225) NULL,
	[IsBan] [bit] NULL,
	[Balance] [money] NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChatRoom]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChatRoom](
	[UserChatRoomId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ChatRoomId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserChatRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCommentPost]    Script Date: 10/25/2023 10:34:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCommentPost](
	[UserCommentPostId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PostId] [int] NULL,
	[Content] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[LikeAmount] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserCommentPostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (1, 2, 1, 30, NULL, NULL, NULL, N'300000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'SEP_490')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (2, 2, 1, 30, NULL, NULL, NULL, N'100000', N'30', NULL, N'Its very great', CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-03T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'English101')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (3, 2, 1, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-04T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'English_102')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (4, 2, 1, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-04T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'English_103')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (5, 2, 1, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-05T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Engilsh_104')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (6, 2, 2, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-06T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Math_101')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (7, 2, 2, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-07T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Math_102')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (8, 2, 2, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-08T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Math_103')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (9, 2, 3, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-09T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Biology_101')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (10, 2, 3, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-10T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Biology_102')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (11, 2, 3, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-11T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Biology_103')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (12, 2, 4, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2003-02-12T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Physic_101')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (13, 2, 4, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2001-02-13T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Physic_102')
INSERT [dbo].[Class] ([ClassId], [TeacherId], [CourseId], [NumberStudent], [Topic], [QuizzeId], [Schedule], [Fee], [NumberOfWeek], [NumberPhone], [Description], [CreateDate], [StartDate], [EndDate], [Status], [IsDelete], [TokenClass], [Classname]) VALUES (14, 2, 4, 30, NULL, NULL, NULL, N'10000', N'30', NULL, N'The Basic English Communication Class is a course that provides students with fundamental knowledge
', CAST(N'2009-02-09T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), CAST(N'2001-02-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'physic_103')
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseName], [Description], [CreateDate], [Image], [IsDelete]) VALUES (1, N'English', N'aaaaaaaa', CAST(N'2001-02-01T00:00:00.000' AS DateTime), N'EnglishCourse.jpg', NULL)
INSERT [dbo].[Course] ([CourseId], [CourseName], [Description], [CreateDate], [Image], [IsDelete]) VALUES (2, N'Math', N'Math is Great', CAST(N'2001-02-11T00:00:00.000' AS DateTime), N'Math.jpg', NULL)
INSERT [dbo].[Course] ([CourseId], [CourseName], [Description], [CreateDate], [Image], [IsDelete]) VALUES (3, N'Biology ', N'Biology is Cool', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'biology.jpg', NULL)
INSERT [dbo].[Course] ([CourseId], [CourseName], [Description], [CreateDate], [Image], [IsDelete]) VALUES (4, N'Physic', N'physic is cool', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Physic.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackId], [FromUserId], [Rating], [Description], [CreateDate], [ModifileDate], [IsDelete]) VALUES (1, 1, 3, N'a', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[ListStudentClass] ON 

INSERT [dbo].[ListStudentClass] ([ListStudentInClassId], [ClassId], [UserId], [CreateDate]) VALUES (54, 9, 3, CAST(N'2023-10-10T19:26:42.790' AS DateTime))
INSERT [dbo].[ListStudentClass] ([ListStudentInClassId], [ClassId], [UserId], [CreateDate]) VALUES (55, 6, 3, CAST(N'2023-10-23T22:12:04.383' AS DateTime))
INSERT [dbo].[ListStudentClass] ([ListStudentInClassId], [ClassId], [UserId], [CreateDate]) VALUES (56, 6, 3, CAST(N'2023-10-23T22:12:14.450' AS DateTime))
INSERT [dbo].[ListStudentClass] ([ListStudentInClassId], [ClassId], [UserId], [CreateDate]) VALUES (57, 6, 4, CAST(N'2023-10-24T00:36:12.557' AS DateTime))
INSERT [dbo].[ListStudentClass] ([ListStudentInClassId], [ClassId], [UserId], [CreateDate]) VALUES (58, 3, 4, CAST(N'2023-10-24T00:39:53.387' AS DateTime))
SET IDENTITY_INSERT [dbo].[ListStudentClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (1, 3, N'Check 23', N'Test 1 + test2  + test 3 + test4', N'Bioloy', 0, N'638336750795219092.jpg', CAST(N'2023-10-18T00:24:25.957' AS DateTime), 1)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (2, 3, N'string', N'string', N'aaaa', 0, N'638336737464228472.jpg', CAST(N'2023-10-18T00:24:25.957' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (3, 3, N'string', N'string', N'aaaa', 0, N'638336732081479802.jpg', CAST(N'2023-10-18T00:24:25.957' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (4, 3, N'Cương', N'H2 công O2', N'selectedItem', 0, N'638333083304318912.jpg', CAST(N'2023-10-18T00:45:58.133' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (5, 3, N'Test', N'Abac', N'selectDropdownRef', 0, N'638333083304318912.jpg', CAST(N'2023-10-18T00:54:11.257' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (6, 3, N'Test', N'Abac', N'aaaa', 0, N'638336732261557330.jpg', CAST(N'2023-10-18T00:24:25.957' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (7, 3, N'Test', N'Abac', N'aaaa', 0, N'638336368496165427.jpg', CAST(N'2023-10-18T00:57:21.943' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (8, 3, N'Test', N'Abac', N'selectedItem', 0, N'image.jpg', CAST(N'2023-10-18T01:00:16.353' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (9, 3, N'Test', N'Abac', N'selectedItem', 0, N'638333083304318912.jpg', CAST(N'2023-10-18T01:01:13.287' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (10, 3, N'Test', N'Abac', N'selectedItem', 0, N'638331625319529233.jpg', CAST(N'2023-10-18T01:02:12.457' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (11, 3, N'Caau nayf khos quas', N'2 + 2 banwlg may', N'Math', 0, N'638333080641992509.jpg', CAST(N'2023-10-19T17:27:44.647' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (12, 3, N'Caau nayf khos quas', N'2 + 2 banwlg may', N'Math', 0, N'638333080694143199.jpg', CAST(N'2023-10-19T17:27:49.583' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (13, 3, N'Agahs', N'Ahsisijbd', N'English', 0, N'638333083034529148.jpg', CAST(N'2023-10-19T17:31:43.673' AS DateTime), 0)
INSERT [dbo].[Post] ([PostId], [CreateBy], [Title], [Description], [ContentPost], [LikeAmout], [Image], [CreateDate], [IsActive]) VALUES (14, 3, N'Agahs', N'Ahsisijbd', N'English', 0, N'638333083304318912.jpg', CAST(N'2023-10-19T17:32:10.693' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Teacher')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Student')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FullName], [Email], [Password], [Phone], [Image], [Description], [Address], [FeedbackId], [RoleId], [Token], [IsBan], [Balance], [CreateDate]) VALUES (2, N'NgoBaCuong', N'Ngobacuong2211@gmail.com', N'aaaa', N'094477577', N'header_essay-final-michel-par11617.jpg', N'a', N'a', 1, 1, NULL, NULL, 70000.0000, NULL)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Password], [Phone], [Image], [Description], [Address], [FeedbackId], [RoleId], [Token], [IsBan], [Balance], [CreateDate]) VALUES (3, N'CUONG XINH TRAI', N'Cuongnbhe164516@fpt.edu.vn', N'Cuong2211', N'0964918288', N'3_638329567004710945.jpg', N'a', N'Sài gòn , việt nam', 1, 2, NULL, NULL, 70000.0000, NULL)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Password], [Phone], [Image], [Description], [Address], [FeedbackId], [RoleId], [Token], [IsBan], [Balance], [CreateDate]) VALUES (4, N'NgoBaCuong', N'Ngobacuong2211@gmail.com', N'aaaa', N'094477577', N'header_essay-final-michel-par11617.jpg', N'a', N'a', 1, 2, NULL, NULL, 680000.0000, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__CourseId__59063A47] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__CourseId__59063A47]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__QuizzeId__59FA5E80] FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__QuizzeId__59FA5E80]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[StatusClass] ([StatusId])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__Status__5AEE82B9] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusClass] ([StatusId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__Status__5AEE82B9]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__TeacherId__5812160E] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__TeacherId__5812160E]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD  CONSTRAINT [FK__ListStude__Class__5DCAEF64] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[ListStudentClass] CHECK CONSTRAINT [FK__ListStude__Class__5DCAEF64]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD  CONSTRAINT [FK__ListStude__UserI__5EBF139D] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ListStudentClass] CHECK CONSTRAINT [FK__ListStude__UserI__5EBF139D]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK__LoginHist__UserI__412EB0B6] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK__LoginHist__UserI__412EB0B6]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Message__CreateB__75A278F5] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Message__CreateB__75A278F5]
GO
ALTER TABLE [dbo].[NotificationUser]  WITH CHECK ADD FOREIGN KEY([NotificationId])
REFERENCES [dbo].[Notification] ([NotificationId])
GO
ALTER TABLE [dbo].[NotificationUser]  WITH CHECK ADD FOREIGN KEY([NotificationId])
REFERENCES [dbo].[Notification] ([NotificationId])
GO
ALTER TABLE [dbo].[NotificationUser]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[NotificationUser]  WITH CHECK ADD  CONSTRAINT [FK__Notificat__UserI__45F365D3] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[NotificationUser] CHECK CONSTRAINT [FK__Notificat__UserI__45F365D3]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK__Post__CreateBy__49C3F6B7] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK__Post__CreateBy__49C3F6B7]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[Quizze]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Quizze]  WITH CHECK ADD  CONSTRAINT [FK__Quizze__CreateBy__5441852A] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Quizze] CHECK CONSTRAINT [FK__Quizze__CreateBy__5441852A]
GO
ALTER TABLE [dbo].[Quizze]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Quizze]  WITH CHECK ADD  CONSTRAINT [FK__Quizze__Modified__5535A963] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Quizze] CHECK CONSTRAINT [FK__Quizze__Modified__5535A963]
GO
ALTER TABLE [dbo].[QuizzeAnswer]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[QuizzeAnswer]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[QuizzeInClass]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[QuizzeInClass]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[QuizzeResult]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[QuizzeResult]  WITH CHECK ADD FOREIGN KEY([QuizzeId])
REFERENCES [dbo].[Quizze] ([QuizzeId])
GO
ALTER TABLE [dbo].[QuizzeResult]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[QuizzeResult]  WITH CHECK ADD  CONSTRAINT [FK__QuizzeRes__UserI__6C190EBB] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[QuizzeResult] CHECK CONSTRAINT [FK__QuizzeRes__UserI__6C190EBB]
GO
ALTER TABLE [dbo].[ReportUser]  WITH CHECK ADD FOREIGN KEY([FromUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ReportUser]  WITH CHECK ADD  CONSTRAINT [FK__ReportUse__FromU__3E52440B] FOREIGN KEY([FromUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ReportUser] CHECK CONSTRAINT [FK__ReportUse__FromU__3E52440B]
GO
ALTER TABLE [dbo].[RoomCallVideo]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[RoomCallVideo]  WITH CHECK ADD  CONSTRAINT [FK__RoomCallV__Class__628FA481] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[RoomCallVideo] CHECK CONSTRAINT [FK__RoomCallV__Class__628FA481]
GO
ALTER TABLE [dbo].[RoomCallVideo]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RoomCallVideo]  WITH CHECK ADD  CONSTRAINT [FK__RoomCallV__Teach__619B8048] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RoomCallVideo] CHECK CONSTRAINT [FK__RoomCallV__Teach__619B8048]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([FeedbackId])
REFERENCES [dbo].[Feedback] ([FeedbackId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__FeedbackId__3A81B327] FOREIGN KEY([FeedbackId])
REFERENCES [dbo].[Feedback] ([FeedbackId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__FeedbackId__3A81B327]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__RoleId__3B75D760] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__RoleId__3B75D760]
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__UserChatR__UserI__70DDC3D8] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserChatRoom] CHECK CONSTRAINT [FK__UserChatR__UserI__70DDC3D8]
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD  CONSTRAINT [FK__UserComme__UserI__4CA06362] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserCommentPost] CHECK CONSTRAINT [FK__UserComme__UserI__4CA06362]
GO
