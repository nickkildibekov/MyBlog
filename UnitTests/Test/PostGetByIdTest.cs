using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class PostGetByIdTest
    {
        private BlogContext db;
        private PostRepository postRepository;
        private Mock<UnitOfWork> mockUOW;
        private Post post;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            postRepository = new PostRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, postRepository );
            post = new Post
            {
                Id = 100,
                Title = "Amazon",
                Description = "Amazon daily deals for Tuesday, April 17",
                Category = "Technology",
                Content =
                    "If you\'re looking to add a little extra security for your house, Amazon has plenty of deals on surveillance cameras so you can keep an eye on things.\r\nDIYers can also pick up a DeWALT drill and impact combo kit for their next project, and outdoor enthusiasts can save up to 25% on boating and fishing gear. \r\n\r\nThere are also lightning deals on summer wear like tank tops and water shoes, not to mention smartphone charging accessories like an Anker power bank and a Qi-enabled wireless charger.\r\n",
                Author = "blogger123@com.com",
            };
            mockUOW.Object.Post.Create( post );
            mockUOW.Object.Save();
        }

        [TestMethod]
        public void GetPostByIdReturnsNotNull()
        {
            //Act
            Post testPost = mockUOW.Object.Post.Get(100);
            //Assert
            Assert.IsNotNull(testPost,"Created post is not returning by it's Id");
        }

        [TestMethod]
        public void GetPostByIdReturnsPostType()
        {
            //Act
            Post testPost = mockUOW.Object.Post.Get( 100 );
            //Assert
            Assert.IsInstanceOfType(testPost, typeof(Post),"Returned by Id post's type is not Post");
        }
    }
}
