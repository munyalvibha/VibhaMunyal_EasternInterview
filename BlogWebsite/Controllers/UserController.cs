using BlogWebsite.Bal;
using BlogWebsite.Repository;
using BlogWebsite.Repository.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebsite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserRepository objUserRepository = new UserRepository();
        public ActionResult Profile(UserModel model)
        {
            var user = objUserRepository.GetUserProfile(User.Identity.GetUserId());
            if (user != null)
            {
                model.UserName = user.UserName;
                model.Email = user.Email;
                model.PhoneNumber = user.PhoneNumber;
            }
            else
            {
                ViewBag.ErrorMessage = "Something went wrong! Please try later";
            }
            return View(model);
        }
    }
}