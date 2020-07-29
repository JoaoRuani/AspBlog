using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.PostServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsApiController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            if(posts.Count() == 0)
            {
                return NoContent();
            }
            return Ok(posts);
        }
        [HttpGet("{id}", Name = nameof(GetPost))]
        public ActionResult<Post> GetPost(int id)
        {
            var post = _postService.GetPostById(id);
            if(post is null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        public ActionResult<Post> CreatePost(Post post)
        {
            if(!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var createdPost = _postService.CreatePost(post);
            return CreatedAtRoute(nameof(GetPost), new { Id = createdPost.Id }, createdPost);
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePost(int id, Post post)
        {
            if(_postService.GetPostById(id) is null)
            {
                return NotFound();
            }
            post.Id = id;
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            _postService.UpdatePost(post);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            var post = _postService.GetPostById(id);
            if (post is null)
            {
                return NotFound();
            }
            _postService.RemovePost(post);
            return NoContent();
        }
    }
}
