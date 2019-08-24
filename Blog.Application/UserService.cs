using Blog.Contracts.Services;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Application
{
    public class UserService : IUserService
    {
        private ApplicationDbContext db;

        public UserService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetUserImageUrl(string userId)
        {
            return db.Users.SingleOrDefault(x => x.Id == userId).ImageUrl;
        }

        public string GetUserName(string userId)
        {
            return db.Users.SingleOrDefault(x => x.Id == userId).UserName;
        }

        public void ChangeAvatars(HttpPostedFileBase file, string Id)
        {
            var path = "";

            if (file != null && file.ContentLength > 0)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                   Path.GetExtension(file.FileName).ToLower() == ".jpeg" ||
                   Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                   Path.GetExtension(file.FileName).ToLower() == ".png")
                {
                    

                    path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("/Content/Images/"), file.FileName);

                    file.SaveAs(path);
                }

                path = Path.Combine(Directory.GetCurrentDirectory(), @"/Content/Images/", file.FileName);
            }
            
            var user = db.Users.FirstOrDefault(x => x.Id == Id);
            user.ImageUrl = path;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
