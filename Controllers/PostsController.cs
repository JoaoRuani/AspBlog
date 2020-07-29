using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.PostRepository;
using Blog.Models;
using Blog.Services.PostServices;
using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        // GET: Posts
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index()
        {
            var posts = _postService.GetAllPosts();
            return View(posts);
        }

        // GET: Posts/post-title-23
        [HttpGet("[controller]/{identifier}", Name = "PostDetails")]
        public ActionResult Details(string identifier)
        {
            if(identifier is null)
            {
                return NotFound();
            }
            var post = _postService.GetPostByIdentifier(identifier);
            if(post is null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create() => View();

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "Title", "Content")] Post post)
        {
            if(ModelState.IsValid)
            {
                _postService.CreatePost(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _postService.GetPostById(id);
            if(post is null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id", "Title", "Content")]Post postFromForm)
        {
            if (!ModelState.IsValid)
            {
                return View(postFromForm);
            }
            try
            {
                _postService.UpdatePost(postFromForm);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {

                return NotFound();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: PostsDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post postFromView)
        {
            var postFromRepo = _postService.GetPostById(id);
            if (postFromRepo == null)
            {
                return NotFound();
            }
            _postService.RemovePost(postFromRepo);
            return RedirectToAction(nameof(Index));
        }
    }
}
