using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class User
    {
        public int id { get; set; }
        public string kullaniciAdi { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string avatar { get; set; }
        public bool is_admin { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
