using BlogWebsite.Bal;
using BlogWebsite.Dal;
using BlogWebsite.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Repository
{
    public class BlogLikeRepository: IBlogLikeRepository
    {
        readonly BlogDBEntities _entities = new BlogDBEntities();
        public List<BlogLikeModel> GetBlogLikes(int blogid)
        {
            var blogLike = from blogs in _entities.BlogLikes
                       where blogs.BlogId==blogid
                       select new BlogLikeModel
                       {
                           UserId = blogs.AspNetUser.UserName,
                           BlogId = blogs.BlogId,
                           Blogname=blogs.Blog.BlogTitle,
                           Username=blogs.AspNetUser.UserName,
                           LikedOn=blogs.LikedOn
                       };
            return blogLike.ToList();
        }

        public Tuple<int, string> AddBlogLike(BlogLikeModel blogLikeModel)
        {
            try
            {
                var blog = new BlogLike
                {
                    UserId = blogLikeModel.UserId,
                    BlogId=blogLikeModel.BlogId,
                    LikedOn=DateTime.UtcNow
                };

                _entities.BlogLikes.Add(blog);
                return new Tuple<int, string>(_entities.SaveChanges(), "Blog inserted");
            }
            catch (Exception)
            {
                return new Tuple<int, string>(-1, "Something went wrong!");
            }
        }
    }
}
