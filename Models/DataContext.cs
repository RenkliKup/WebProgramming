using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DataContext:DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categorie1 { get; set; }
        public DbSet<User> Users { get; set; }
        
        


    }
}
