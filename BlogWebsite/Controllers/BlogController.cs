using BlogWebsite.Bal;
using BlogWebsite.Repository;
using BlogWebsite.Repository.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogWebsite.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        IUserRepository objUserRepository = new UserRepository();
        IBlogRepository objBlogRepository = new BlogRepository();

        public ActionResult Blog()
        {
            return View();
        }

        public JsonResult GetCategory()
        {
            var category = objUserRepository.GetCategories();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlog()
        {
            var userid = User.Identity.GetUserId();
            var blogList = objBlogRepository.GetBlog(userid);
            if(blogList.Count>0)
                return Json(blogList, JsonRequestBehavior.AllowGet);
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddBlog(BlogModel blogModel)
        {
            try
            {
                blogModel.UserId = User.Identity.GetUserId();
                var result = objBlogRepository.AddBlog(blogModel);
                return Json(new
                {
                    code = result.Item1,
                    message = result.Item2,
                });
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Something Went Wrong.");
            }
        }

        [HttpGet]
        public ActionResult GetBlogById(int id)
        {
            try
            {
                var reult = objBlogRepository.GetBlogById(id);
                return Json(reult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Something Went Wrong.");
            }
        }

        [HttpPost]
        public ActionResult UpdateBlog(BlogModel blogModel)
        {
            try
            {
                var reult = objBlogRepository.UpdateBlog(blogModel);
                return Json(reult);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Something Went Wrong.");
            }
        }

        public ActionResult DeleteBlog(int id)
        {
            try
            {
                var result = objBlogRepository.ToogleDeletedBlogState(id);
                return Json(result);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Something Went Wrong.");
            }
        }

    }
}