using System.Linq;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class CommentEditTest
    {
        private BlogContext db;
        private CommentRepository commentRepository;
        private Mock<UnitOfWork> mockUOW;
        private Comment comment;
        private Comment comment1;
        private Comment comment2;
        private string contentForChange;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            commentRepository = new CommentRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, commentRepository );
            comment = new Comment
            {
                Id = 4,
                Author = "blogger123",
                Content = "Very usefull post.Thanks.",
                CurrentPost = db.Posts.FirstOrDefault( p => p.Id == 1 ),
                CurrentPostId = 1
            };
            contentForChange = "Some changed text";
        }

        
        [TestMethod]
        public void CommentEditTestReturnsPostWithAnotherContent()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();
            comment1 = mockUOW.Object.Comment.Get( 4 );
            comment1.Content = contentForChange;
            mockUOW.Object.Comment.Edit( comment );
            comment2 = mockUOW.Object.Comment.Get( 4 );

            //Assert
            Assert.AreEqual( comment2.Content, contentForChange,"Comment's content did not changed after it was edited." );
        }



    }
}
