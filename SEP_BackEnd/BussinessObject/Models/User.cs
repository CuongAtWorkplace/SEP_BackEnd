using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Classes = new HashSet<Class>();
            ListStudentClasses = new HashSet<ListStudentClass>();
            LoginHistories = new HashSet<LoginHistory>();
            Messages = new HashSet<Message>();
            NotificationUsers = new HashSet<NotificationUser>();
            Posts = new HashSet<Post>();
            QuizzeCreateByNavigations = new HashSet<Quizze>();
            QuizzeModifiedByNavigations = new HashSet<Quizze>();
            QuizzeResults = new HashSet<QuizzeResult>();
            ReportUsers = new HashSet<ReportUser>();
            RoomCallVideos = new HashSet<RoomCallVideo>();
            UserChatRooms = new HashSet<UserChatRoom>();
            UserCommentPosts = new HashSet<UserCommentPost>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int? FeedbackId { get; set; }
        public int? RoleId { get; set; }
        public string? Token { get; set; }
        public bool? IsBan { get; set; }

        public virtual Feedback? Feedback { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<ListStudentClass> ListStudentClasses { get; set; }
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<NotificationUser> NotificationUsers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Quizze> QuizzeCreateByNavigations { get; set; }
        public virtual ICollection<Quizze> QuizzeModifiedByNavigations { get; set; }
        public virtual ICollection<QuizzeResult> QuizzeResults { get; set; }
        public virtual ICollection<ReportUser> ReportUsers { get; set; }
        public virtual ICollection<RoomCallVideo> RoomCallVideos { get; set; }
        public virtual ICollection<UserChatRoom> UserChatRooms { get; set; }
        public virtual ICollection<UserCommentPost> UserCommentPosts { get; set; }
    }
}
