using Blog.Application;
using Blog.Contracts.Services;
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


            var mockCtx = new  Mock<ICategoryService>();
            mockCtx.Setup(m => m.GetAllHomeCategory()).Returns(new List<HomeCategoryViewModel>
            {
                new HomeCategoryViewModel() { CategoryId = 1, Name = "P1"},
                new HomeCategoryViewModel() { CategoryId = 2, Name = "P2"}
            });

           
            var controller = new HomeController(null,mockCtx.Object,null);
            var result = controller.Index() as ViewResult;
            var list = (List<HomeCategoryViewModel>)result.ViewData.Model;
            

            Assert.AreEqual(list[0].Name, "P1");
        }
    }
}
