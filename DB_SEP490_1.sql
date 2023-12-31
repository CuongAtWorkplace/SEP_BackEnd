USE [DB_SEP490_1]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[ChatRoomId] [int] IDENTITY(1,1) NOT NULL,
	[ChatRoomName] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[isManagerChat] [bit] NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK__ChatRoom__69733CF785260202] PRIMARY KEY CLUSTERED 
(
	[ChatRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](225) NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[NumberStudent] [int] NULL,
	[Topic] [nvarchar](50) NULL,
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
 CONSTRAINT [PK__Class__CB1927C0EE3FA180] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[Image] [nvarchar](225) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__Course__C92D71A761874198] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[ListStudentClass]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[Message]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[NoteTeacher]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteTeacher](
	[NoteId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ClassId] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[NoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentHistory]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromUser] [int] NULL,
	[ToUser] [int] NULL,
	[TotalMoney] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Type] [bit] NULL,
 CONSTRAINT [PK__PaymentH__3214EC07F0F27231] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[CreateBy] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[ContentPost] [nvarchar](225) NULL,
	[LikeAmout] [int] NULL,
	[Image] [nvarchar](225) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Post__AA1260187E3F81B0] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportUser]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[RequestClass]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestClass](
	[RequestClassId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ClassId] [int] NULL,
	[Type] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestManager]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestManager](
	[RequestManagerId] [int] NOT NULL,
	[FromUserId] [int] NULL,
	[RoomChatId] [int] NULL,
	[IsChecked] [bit] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_RequestManager] PRIMARY KEY CLUSTERED 
(
	[RequestManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[StatusClass]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[UploadedFiles]    Script Date: 12/19/2023 3:06:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadedFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](255) NULL,
	[FilePath] [nvarchar](255) NULL,
	[ClassId] [int] NULL,
 CONSTRAINT [PK__Uploaded__3214EC07181DD5BA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[UserChatRoom]    Script Date: 12/19/2023 3:06:46 PM ******/
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
/****** Object:  Table [dbo].[UserCommentPost]    Script Date: 12/19/2023 3:06:46 PM ******/
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
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__CourseId__59063A47] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__CourseId__59063A47]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__CourseId__5EBF139D] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__CourseId__5EBF139D]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__Status__5AEE82B9] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusClass] ([StatusId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__Status__5AEE82B9]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__Status__628FA481] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusClass] ([StatusId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__Status__628FA481]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK__Class__TeacherId__6477ECF3] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK__Class__TeacherId__6477ECF3]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD  CONSTRAINT [FK__ListStude__Class__5DCAEF64] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[ListStudentClass] CHECK CONSTRAINT [FK__ListStude__Class__5DCAEF64]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD  CONSTRAINT [FK__ListStude__Class__66603565] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[ListStudentClass] CHECK CONSTRAINT [FK__ListStude__Class__66603565]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD  CONSTRAINT [FK__ListStude__UserI__5EBF139D] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ListStudentClass] CHECK CONSTRAINT [FK__ListStude__UserI__5EBF139D]
GO
ALTER TABLE [dbo].[ListStudentClass]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Message__ChatRoo__6D0D32F4] FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Message__ChatRoo__6D0D32F4]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Message__CreateB__75A278F5] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Message__CreateB__75A278F5]
GO
ALTER TABLE [dbo].[NoteTeacher]  WITH CHECK ADD  CONSTRAINT [FK__NoteTeach__Class__17036CC0] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[NoteTeacher] CHECK CONSTRAINT [FK__NoteTeach__Class__17036CC0]
GO
ALTER TABLE [dbo].[NoteTeacher]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK__PaymentHi__FromU__66603565] FOREIGN KEY([FromUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PaymentHistory] CHECK CONSTRAINT [FK__PaymentHi__FromU__66603565]
GO
ALTER TABLE [dbo].[PaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK__PaymentHi__ToUse__6754599E] FOREIGN KEY([ToUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PaymentHistory] CHECK CONSTRAINT [FK__PaymentHi__ToUse__6754599E]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK__Post__CreateBy__49C3F6B7] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK__Post__CreateBy__49C3F6B7]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK__Post__CreateBy__73BA3083] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK__Post__CreateBy__73BA3083]
GO
ALTER TABLE [dbo].[ReportUser]  WITH CHECK ADD  CONSTRAINT [FK__ReportUse__FromU__3E52440B] FOREIGN KEY([FromUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ReportUser] CHECK CONSTRAINT [FK__ReportUse__FromU__3E52440B]
GO
ALTER TABLE [dbo].[RequestClass]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[RequestClass]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RequestManager]  WITH CHECK ADD  CONSTRAINT [FK_RequestManager_User] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RequestManager] CHECK CONSTRAINT [FK_RequestManager_User]
GO
ALTER TABLE [dbo].[UploadedFiles]  WITH CHECK ADD  CONSTRAINT [FK__UploadedF__Class__29221CFB] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[UploadedFiles] CHECK CONSTRAINT [FK__UploadedF__Class__29221CFB]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__FeedbackId__3A81B327] FOREIGN KEY([FeedbackId])
REFERENCES [dbo].[Feedback] ([FeedbackId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__FeedbackId__3A81B327]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__UserChatR__ChatR__0E6E26BF] FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[UserChatRoom] CHECK CONSTRAINT [FK__UserChatR__ChatR__0E6E26BF]
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__UserChatR__ChatR__0F624AF8] FOREIGN KEY([ChatRoomId])
REFERENCES [dbo].[ChatRoom] ([ChatRoomId])
GO
ALTER TABLE [dbo].[UserChatRoom] CHECK CONSTRAINT [FK__UserChatR__ChatR__0F624AF8]
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__UserChatR__UserI__70DDC3D8] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserChatRoom] CHECK CONSTRAINT [FK__UserChatR__UserI__70DDC3D8]
GO
ALTER TABLE [dbo].[UserChatRoom]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD  CONSTRAINT [FK__UserComme__PostI__10566F31] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[UserCommentPost] CHECK CONSTRAINT [FK__UserComme__PostI__10566F31]
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD  CONSTRAINT [FK__UserComme__PostI__114A936A] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[UserCommentPost] CHECK CONSTRAINT [FK__UserComme__PostI__114A936A]
GO
ALTER TABLE [dbo].[UserCommentPost]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
