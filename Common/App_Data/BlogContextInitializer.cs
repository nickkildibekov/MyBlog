using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Web;
using Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Common.App_Data
{
    public class BlogContextInitializer : CreateDatabaseIfNotExists<BlogContext>
    {

        protected override void Seed( BlogContext db )
        {
            var categories = new List<Category>
            {
                new Category {Id = 1, Name = "Travel", Description = "Category about Travel"},
                new Category {Id = 2, Name = "Technology", Description = "Category about Technology"},
                new Category {Id = 3, Name = "Sport", Description = "Category about Sport"},
                new Category {Id = 4, Name = "Recreation", Description = "Category about Recreation"},
                new Category {Id = 5, Name = "Misc", Description = "Category about Misc"}
            };
            categories.ForEach( c => db.Categories.Add( c ) );
            db.SaveChanges();

            var posts = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Title = "Amazon",
                    Description = "Amazon daily deals for Tuesday, April 17",
                    Category = "Technology",
                    Content =
                        "If you\'re looking to add a little extra security for your house, Amazon has plenty of deals on surveillance cameras so you can keep an eye on things.\r\nDIYers can also pick up a DeWALT drill and impact combo kit for their next project, and outdoor enthusiasts can save up to 25% on boating and fishing gear. \r\n\r\nThere are also lightning deals on summer wear like tank tops and water shoes, not to mention smartphone charging accessories like an Anker power bank and a Qi-enabled wireless charger.\r\n",
                    Author = "blogger123@com.com",
                    DefaultImageName = "amazon.jpg",
                    ImageMimeType = "image / jpeg",
                    ImageData = FileToByteArray("~/Images/Default/amazon.jpg"),
                    IsApproved = true
        },
                new Post
                {
                    Id = 2,
                    Title = "Ford",
                    Description = "Ford charges into electric bike-sharing",
                    Category = "Technology",
                    Content =
                        "I got to try one out ahead of time, taking a test ride through San Francisco\'s crowded South of Market and hilly Potrero Hill neighborhoods. My prediction: The e-bike, a Ford GoBike Plus, will be in high demand. The motor provides a jolt of pep, and I was able to climb a fairly steep two blocks of Mississippi Street — something I never would have done on a regular bicycle.\r\n\r\nMotivate, the bike-share operator behind Citi Bike in New York City, rushed to bring the new e-bikes into the Bay Area after a spate of other e-bikes and scooters flooded the market. Like its pedal-powered cousin, the new bikes require a dock. These aren\'t a jump-on-and-drop-off anywhere option, but you don\'t have to worry about blocking the sidewalk or walkway, since the bike has a designated space. \r\n\r\nFord’s e-bikes follow the trend from Chinese bike companies that have crept into North American cities. In China, the electric bikes have been popular for the past few years, but the easy-to-ride bicycles come with major issues, like sidewalk litter, rampant theft, and mass bicycle graves filled with broken and abandoned bikes. \r\n\r\nAlso in the mix is Uber\'s recently acquired Jump e-bikes, a San-Francisco-based share program. Those don\'t require a dock, but they feel less zippy compared to the Ford bikes. The built-in U-locks on the red Jump bikes do make it easier to use a bike rack wherever you go. A Motivate spokesperson said Ford is researching a dockless version of its bicycles.",
                    Author = "blogger123@com.com",
                    DefaultImageName = "ford.jpg",
                    ImageMimeType = "image / jpeg",
                    ImageData = FileToByteArray("~/Images/Default/ford.jpg"),
                    IsApproved = true
                },
                new Post
                {
                    Id = 3,
                    Title = "RAVPower",
                    Description = "These deals on RAVPower chargers are too good to pass up",
                    Category = "Technology",
                    Content =
                        "You have plenty of gadgets, new and old, that need charging. Save big while RAVPower devices are on sale and charge them all.\r\n\r\nSEE ALSO: This glow-in-the-dark MFi-certified charging cable is just $20\r\n\r\nAmazon has some great deals today on RAVPower chargers to keep your devices juiced up. From Qi-enabled wireless charging to USB devices, there are plenty of deals to help you make sure you don\'t run out of power. \r\n\r\nCheck out the RAVPower chargers on sale today:\r\n\r\nWireless and ready\r\nThis charging pad works with any newer phone like the iPhone X and Samsung Galaxy S9. It also features an indicator light to let you know when your device is done charging. You can save a whopping 82% on it today.",
                    Author = "blogger123@com.com",
                    DefaultImageName = "ravp.jpg",
                    ImageMimeType = "image / jpeg",
                    ImageData = FileToByteArray("~/Images/Default/ravp.jpg"),
                    IsApproved = true
                },
                new Post
                {
                    Id = 4,
                    Title = "EarthDay",
                    Description = "The Samsung Galaxy S8, Echo devices, and more used items are on sale for Earth Day",
                    Category = "Technology",
                    Content =
                        "While April 22 isn\'t typically a huge shopping holiday, you didn\'t think Amazon was about to not use this as an excuse to have a giant sale, did you? In honor of Earth Day, save big on select used tech items across the site. Sales end at 11:59 pm PST on April 22.\r\n\r\nSEE ALSO: Solar-charging backpacks let you power up while on the go and these are some of our favorites\r\n\r\nE-waste is wreaking havoc on the Earth at a pretty alarming rate, with nearly 70% of toxins in landfills coming from electronics. \r\n\r\nThe Amazon Warehouse is aiming to give used items a new home. In the spirit of reducing, reusing, and recycling, Amazon is offering tons of deals, plus an extra 20% off on select used items. \r\n\r\nSave on everything from smartphones, to robot vacuums, to kitchen gadgets, and more. Many of these items are high-end and don\'t usually see discounts, so this sale is kind of a big deal.",
                    Author = "blogger123@com.com",
                    DefaultImageName = "samsung.jpg",
                    ImageMimeType = "image / jpeg",
                    ImageData = FileToByteArray("~/Images/Default/samsung.jpg"),
                    IsApproved = true

                },
                new Post
                {
                    Id = 5,
                    Title = "Headphones",
                    Description = "These Bose wireless headphones are sweat-resistant and $50 off",
                    Category = "Technology",
                    Content =
                        "Break free from wires for good and make those trips to the gym even easier with these Bose SoundSport wireless headphones that are on sale today for $50 off.\r\n\r\nSEE ALSO: Make any headphones wireless with this $20 Bluetooth receiver\r\n\r\nThese headphones are sweat and weather-resistant so you can go HAM without worry. They comes with three different tips to fit comfortably and provide up to five hours of play time on a single charge. They also come with a charging case to keep them powered up on the go, and you can even keep track of them with Bose\'s \"Find My Buds\" app.\r\n\r\nPlus, they look super badass.\r\n\r\nAmazon lists the price at $249, but you can get them now for only $199 — a 20% savings.",
                    Author = "sport123@com.com",
                    DefaultImageName = "bose.jpg",
                    ImageMimeType = "image / jpeg",
                    ImageData = FileToByteArray("~/Images/Default/bose.jpg"),
                    IsApproved = true
                },
                new Post
                {
                    Id = 6,
                    Title = "MothersDay",
                    Description = "21 Mother's Day gifts for the tech-savvy mom",
                    Category = "Technology",
                    Content =
                        "Paying back our moms for all that they do is no easy task. But we can always try come Mother\'s Day with some sweet, tech-centric gifts.\r\n\r\nSEE ALSO: Traditional anniversary gifts, reimagined for millennial couples\r\n\r\nNot all moms need special instructions just for turning on the TV. If your mom is the first to adopt the latest streaming device, knows all the iPhone hacks, and is even teaching you a thing or two, then these are the gifts for her. From portable tech that she can take to work to home gadgets that she can use around the house, these awesome tech gifts are sure to be right in her wheelhouse.\r\n\r\nFor moms who hit the gym\r\nA Fitbit is a great go-to gift for anyone who wants to get fit, or is looking to download all the data or their latest sweat session. This classic, easy-to-use fitness tracker is a bestseller for a reason and could help your fitness fanatic mom stay on her toes.",
                    Author = "sport123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 7,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "sport123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 8,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "sport123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 9,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "sport123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 10,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "profi123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 11,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "profi123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 12,
                    Title = "Madrid",
                    Description = "Travelling to Madrid? Here are some of the best spots off the beaten path",
                    Category = "Travel",
                    Content =
                        "With its beautiful architecture, lively culture, and delicious cuisine, few cities can compare to the wonders that can be found in Madrid. And while locations like the Prado museum, Retiro park, and Royal Palace usually top visitors’ bucket list, oftentimes it’s the lesser-known spots that create the richest experiences.\r\n\r\nIn the spirit of channelling our inner wanderlust, we set out to discover the best places in Madrid that fly under the radar. This isn’t your ordinary travel guide: read on to discover our picks for some of the best things to do, see, and eat in Madrid — and experience the city like a true Madrileño.   \r\n\r\nWHAT TO DO\r\n\r\nFor couples: Most people think of the Rioja region when they think of Spanish wine, but Madrid is actually surrounded by vineyards — some of which are just a bus or train ride away. You and your significant other can take a day trip to the Vinos de Madrid, which includes three different subsections, and sample local wines while taking in the breath-taking scenery. There are plenty of tour options for each area.\r\n\r\nFor business travellers: If you’re in Madrid on business, Miss Filatelista blogger Lola Mendez recommends you check out Google Campus Madrid, a collaborative space made for everyone from entrepreneurs to freelancers. You can sign up for free access and use it as a makeshift office during your travels. There’s also an onsite café if you prefer a more laid-back",
                    Author = "profi123@com.com",
                    IsDeclined = true
                },
                new Post
                {
                    Id = 13,
                    Title = "Instagram",
                    Description = "Instagram blogger Photoshops her body to look how trolls want it to look",
                    Category = "Recreation",
                    Content =
                        "Sadly, the reality of having any kind of online presence in this day and age seems to come hand in hand with receiving negative and abusive comments. It\'s unpleasant, upsetting, and sometimes, deeply personal. \r\n\r\nSEE ALSO: How to protect yourself when social media is harming your self-esteem\r\n\r\n\r\nA popular British fitness blogger did something rather unusual with the negative Instagram DMs she received after posting shots of herself working out on her Instagram Story. She Photoshopped the images to reflect the abusive comments left by trolls and added them to her Story. And, the results were nothing short of terrifying.\r\n\r\nChessie King worked with anti-cyberbullying non-profit organisation Cybersmile to highlight the harmful effect of online abuse on young people.\r\n\r\nKing, who has over 330K Instagram followers, posted a series of photos and video of herself on her Instagram Story. Those photos and videos were then \"altered in real-time\" to reflect the replies she was receiving from trolls. \r\n\r\nTrolling is something that\'s sadly become part of King\'s everyday life as an Instagram blogger. But, research shows that it\'s not just bloggers and influencers who receive online abuse. Research conducted by Data and Society Research Institute found that 47 percent of internet users have \"personally experienced online harassment or abuse.\"",
                    Author = "profi123@com.com",
                    IsDeleted = true
                },
                new Post
                {
                    Id = 14,
                    Title = "Instagram",
                    Description = "Instagram blogger Photoshops her body to look how trolls want it to look",
                    Category = "Misc",
                    Content =
                        "Sadly, the reality of having any kind of online presence in this day and age seems to come hand in hand with receiving negative and abusive comments. It\'s unpleasant, upsetting, and sometimes, deeply personal. \r\n\r\nSEE ALSO: How to protect yourself when social media is harming your self-esteem\r\n\r\n\r\nA popular British fitness blogger did something rather unusual with the negative Instagram DMs she received after posting shots of herself working out on her Instagram Story. She Photoshopped the images to reflect the abusive comments left by trolls and added them to her Story. And, the results were nothing short of terrifying.\r\n\r\nChessie King worked with anti-cyberbullying non-profit organisation Cybersmile to highlight the harmful effect of online abuse on young people.\r\n\r\nKing, who has over 330K Instagram followers, posted a series of photos and video of herself on her Instagram Story. Those photos and videos were then \"altered in real-time\" to reflect the replies she was receiving from trolls. \r\n\r\nTrolling is something that\'s sadly become part of King\'s everyday life as an Instagram blogger. But, research shows that it\'s not just bloggers and influencers who receive online abuse. Research conducted by Data and Society Research Institute found that 47 percent of internet users have \"personally experienced online harassment or abuse.\"",
                    Author = "profi123@com.com",
                    IsDeleted = true
                },
                new Post
                {
                    Id = 15,
                    Title = "Instagram",
                    Description = "Instagram blogger Photoshops her body to look how trolls want it to look",
                    Category = "Sport",
                    Content =
                        "Sadly, the reality of having any kind of online presence in this day and age seems to come hand in hand with receiving negative and abusive comments. It\'s unpleasant, upsetting, and sometimes, deeply personal. \r\n\r\nSEE ALSO: How to protect yourself when social media is harming your self-esteem\r\n\r\n\r\nA popular British fitness blogger did something rather unusual with the negative Instagram DMs she received after posting shots of herself working out on her Instagram Story. She Photoshopped the images to reflect the abusive comments left by trolls and added them to her Story. And, the results were nothing short of terrifying.\r\n\r\nChessie King worked with anti-cyberbullying non-profit organisation Cybersmile to highlight the harmful effect of online abuse on young people.\r\n\r\nKing, who has over 330K Instagram followers, posted a series of photos and video of herself on her Instagram Story. Those photos and videos were then \"altered in real-time\" to reflect the replies she was receiving from trolls. \r\n\r\nTrolling is something that\'s sadly become part of King\'s everyday life as an Instagram blogger. But, research shows that it\'s not just bloggers and influencers who receive online abuse. Research conducted by Data and Society Research Institute found that 47 percent of internet users have \"personally experienced online harassment or abuse.\"",
                    Author = "profi123@com.com",
                    IsDeleted = true
                }

            };
            posts.ForEach( p => db.Posts.Add( p ) );
            db.SaveChanges();

           var comments = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Author = "blogger123",
                    Content = "Very usefull post.Thanks.",
                    CurrentPost = db.Posts.Where(p => p.Id == 1).ToList().FirstOrDefault(),
                    CurrentPostId = 1
                },
                new Comment
                {
                    Id = 2,
                    Author = "traveller",
                    Content = "That is not true!",
                    CurrentPost = db.Posts.Where(p => p.Id == 1).ToList().FirstOrDefault(),
                    CurrentPostId = 1
                },
                new Comment
                {
                    Id = 3,
                    Author = "sportsman",
                    Content = "Hello everybody",
                    CurrentPost = db.Posts.Where(p => p.Id == 1).ToList().FirstOrDefault(),
                    CurrentPostId = 1
                }
            };
            comments.ForEach( c => db.Comments.Add( c ) );
            db.SaveChanges();

            var passwordHash = new PasswordHasher();
            var users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        Id = "2",
                        UserName = "blogger123",
                        Email = "blogger123@com.com",
                        PasswordHash = passwordHash.HashPassword("blogger123")
                    },
                    new ApplicationUser()
                    {
                        Id = "3",
                        UserName = "traveller",
                        Email = "paris123@com.com",
                        PasswordHash = passwordHash.HashPassword("travel123")
                    },
                    new ApplicationUser()
                    {
                        Id = "4",
                        UserName = "sportsman",
                        Email = "sport123@com.com",
                        PasswordHash = passwordHash.HashPassword("sportl123")
                    },
                    new ApplicationUser()
                    {
                        Id = "4",
                        UserName = "professor",
                        Email = "profi123@com.com",
                        PasswordHash = passwordHash.HashPassword("profl123")
                    }
                };
            if (!db.Roles.Any( r => r.Name == "Admin" ))
            {

                var store = new RoleStore<IdentityRole>( db );
                var manager = new RoleManager<IdentityRole>( store );
                var role = new IdentityRole { Name = "Admin" };
                manager.Create( role );
            }

            if (!db.Roles.Any( r => r.Name == "User" ))
            {
                var store = new RoleStore<IdentityRole>( db );
                var manager = new RoleManager<IdentityRole>( store );
                var role = new IdentityRole { Name = "User" };
                manager.Create( role );
            }

            foreach (var user in users)
            {
                var userManager = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>( db ) );
                if (db.Users.Any( u => u.Id == user.Id ))
                    continue;
                userManager.Create( user );
                userManager.AddToRole( user.Id, "User" );
            }


            if (!db.Users.Any( u => u.UserName == "admin@admin.com" ))
            {
                var userManager = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>( db ) );
                var user = new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash.HashPassword( "admin" )
                };

                userManager.Create( user );
                userManager.AddToRole( user.Id, "Admin" );
            }
        }
       
        public byte[] FileToByteArray( string fileName )
        {
            fileName = HttpContext.Current.Server.MapPath( fileName );
            if (fileName != null)
            {
                FileStream fs = new FileStream( fileName,
                    FileMode.Open,
                    FileAccess.Read );
                BinaryReader br = new BinaryReader( fs );
                long numBytes = new FileInfo( fileName ).Length;
                br.ReadBytes( (int)numBytes );
            }
            return File.ReadAllBytes( fileName );
        }
    }

}



