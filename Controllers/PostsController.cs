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
    [ApiController]
    [Route("api/posts")]
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
        /* [HttpGet("{id}")]
        public Post GetPost([FromServices] ILogger<PostsController> logger) {
            logger.LogDebug("GetProduct Action Invoked");
            return context.Posts.FirstOrDefault();

        }*/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(long id)
        {
            
            Post p= await context.Posts.FindAsync(id);
            if(p==null)
            {
                return NotFound();
            }
            return Ok(new { PostId=p.PostId,
                Content=p.content,
                UserId=p.UserId,
                CategoryId=p.CategoryId});

        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(PostBindingTarget target)
        {
           
                Post p = target.ToPost();
                await context.Posts.AddAsync(p);
                await context.SaveChangesAsync();
                return Ok(p);
            
            
            
        }
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetPost),new { Id=1});
        }
        [HttpPut]
        public async Task UpdateProduct(Post post)
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
