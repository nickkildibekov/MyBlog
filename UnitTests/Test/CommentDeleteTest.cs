using System.Linq;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class CommentDeleteTest
    {
        private BlogContext db;
        private CommentRepository commentRepository;
        private Mock<UnitOfWork> mockUOW;
        private Comment comment;
        private Comment comment1;
        private int idForTest;

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
                CurrentPost = db.Posts.FirstOrDefault( p => p.Id == 1 ),
                CurrentPostId = 1
            };
            idForTest = 1;
        }

        [TestMethod]
        public void DeleteCommentTestReturnsNull()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();
            comment = mockUOW.Object.Comment.Get( idForTest );
            mockUOW.Object.Comment.Delete( comment );
            mockUOW.Object.Save();
            comment1 = mockUOW.Object.Comment.Get( idForTest );

            //Assert
            Assert.IsNull( comment1, "Deleted comment != null after deleting." );
        }

    }
}
