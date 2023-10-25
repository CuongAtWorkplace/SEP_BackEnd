using BussinessObject.Models;
using DataAccess.DTO;
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
        void UpdateLikePost(Post post);
        void UpdateUnLikePost(Post post);
        void AddComment(UserCommentPost commentPost);
        IEnumerable<CommentDTO> ListCommentPost(int postId);
        void HideComment(UserCommentPost commentPost);
    }
}
