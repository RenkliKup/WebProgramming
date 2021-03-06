using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class Post
    {
        [Key]
        public long PostId { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string content { get; set; }
        public string short_content { get; set; }
        public string thumbnail { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public string updated_date { get; set; }
        public string show_in_slider { get; set; }
        public string slider_thumbnail { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

    }
}
