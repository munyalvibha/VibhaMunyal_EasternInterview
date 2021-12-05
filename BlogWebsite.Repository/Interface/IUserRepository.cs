using BlogWebsite.Bal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Repository.Interface
{
    public interface IUserRepository
    {
        List<CategoryModel> GetCategories();
        UserModel GetUserProfile(string userId);
    }
}
