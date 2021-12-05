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
    public class BlogRepository: IBlogRepository
    {
        readonly BlogDBEntities _entities = new BlogDBEntities();

        public List<BlogModel> GetBlog(string userid)
        {
            var blog = new List<BlogModel>();
            if (userid == null)
            {
                var blogList=_entities.Blogs.Where(x=>x.IsDeleted==false).ToList();
                foreach(var blogs in blogList)
                {
                    var blogCount = _entities.BlogLikes.Where(x => x.BlogId == blogs.BlogId).Count();
                    var blogModel = new BlogModel
                    {
                        UserId = blogs.AspNetUser.UserName,
                        BlogTitle = blogs.BlogTitle,
                        BlogDescription = blogs.BlogDescription,
                        Categoryname = blogs.Category.CategoryName,
                        BlogId = blogs.BlogId,
                        CreatedDate = blogs.CreatedDate,
                        IsDeleted = blogs.IsDeleted,
                        likeCount=blogCount
                    };
                    blog.Add(blogModel);
                }
            }
            else
            {
                blog = (from blogs in _entities.Blogs
                        where blogs.UserId == userid
                        select new BlogModel
                        {
                            UserId = blogs.AspNetUser.UserName,
                            BlogTitle = blogs.BlogTitle,
                            BlogDescription = blogs.BlogDescription,
                            Categoryname = blogs.Category.CategoryName,
                            BlogId = blogs.BlogId,
                            CreatedDate = blogs.CreatedDate,
                            IsDeleted = blogs.IsDeleted
                        }).ToList();
            }

            return blog;
        }

        public Tuple<int, string> AddBlog(BlogModel blogModel)
        {
            try
            {
                var blog = new Blog
                {
                    UserId = blogModel.UserId,
                    BlogTitle=blogModel.BlogTitle,
                    BlogDescription=blogModel.BlogDescription,
                    CategoryId=blogModel.CategoryId,
                    CreatedDate=DateTime.UtcNow,                    
                };

                _entities.Blogs.Add(blog);
                return new Tuple<int, string>(_entities.SaveChanges(), "Blog inserted");
            }
            catch (Exception)
            {
                return new Tuple<int, string>(-1, "Something went wrong!");
            }
        }

        public BlogModel GetBlogById(int id)
        {

            var blog = _entities.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog != null)
            {
                BlogModel objBlogModell = new BlogModel
                {
                    BlogId=blog.BlogId,
                    BlogDescription=blog.BlogDescription,
                    BlogTitle=blog.BlogTitle,
                    CategoryId=blog.CategoryId,
                    Username=blog.AspNetUser.UserName,
                    CreatedDate=blog.CreatedDate,
                };
                return objBlogModell;
            }
            return null;
        }

        public string UpdateBlog(BlogModel blogModel)
        {
            try
            {
                Blog blog = _entities.Blogs.Where(x => x.BlogId == blogModel.BlogId).FirstOrDefault();
                if (blog != null)
                {
                    blog.BlogTitle = blogModel.BlogTitle;
                    blog.BlogDescription = blogModel.BlogDescription;
                    
                    _entities.SaveChanges();
                    return "";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ToogleDeletedBlogState(int id)
        {
            try
            {
                Blog blog = _entities.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
                if (blog != null)
                {
                    blog.IsDeleted = !blog.IsDeleted;
                    _entities.SaveChanges();
                    return "";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
