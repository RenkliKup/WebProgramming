using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
namespace WebApp
{
    public class TestMiddleware
    {
        private RequestDelegate nextDelegate;
        public TestMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context,DataContext dataContext)
        {
            if(context.Request.Path=="/test")
            {
                await context.Response.WriteAsync(
                    $"There are {dataContext.Posts.Count()} products\n"
                    );
                await context.Response.WriteAsync(
                    $"There are {dataContext.Categorie1.Count()} products\n"
                    );
                await context.Response.WriteAsync(
                    $"There are {dataContext.Users.Count()} products\n"
                    );
            }
            else
            {
                await nextDelegate(context);
            }
        }

    }
}
