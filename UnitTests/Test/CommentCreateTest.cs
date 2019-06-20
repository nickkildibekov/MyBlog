using System.Linq;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class CommentCreateTest
    {
        private BlogContext db;
        private CommentRepository commentRepository;
        private Mock<UnitOfWork> mockUOW;
        private Comment comment;
        private Comment comment1;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            commentRepository = new CommentRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, commentRepository );
            comment = new Comment
                {
                    Author = "blogger123",
                    Content = "Very usefull post.Thanks.",
                    CurrentPost = db.Posts.FirstOrDefault(p => p.Id == 1),
                    CurrentPostId = 1
            };
        }

        [TestMethod]
        public void CommentCreateTestCommentIdBiggerThenNull()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();

            //Assert
            Assert.IsTrue( comment.Id > 0, "Created comment's Id <= 0" );
        }

        [TestMethod]
        public void CommentCreateTestReturnsGetCommentByIdTest()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();
            comment1 = mockUOW.Object.Comment.Get( comment.Id );

            //Assert
            Assert.AreEqual( comment1, comment, "Could not get created comment by it's Id" );
        }

    }
}
