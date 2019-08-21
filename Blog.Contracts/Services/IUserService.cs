﻿using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Contracts.Services
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAll();
    }
}