using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Bal
{
    public class BlogLikeModel
    {
        public int BlogLikeId { get; set; }
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public System.DateTime LikedOn { get; set; }

        public string Blogname { get; set; }
        public string Username { get; set; }
    }
}
