using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BussinessObject.Models
{
    public partial class DB_SEP490Context : DbContext
    {
        public DB_SEP490Context()
        {
        }

        public DB_SEP490Context(DbContextOptions<DB_SEP490Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatRoom> ChatRooms { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<ListStudentClass> ListStudentClasses { get; set; } = null!;
        public virtual DbSet<LoginHistory> LoginHistories { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<NotificationUser> NotificationUsers { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quizze> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizzeAnswer> QuizzeAnswers { get; set; } = null!;
        public virtual DbSet<QuizzeInClass> QuizzeInClasses { get; set; } = null!;
        public virtual DbSet<QuizzeResult> QuizzeResults { get; set; } = null!;
        public virtual DbSet<ReportUser> ReportUsers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoomCallVideo> RoomCallVideos { get; set; } = null!;
        public virtual DbSet<StatusClass> StatusClasses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserChatRoom> UserChatRooms { get; set; } = null!;
        public virtual DbSet<UserCommentPost> UserCommentPosts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database=DB_SEP490;uid=sa;pwd=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.ToTable("ChatRoom");

                entity.Property(e => e.ChatRoomName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Classname).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Fee).HasMaxLength(50);

                entity.Property(e => e.NumberOfWeek).HasMaxLength(50);

                entity.Property(e => e.NumberPhone).HasMaxLength(10);

                entity.Property(e => e.Schedule).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TokenClass).HasMaxLength(225);

                entity.Property(e => e.Topic).HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Class__CourseId__59063A47");

                entity.HasOne(d => d.Quizze)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.QuizzeId)
                    .HasConstraintName("FK__Class__QuizzeId__59FA5E80");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Class__Status__5AEE82B9");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Class__TeacherId__5812160E");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.Image).HasMaxLength(225);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.ModifileDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ListStudentClass>(entity =>
            {
                entity.HasKey(e => e.ListStudentInClassId)
                    .HasName("PK__ListStud__24915C875C7B1397");

                entity.ToTable("ListStudentClass");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ListStudentClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__ListStude__Class__5DCAEF64");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ListStudentClasses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ListStude__UserI__5EBF139D");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.HasKey(e => e.LoginHistory1)
                    .HasName("PK__LoginHis__31A7DF80B57539EC");

                entity.ToTable("LoginHistory");

                entity.Property(e => e.LoginHistory1).HasColumnName("LoginHistory");

                entity.Property(e => e.TimeLog).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LoginHist__UserI__412EB0B6");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatRoomId)
                    .HasConstraintName("FK__Message__ChatRoo__74AE54BC");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK__Message__CreateB__75A278F5");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(225);
            });

            modelBuilder.Entity<NotificationUser>(entity =>
            {
                entity.ToTable("NotificationUser");

                entity.Property(e => e.Content).HasMaxLength(225);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.NotificationUsers)
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("FK__Notificat__Notif__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotificationUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__45F365D3");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.ContentPost).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.Image).HasMaxLength(225);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK__Post__CreateBy__49C3F6B7");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Answer).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Question1)
                    .HasMaxLength(225)
                    .HasColumnName("Question");

                entity.HasOne(d => d.Quizze)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizzeId)
                    .HasConstraintName("FK__Question__Quizze__656C112C");
            });

            modelBuilder.Entity<Quizze>(entity =>
            {
                entity.ToTable("Quizze");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.QuizzeCategory).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.WorkingTime).HasMaxLength(50);

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.QuizzeCreateByNavigations)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK__Quizze__CreateBy__5441852A");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.QuizzeModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK__Quizze__Modified__5535A963");
            });

            modelBuilder.Entity<QuizzeAnswer>(entity =>
            {
                entity.ToTable("QuizzeAnswer");

                entity.Property(e => e.Answer).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsCorrect).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizzeAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuizzeAns__Quest__68487DD7");
            });

            modelBuilder.Entity<QuizzeInClass>(entity =>
            {
                entity.HasKey(e => e.QuizzeInClass1)
                    .HasName("PK__QuizzeIn__C0E4B2E7E10671BA");

                entity.ToTable("QuizzeInClass");

                entity.Property(e => e.QuizzeInClass1).HasColumnName("QuizzeInClass");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.QuizzeInClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__QuizzeInC__Class__40F9A68C");

                entity.HasOne(d => d.Quizze)
                    .WithMany(p => p.QuizzeInClasses)
                    .HasForeignKey(d => d.QuizzeId)
                    .HasConstraintName("FK__QuizzeInC__Quizz__41EDCAC5");
            });

            modelBuilder.Entity<QuizzeResult>(entity =>
            {
                entity.ToTable("QuizzeResult");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Quizze)
                    .WithMany(p => p.QuizzeResults)
                    .HasForeignKey(d => d.QuizzeId)
                    .HasConstraintName("FK__QuizzeRes__Quizz__6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuizzeResults)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__QuizzeRes__UserI__6C190EBB");
            });

            modelBuilder.Entity<ReportUser>(entity =>
            {
                entity.ToTable("ReportUser");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EvidenceImage).HasMaxLength(255);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Reason).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.ReportUsers)
                    .HasForeignKey(d => d.FromUser)
                    .HasConstraintName("FK__ReportUse__FromU__3E52440B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<RoomCallVideo>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__RoomCall__32863939A5C8EF8B");

                entity.ToTable("RoomCallVideo");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.RoomCallVideos)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__RoomCallV__Class__628FA481");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.RoomCallVideos)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__RoomCallV__Teach__619B8048");
            });

            modelBuilder.Entity<StatusClass>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__StatusCl__C8EE2063CDF9F791");

                entity.ToTable("StatusClass");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.FullName).HasMaxLength(225);

                entity.Property(e => e.Password).HasMaxLength(225);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.Token).HasMaxLength(225);

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK__User__FeedbackId__3A81B327");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__3B75D760");
            });

            modelBuilder.Entity<UserChatRoom>(entity =>
            {
                entity.ToTable("UserChatRoom");

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.UserChatRooms)
                    .HasForeignKey(d => d.ChatRoomId)
                    .HasConstraintName("FK__UserChatR__ChatR__71D1E811");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserChatRooms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserChatR__UserI__70DDC3D8");
            });

            modelBuilder.Entity<UserCommentPost>(entity =>
            {
                entity.ToTable("UserCommentPost");

                entity.Property(e => e.Content).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserCommentPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__UserComme__PostI__4D94879B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCommentPosts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserComme__UserI__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
