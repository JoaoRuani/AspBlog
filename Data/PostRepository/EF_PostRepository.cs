using Blog.Data.EntityFramework;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.PostRepository
{
    public class EF_PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;

        public EF_PostRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Post Create(Post obj)
        {
            if(obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            var post = _context.Posts.Add(obj).Entity;
            _context.SaveChanges();
            return post;
        }

        public Post Delete(Post obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            var post = _context.Posts.Remove(obj).Entity;
            _context.SaveChanges();
            return post;

        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        public Post GetByTitle(string title)
        {
            return _context.Posts.FirstOrDefault(p => p.Title == title);
        }

        public void Update(Post obj)
        {
            //_context.Posts.Update(obj);
            _context.SaveChanges();
        }
      
    }
}
