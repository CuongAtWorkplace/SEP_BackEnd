using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PostManagement
    {
        private static PostManagement instance = null;
        private static readonly object instanceLock = new object();
        private PostManagement() { }
        public static PostManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PostManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Post> GetPostList()
        {
            List<Post> list = new List<Post>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.Posts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public IEnumerable<Post> GetPostListActive()
        {
            List<Post> list = new List<Post>();
            try
            {
                var db = new DB_SEP490Context();
                list = db.Posts.Where(x => x.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public IEnumerable<Post> getPostByName(string namePost)
        {
            List<Post> listPostByName = new List<Post>();
            try
            {
                var db = new DB_SEP490Context();
                listPostByName = db.Posts.Where(x => x.Equals(namePost)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listPostByName;
        }

        //public IEnumerable<Class> getClassInCourse(int courseId)
        //{
        //    List<Class> listClassInCourse = new List<Class>();
        //    try
        //    {
        //        var db = new DB_SEP490Context();
        //        listClassInCourse = db.Classes.Where(x => x.CourseId == courseId).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return listClassInCourse;
        //}

        public Post getPostById(int PostId)
        {
            Post? news = null;
            try
            {
                var db = new DB_SEP490Context();
                news = db.Posts.SingleOrDefault(x => x.PostId == PostId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

        public void AddNewPost(Post post)
        {
            try
            {
               
                
                    var db = new DB_SEP490Context();
                    Post PostAdd = new Post
                    {
                        ContentPost = post.ContentPost,
                        CreateBy = post.CreateBy,
                        CreateByNavigation = null,
                        Description = post.Description,
                        CreateDate = DateTime.Now,
                        Image = post.Image,
                        LikeAmout = 0,
                        Title = post.Title,
                        UserCommentPosts = null,
                        IsActive = false,
                    };
                    db.Posts.Add(PostAdd);
                    db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Post post)
        {
            try
            {
                Post PostUpdate = getPostById(post.PostId);
                if (PostUpdate != null)
                {
                    var db = new DB_SEP490Context();
                    db.Entry<Post>(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePostActive(Post post)
        {
            try
            {
                Post PostUpdate = getPostById(post.PostId);
                if (PostUpdate != null)
                {
                    var db = new DB_SEP490Context();
                    Post PostAdd = new Post
                    {
                        PostId = post.PostId,
                        ContentPost = post.ContentPost,
                        CreateBy = PostUpdate.CreateBy,
                        CreateByNavigation = post.CreateByNavigation,
                        Description = post.Description,
                        CreateDate = PostUpdate.CreateDate,
                        Image = post.Image,
                        LikeAmout = 0,
                        Title = post.Title,
                        UserCommentPosts = null,
                        IsActive = true,
                    };
                    db.Entry<Post>(PostAdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void HideComment(UserCommentPost commentPost)
        {
            try
            {
                    var db = new DB_SEP490Context();
                UserCommentPost u = new UserCommentPost
                {

                };
                    db.Entry<UserCommentPost>(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
