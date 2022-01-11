using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class PostBindingTarget
    {
        [Required]
        public string title { get; set; }
        public string slug { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public string short_content { get; set; }
        public string thumbnail { get; set; }
        public DateTime created_date { get; set; }
        public string updated_date { get; set; }
        public string show_in_slider { get; set; }
        public string slider_thumbnail { get; set; }
        [Range(1,long.MaxValue)]
        public long CategoryId { get; set; }
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }
        public Post ToPost() => new Post()
        {
            title = this.title,
            slug = this.slug,
            content = this.content,
            short_content = this.short_content,
            thumbnail = this.thumbnail,
            show_in_slider = this.show_in_slider,
            slider_thumbnail = this.slider_thumbnail,
            CategoryId = this.CategoryId,
            UserId = this.UserId,
            created_date = this.created_date,
            updated_date = this.updated_date
        };
        
    }
}
