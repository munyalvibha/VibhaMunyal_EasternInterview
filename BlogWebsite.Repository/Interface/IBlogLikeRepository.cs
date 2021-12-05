using BlogWebsite.Bal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Repository.Interface
{
    public interface IBlogLikeRepository
    {
        List<BlogLikeModel> GetBlogLikes(int blogid);
        Tuple<int, string> AddBlogLike(BlogLikeModel blogLikeModel);
    }
}
