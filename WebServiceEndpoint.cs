﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using WebApp.Models;
using WebApp;

namespace Microsoft.AspNetCore.Builder
{
    public static class WebServiceEndpoint
    {
        private static string BASEURL = "api/posts";
        public static void MapWebService(this IEndpointRouteBuilder app)
        {
            app.MapGet($"{BASEURL}/{{id}}", async context => {
                long key = long.Parse(context.Request.RouteValues["id"] as string);
                DataContext data = context.RequestServices.GetService<DataContext>();
                Post p = data.Posts.Find(key);
                if(p==null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    await context.Response
                    .WriteAsync(JsonSerializer.Serialize<Post>(p));
                }
            });
            app.MapGet(BASEURL, async context => {
                
                DataContext data = context.RequestServices.GetService<DataContext>();
                
                
                
                    context.Response.ContentType = "application/json";
                    await context.Response
                    .WriteAsync(JsonSerializer.Serialize<IEnumerable<Post>>(data.Posts));
                
            });
            app.MapPost(BASEURL, async context => {

                DataContext data = context.RequestServices.GetService<DataContext>();
                Post p = await JsonSerializer.DeserializeAsync<Post>(context.Request.Body
                    );
                await data.AddAsync(p);
                await data.SaveChangesAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;

            });

        }
    }
}