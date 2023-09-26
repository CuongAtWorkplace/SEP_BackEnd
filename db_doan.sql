create database DB_SEP490


create table [Role](
	RoleId int primary key identity(1,1),
	RoleName nvarchar(50) not null
)
create table Feedback(
	FeedbackId int primary key identity(1,1),
	FromUserId int ,
	Rating int ,
	[Description] nvarchar(225),
	CreateDate datetime,
	ModifileDate datetime,
	IsDelete bit
	)
create table [User](
	[UserId] int NOT NULL  primary key identity(1,1),
	FullName nvarchar(225), 
	Email nvarchar(225), 
	[Password] nvarchar(225), 
	Phone nvarchar(12), 
	[Image] nvarchar(max),
	[Description] nvarchar(max),
	[Address] nvarchar(225), 
	[FeedbackId] int foreign key references [Feedback](FeedbackId),
	[RoleId] int foreign key references[Role](RoleId),
	[Token] nvarchar(225),
	IsBan bit 
)

create table ReportUser(
	ReportUserId int primary key identity(1,1),
	FromUser int foreign key references [User](UserId),
	ToUser int NOT NULL,
	[Description] nvarchar(255),
	Reason nvarchar(255),
	CreateDate datetime,
	[Status] nvarchar(200),
	Modified datetime,
	EvidenceImage nvarchar(255),
	IsChecked bit
)

create table LoginHistory(
	LoginHistory int primary key identity(1,1),
	UserId int foreign key references [User](UserId),
	TimeLog datetime 
)

create table [Notification](
	NotificationId int primary key identity(1,1),
	Title nvarchar(225),
	[Description] nvarchar(225),
	CreateDate datetime,
	ModifiedDate datetime,
	IsDelete bit
)

Create table NotificationUser(
	NotificationUserId int primary key identity(1,1),
	UserId int foreign key references [User](UserId),
	NotificationId int foreign key references [Notification](NotificationId),
	ModifiedDate datetime,
	Content nvarchar(225),
	IsReaded bit,
	IsDelete bit
)

Create table Post(
	PostId int primary key identity(1,1),
	CreateBy int foreign key references [User](UserId),
	Title nvarchar(100),
	[Description] nvarchar(225),
	[ContentPost] nvarchar(225),
	LikeAmout int ,
	Image nvarchar(225),
	CreateDate datetime,
	IsActive bit
)

create table UserCommentPost(
		UserCommentPostId int primary key identity(1,1),
		UserId int foreign key references [User](UserId),
		PostId int foreign key references [Post](PostId),
		Content nvarchar(225),
		CreateDate datetime,
		LikeAmount int ,
		IsActive bit
)

Create table Course(
	CourseId int primary key identity(1,1),
	CourseName nvarchar(50),
	[Description] nvarchar(225),
	CreateDate datetime,
	Image nvarchar(225),
	IsDelete bit
)

create table StatusClass(
	StatusId int primary key identity(1,1),
	StatusName nvarchar(50)
)
create table Quizze(
	QuizzeId int primary key identity(1,1),
	Title nvarchar(100),
	[Description] nvarchar(225),
	CreateBy int foreign key references [User](UserId),
	WorkingTime nvarchar(50),
	CreateDate datetime ,
	ModifiedBy int foreign key references [User](UserId),
	NumberOfQuestion int ,
	QuizzeCategory nvarchar(100),
	IsDraft bit,
	IsDelete bit
)
Create table Class(
	ClassId int primary key identity(1,1),
	TeacherId int foreign key references [User](UserId),
	CourseId int foreign key references [Course](CourseId),
	NumberStudent int ,
	Topic nvarchar(50),
	QuizzeId int foreign key references [Quizze](QuizzeId),
	Schedule nvarchar(255),
	Fee nvarchar(50),
	NumberOfWeek nvarchar(50),
	NumberPhone nvarchar(10),
	[Description] nvarchar(225),
	CreateDate datetime ,
	StartDate datetime,
	EndDate datetime,
	[Status] int foreign key references [StatusClass](StatusId),
	IsDelete bit,
	TokenClass nvarchar(225)
)

create table ListStudentClass(
	ListStudentInClassId int primary key identity(1,1),
	ClassId int foreign key references [Class](ClassId),
	UserId int foreign key references [User](UserId),
	CreateDate datetime
)

Create table RoomCallVideo(
	RoomId int primary key identity(1,1),
	RoomName nvarchar(100),
	TeacherId int foreign key references [User](UserId),
	ClassId int foreign key references [Class](ClassId)
	)



create table Question(
	QuestionId int primary key identity(1,1),
	QuizzeId int foreign key references [Quizze](QuizzeId),
	Question nvarchar(225),
	Answer nvarchar(100),
	IsMultiQuestion bit,
	CreateDate datetime ,
	ModifiedDate datetime,
	IsDelete bit
	
)

create table QuizzeAnswer(
	QuizzeAnswerId int primary key identity(1,1),
	QuestionId int foreign key references [Question](QuestionId),
	Answer nvarchar(100),
	IsCorrect nvarchar(100),
	CreateDate datetime,
	ModifiedDate datetime
)

create table QuizzeResult(
	QuizzeResultId int primary key identity(1,1),
	QuizzeId int foreign key references [Quizze](QuizzeId),
	UserId int foreign key references [User](UserId),
	Score int ,
	CreateDate datetime,
	NumberOfTrue int , 
	NumberOfFalse int
)

Create table ChatRoom(
	ChatRoomId int primary key identity(1,1),
	ChatRoomName nvarchar(100),
	[Description] nvarchar(100)
)

Create table UserChatRoom(
	UserChatRoomId int primary key identity(1,1),
	UserId int foreign key references [User](UserId),
	ChatRoomId int foreign key references [ChatRoom](ChatRoomId)
)

Create table [Message](
	MessageId int primary key identity(1,1),
	ChatRoomId int foreign key references [ChatRoom](ChatRoomId),
	CreateBy int foreign key references [User](UserId),
	Content nvarchar(225),
	CreateDate datetime
)