using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
namespace Blog.Services.PostServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int id);
        Post CreatePost(Post post);
        void UpdatePost(Post post);
        void RemovePost(Post post);
        Post GetPostByIdentifier(string identifier);
    }
}
