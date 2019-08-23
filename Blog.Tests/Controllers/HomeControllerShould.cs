using Blog.Application;
using Blog.Contracts.ViewModels;
using Blog.Model;
using Blog.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerShould
    {
        [Test]
        public void Return_Home_Index()
        {
            
            var mockCtx = new Mock<ApplicationDbContext>();
            var categoryService = new CategoryService(mockCtx.Object);
            
            var controller = new HomeController(null,categoryService,null);
            var result = controller.Index() as ViewResult;
            var list = (List<HomeCategoryViewModel>)result.ViewData.Model;
            

            Assert.AreEqual(list[0].Name, "Odżywianie");
        }
    }
}
