using System.Collections.Generic;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Test
{
    [TestClass]
    public class PostGetListTest
    {
        private BlogContext db;
        private PostRepository postRepository;
        private Mock<UnitOfWork> mockUOW;
        private List<Post> posts;

        [TestInitialize]
        public void Initialize()
        {
            db = new BlogContext();
            postRepository = new PostRepository( db );
            mockUOW = new Mock<UnitOfWork>( db, postRepository );
            posts = new List<Post>()
            {
                new Post
                {
                    Id = 200,
                    Title = "Amazon",
                    Description = "Amazon daily deals for Tuesday, April 17",
                    Category = "Technology",
                    Content =
                        "If you\'re looking to add a little extra security for your house, Amazon has plenty of deals on surveillance cameras so you can keep an eye on things.\r\nDIYers can also pick up a DeWALT drill and impact combo kit for their next project, and outdoor enthusiasts can save up to 25% on boating and fishing gear. \r\n\r\nThere are also lightning deals on summer wear like tank tops and water shoes, not to mention smartphone charging accessories like an Anker power bank and a Qi-enabled wireless charger.\r\n",
                    Author = "blogger123@com.com",
                },
                new Post
                {
                    Id = 300,
                    Title = "Ford",
                    Description = "Ford charges into electric bike-sharing",
                    Category = "Technology",
                    Content =
                        "I got to try one out ahead of time, taking a test ride through San Francisco\'s crowded South of Market and hilly Potrero Hill neighborhoods. My prediction: The e-bike, a Ford GoBike Plus, will be in high demand. The motor provides a jolt of pep, and I was able to climb a fairly steep two blocks of Mississippi Street — something I never would have done on a regular bicycle.\r\n\r\nMotivate, the bike-share operator behind Citi Bike in New York City, rushed to bring the new e-bikes into the Bay Area after a spate of other e-bikes and scooters flooded the market. Like its pedal-powered cousin, the new bikes require a dock. These aren\'t a jump-on-and-drop-off anywhere option, but you don\'t have to worry about blocking the sidewalk or walkway, since the bike has a designated space. \r\n\r\nFord’s e-bikes follow the trend from Chinese bike companies that have crept into North American cities. In China, the electric bikes have been popular for the past few years, but the easy-to-ride bicycles come with major issues, like sidewalk litter, rampant theft, and mass bicycle graves filled with broken and abandoned bikes. \r\n\r\nAlso in the mix is Uber\'s recently acquired Jump e-bikes, a San-Francisco-based share program. Those don\'t require a dock, but they feel less zippy compared to the Ford bikes. The built-in U-locks on the red Jump bikes do make it easier to use a bike rack wherever you go. A Motivate spokesperson said Ford is researching a dockless version of its bicycles.",
                    Author = "blogger123@com.com",
                }
            };
            foreach (var testPost in posts)
            {
                mockUOW.Object.Post.Create( testPost );
            }
            mockUOW.Object.Save();
        }

        [TestMethod]
        public void GetListOfPostsReturnsNotNull()
        {
            //Act
            var testPostsList = mockUOW.Object.Post.GetList();
            //Assert
            Assert.IsNotNull( testPostsList, "List of posts is not returned, it == null" );
        }

        [TestMethod]
        public void GetListOfPostsReturnsListOfPostType()
        {
            //Act
            var testPostsList = mockUOW.Object.Post.GetList();
            //Assert
            Assert.IsInstanceOfType( testPostsList, typeof( List<Post> ),"Returned List of posts's type is not Post" );
        }
    }
}
