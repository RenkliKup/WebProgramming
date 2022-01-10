using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string kullaniciAdi { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string avatar { get; set; }
        public bool is_admin { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
