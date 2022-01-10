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
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Post> posts { get; set; }


    }
}
