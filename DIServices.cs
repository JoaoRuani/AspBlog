using Blog.Data.EntityFramework;
using Blog.Data.PostRepository;
using Blog.Services.PostServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog
{
    public static class DIServices
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, EF_PostRepository>();
            services.AddTransient<IPostService, DefaultPostService>();
            return services;
        }
    }
}
