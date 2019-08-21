using Blog.Contracts.Services;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
