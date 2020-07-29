using Blog.Data.PostRepository;
using Blog.Models;
using Bogus;

namespace Blog.Seeders
{
    public class PostSeed : Seeder<Post>
    {
        public PostSeed(IPostRepository rep) : base(rep)
        {

        }
        protected override void Init()
        {
            var postFaker = new Faker<Post>("pt_BR")
                .RuleFor(p => p.Title, f => f.Random.Words())
                .RuleFor(p => p.Content, f => f.Lorem.Text())
                .RuleFor(p => p.PublishDate, f => f.Date.Past());

            var generatedPosts = postFaker.Generate(10);

            foreach (var post in generatedPosts)
            {
                _repository.Create(post);
            }
        }
    }
}
