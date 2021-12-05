using BlogWebsite.Bal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Repository.Interface
{
    public interface IBlogRepository
    {
        Tuple<int, string> AddBlog(BlogModel blogModel);
        List<BlogModel> GetBlog(string userid);
        BlogModel GetBlogById(int id);
        string UpdateBlog(BlogModel blogModel);
        string ToogleDeletedBlogState(int id);
    }
}
