using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.PostRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetByTitle(string title);
    }
}
