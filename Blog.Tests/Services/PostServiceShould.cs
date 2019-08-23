using Blog.Application;
using Blog.Contracts.Services;
using Blog.Model;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class PostServiceShould
    {
        [Test]
        public void Can_Short_Content_Post()
        {
            var mockSet = new Mock<DbSet<Post>>();
            var mockCtx = new Mock<ApplicationDbContext>();

            mockCtx.Setup(x => x.Posts).Returns(mockSet.Object);
            PostService postService = new PostService(mockCtx.Object,null,null);

            Post post = new Post();
            post.Content = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            string result = postService.GetShortContent(post.Content);
            string expected = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa...";
            Assert.AreEqual(expected, result);
        }
    }
}
