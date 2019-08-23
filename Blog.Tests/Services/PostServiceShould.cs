using Blog.Application;
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
        public void Add_New_Post_To_Context()
        {
            var mockSet = new Mock<DbSet<Post>>();
            var mockCtx = new Mock<ApplicationDbContext>();

            mockCtx.Setup(x => x.Posts).Returns(mockSet.Object);
            PostService post = new PostService(mockCtx.Object,null);

            post.AddPost(new Post());

            mockCtx.Verify(s => s.Posts.Add(It.IsAny<Post>()), Times.Once());
            mockCtx.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Test]
        public void Can_Short_Content_Post()
        {
            var mockSet = new Mock<DbSet<Post>>();
            var mockCtx = new Mock<ApplicationDbContext>();

            mockCtx.Setup(x => x.Posts).Returns(mockSet.Object);
            PostService postService = new PostService(mockCtx.Object,null);

            Post post = new Post();
            post.Content = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            string result = postService.GetShortContent(post.Content);
            string expected = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa...";
            Assert.AreEqual(expected, result);
        }
    }
}
