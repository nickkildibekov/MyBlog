﻿using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class PostDeleteTest
    {
        private BlogContext db;
        private PostRepository postRepository;
        private Mock<UnitOfWork> mockUOW;
        private Post post;
        private Post post1;
        private int idForTest;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            postRepository = new PostRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, postRepository );
            post = new Post
            {
                Title = "Amazon",
                Description = "Amazon daily deals for Tuesday, April 17",
                Category = "Technology",
                Content =
                    "If you\'re looking to add a little extra security for your house, Amazon has plenty of deals on surveillance cameras so you can keep an eye on things.\r\nDIYers can also pick up a DeWALT drill and impact combo kit for their next project, and outdoor enthusiasts can save up to 25% on boating and fishing gear. \r\n\r\nThere are also lightning deals on summer wear like tank tops and water shoes, not to mention smartphone charging accessories like an Anker power bank and a Qi-enabled wireless charger.\r\n",
                Author = "blogger123@com.com",
            };
            idForTest = 9;
            post1 = new Post();
        }

        [TestMethod]
        public void DeletePostTestReturnsNull()
        {
            //Act
            mockUOW.Object.Post.Create( post );
            mockUOW.Object.Save();
            post = mockUOW.Object.Post.Get( idForTest );
            mockUOW.Object.Post.Delete( post );
            mockUOW.Object.Save();
            post1 = mockUOW.Object.Post.Get( idForTest );

            //Assert
            Assert.IsNull( post1, "Deleted post's Id != null" );
        }
        
    }
}
