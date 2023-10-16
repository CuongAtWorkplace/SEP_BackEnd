using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IReporitory
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostList();
        IEnumerable<Post> GetPostListActive();
        IEnumerable<Post> getPostByName(string namePost);
        Post getPostById(int PostId);
        void AddNewPost(Post post);
        void Update(Post post);
        void UpdatePostActive(Post post);
        void HideComment(UserCommentPost commentPost);
    }
}
