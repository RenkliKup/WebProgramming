using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
