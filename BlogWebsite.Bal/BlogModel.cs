using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Bal
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        [DisplayName("Blog Title")]
        public string BlogTitle { get; set; }

        [DisplayName("Blog Description")]
        public string BlogDescription { get; set; }
        
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public string Categoryname { get; set; }

        public int likeCount { get; set; }
    }
}
