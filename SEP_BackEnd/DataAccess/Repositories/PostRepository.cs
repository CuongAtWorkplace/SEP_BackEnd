using BussinessObject.Models;
using DataAccess.DTO;
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
        public void AddNewPost(Post post) => PostManagement.Instance.AddNewPost(post);

        public IEnumerable<Post> getPostByName(string namePost) => PostManagement.Instance.getPostByName(namePost);

        public Post getPostById(int PostId) => PostManagement.Instance.getPostById(PostId);

        public IEnumerable<Post> GetPostList() => PostManagement.Instance.GetPostList();

        public IEnumerable<Post> GetPostListActive() => PostManagement.Instance.GetPostListActive();

        public void HideComment(UserCommentPost commentPost) => PostManagement.Instance.HideComment(commentPost);

        public void UnHideComment(UserCommentPost commentPost) => PostManagement.Instance.UnHideComment(commentPost);

        public void Update(Post post)=> PostManagement.Instance.Update(post);

        public void UpdatePostActive(Post post) => PostManagement.Instance.UpdatePostActive(post);

        public void UpdateLikePost(Post post) => PostManagement.Instance.UpdateLikePost(post);

        public void UpdateUnLikePost(Post post) => PostManagement.Instance.UpdateUnLikePost(post);

        public void AddComment(UserCommentPost commentPost) => PostManagement.Instance.AddComment(commentPost);

        public IEnumerable<CommentDTO> ListCommentPost(int postId) => PostManagement.Instance.ListCommentPost(postId);

        public void UpdatePostHide(Post post) => PostManagement.Instance.UpdatePostHide(post);
    }
}
