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
    public class UserRepository: IUserRepository
    {
        readonly BlogDBEntities _entities = new BlogDBEntities();

        public List<CategoryModel> GetCategories()
        {
            return _entities.Categories.Select(x=>new CategoryModel { 
                CategoryId=x.CategoryId,
                CategoryName=x.CategoryName
            }).ToList();
        }

        public UserModel GetUserProfile(string userId)
        {
            var user = _entities.AspNetUsers.Where(x => x.Id == userId).Select(x=>new UserModel { 
                Email=x.Email,
                PhoneNumber=x.PhoneNumber,
                UserName=x.UserName
            }).FirstOrDefault();
            if(user!=null)
                return user;

            return null;
        }
    }
}
