using Blog.Data.PostRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog.Seeders
{
    public static class DatabaseSeeder
    {
        public static void UseSeeder(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            var postRepository = serviceProvider.GetService<IPostRepository>();
            new PostSeed(postRepository);
        }
    }
}
