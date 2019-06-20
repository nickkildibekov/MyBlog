using System.Linq;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class CommentGetByIdTest
    {
        private BlogContext db;
        private CommentRepository commentRepository;
        private Mock<UnitOfWork> mockUOW;
        private Comment comment;


        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            commentRepository = new CommentRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, commentRepository );
            comment = new Comment
            {
                Id = 5,
                Author = "blogger123",
                Content = "Very usefull post.Thanks.",
                CurrentPost = db.Posts.FirstOrDefault( p => p.Id == 1 ),
                CurrentPostId = 1
            };
        }

        [TestMethod]
        public void CommentGetByIdReturnsNotNull()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();
            Comment testComment = mockUOW.Object.Comment.Get( 5);
            //Assert
            Assert.IsNotNull( testComment,"Comment wasn't created, it == null" );
        }

        [TestMethod]
        public void CommentGetByIdReturnsCommentType()
        {
            //Act
            mockUOW.Object.Comment.Create( comment );
            mockUOW.Object.Save();
            Comment testComment = mockUOW.Object.Comment.Get( 5 );
            //Assert
            Assert.IsInstanceOfType( testComment, typeof( Comment ),"Created comment type is not Comment" );
        }
    }
}
