using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        public void AddNewPost(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> getCourseByName(string namePost)
        {
            throw new NotImplementedException();
        }

        public Post getPostById(int PostId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostListActive()
        {
            throw new NotImplementedException();
        }

        public void HideComment(UserCommentPost commentPost)
        {
            throw new NotImplementedException();
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }

        public void UpdatePostActive(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
