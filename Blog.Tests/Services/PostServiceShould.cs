using Blog.Application;
using Blog.Contracts.Services;
using Blog.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

           
            mockCtx.Setup(x=>x.Posts).Returns(mockSet.Object);
            PostService post = new PostService(mockCtx.Object);

            post.AddPost(new Post());

            mockCtx.Verify(s => s.Posts.Add(It.IsAny<Post>()), Times.Once());
            mockCtx.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
