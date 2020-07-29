using Blog.Data.PostRepository;
using Blog.Models;
using Bogus.DataSets;
using Ganss.XSS;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.PostServices
{
    public class DefaultPostService : IPostService
    {
        private readonly IPostRepository _repository;

        public DefaultPostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public Post CreatePost(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            post.Content = post.Content;
            post.PublishDate = DateTime.Now;
            return _repository.Create(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repository.GetAll();
        }

        public Post GetPostById(int id)
        {
            return _repository.GetById(id);
        }

        public Post GetPostByIdentifier(string identifier)
        {
            var splittedIdentifier = identifier?.Split('-') ?? throw new ArgumentNullException(nameof(identifier));
            var postId = Convert.ToInt32(splittedIdentifier[^1]);
            if(_repository.GetById(postId) is Post post && post.Identifier == identifier)
            {
                return post;
            }
            return null;
        }

        public void RemovePost(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _repository.Delete(post);
        }

        public void UpdatePost(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            var postRepo = GetPostById(post.Id);
            if (postRepo is null)
            {
                throw new InvalidOperationException("There isn't any matching post in the repository");
            }

            postRepo.PublishDate = DateTime.Now;
            (postRepo.Title, postRepo.Content) = (post.Title, post.Content);
            _repository.Update(post);
        }
    }
}
