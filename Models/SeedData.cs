using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public static class SeedData
    {
            public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if(context.Posts.Count()==0 && context.Users.Count()==0 && context.Categorie1.Count()==0)
            {
                User baris =new User() 
                { kullaniciAdi="bariskrklk",
                    avatar="",
                email="baris.1907.krklk@gmail.com",
                pwd="1234",
                is_admin=true
                };
                Category telefon = new Category() {
                slug="telefon",
                title="telefon"};
                
                Post post = new Post() { Category = telefon,
                    content = "selam",
                    title = "telefon", User = baris,
                    short_content = "tel",
                    show_in_slider = "asdsa",
                    slider_thumbnail = "sds",
                    slug="selam",
                    thumbnail="sd",
                    updated_date=null
                };
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
