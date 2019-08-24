using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Contracts.Services
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAll();
        string GetUserName(string userId);
        string GetUserImageUrl(string userId);
        void ChangeAvatars(HttpPostedFileBase file, string Id);
    }
}
