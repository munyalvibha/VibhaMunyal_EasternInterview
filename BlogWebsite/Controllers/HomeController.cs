using BlogWebsite.Bal;
using BlogWebsite.Repository;
using BlogWebsite.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebsite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IBlogRepository objBlogRepository = new BlogRepository();
        IBlogLikeRepository objBlogLikeRepository = new BlogLikeRepository();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBlog()
        {
            var userExchangeInfo = objBlogRepository.GetBlog(null);
            return Json(userExchangeInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlogDetail(int blogId)
        {
            BlogModel blogModel = new BlogModel();

            if (blogId.ToString()!=null)
            {
                var blogDetail=objBlogRepository.GetBlogById(blogId);

                blogModel.BlogTitle = blogDetail.BlogTitle;
                blogModel.BlogDescription = blogDetail.BlogDescription;
                blogModel.Username = blogDetail.Username;
                blogModel.CreatedDate = blogDetail.CreatedDate;
                blogModel.BlogId = blogDetail.BlogId;

                return View(blogModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public JsonResult GetBlogLikeDetail(int blogId)
        {
            if (blogId.ToString() != null)
            {
                var blogLikeDetail = objBlogLikeRepository.GetBlogLikes(blogId);
                if (blogLikeDetail != null)
                {
                    return Json(blogLikeDetail, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}