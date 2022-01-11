using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private DataContext context;
        public PostsController(DataContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IAsyncEnumerable<Post> GetPosts()
        {
            return context.Posts;
        }
        [HttpGet("{id}")]
        public Post GetPost([FromServices] ILogger<PostsController> logger) {
            logger.LogDebug("GetProduct Action Invoked");
            return context.Posts.FirstOrDefault();

        }
        [HttpGet("{id}")]
        public async Task<Post> GetPost(long id, [FromServices] ILogger<PostsController> logger)
        {
            logger.LogDebug("GetProduct Action Invoked");
            return await context.Posts.FindAsync(id);

        }
        [HttpPost]
        public async Task SaveProduct([FromBody] Post post)
        {
            context.Posts.AddAsync(post);
            context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateProduct([FromBody] Post post)
        {
            context.Posts.Update(post);
            context.SaveChangesAsync();
        }
        [HttpDelete("{id}")]
        public async Task DeleteProduct(long id)
        {
            context.Posts.Remove(new Post { PostId=id});
            context.SaveChanges();
        }
    }
}
