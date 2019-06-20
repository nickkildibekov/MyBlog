using System.Collections.Generic;
using System.Linq;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class CommentGetListTest
    {
        private BlogContext db;
        private CommentRepository commentRepository;
        private Mock<UnitOfWork> mockUOW;
        private List<Comment> comments;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            commentRepository = new CommentRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, commentRepository );
            comments = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Author = "blogger123",
                    Content = "Very usefull post.Thanks.",
                    CurrentPost = db.Posts.FirstOrDefault(p => p.Id == 1),
                    CurrentPostId = 1
                },
                new Comment
                {
                    Id = 2,
                    Author = "traveller",
                    Content = "That is not true!",
                    CurrentPost = db.Posts.Where(p => p.Id == 1).ToList().FirstOrDefault(),
                    CurrentPostId = 1
                }
            };
            foreach (var testComment in comments)
            {
                mockUOW.Object.Comment.Create( testComment );
            }
            mockUOW.Object.Save();
        }

        [TestMethod]
        public void GetListOfCommentsReturnsNotNull()
        {
            //Act
            var testCommentsList = mockUOW.Object.Comment.GetList();
            //Assert
            Assert.IsNotNull( testCommentsList, "List of comments wasn't returned, testCommentsList == null" );
        }

        [TestMethod]
        public void GetListOfCommentsReturnsListOfCommentType()
        {
            //Act
            var testCommentsList = mockUOW.Object.Comment.GetList();
            //Assert
            Assert.IsInstanceOfType( testCommentsList, typeof( List<Comment> ),"Returned list of comments is not type of List<Comment>" );
        }
    }
}
