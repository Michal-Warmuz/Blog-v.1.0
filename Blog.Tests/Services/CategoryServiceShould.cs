using Blog.Contracts.Services;
using Blog.Contracts.ViewModels;
using Blog.Model;
using Blog.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class CategoryServiceShould
    {
        [Test]
        public void Can_Filter_By_Category_Id()
        {
            Mock<IPostService> mock = new Mock<IPostService>();

            mock.Setup(m => m.Posts).Returns(new Post[] {

                new Post() {CategoryId = 1, Title="aaaaaaaaaa"},
                new Post() {CategoryId = 1, Title="aaaaaaaaaa"},
                new Post() {CategoryId = 2, Title="aaaaaaaaaa"},
                new Post() {CategoryId = 2, Title="aaaaaaaaaa"},
            });

            PostController controller = new PostController(mock.Object, null);


            Post[] result = ((PostsByCategoryViewModel)controller.GetPostByCategoryId(1).Model).Posts.ToArray();

            Assert.AreEqual(result.Length, 2);
        }
    }
}
