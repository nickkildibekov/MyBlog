using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common.App_Data;
using Common.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                Categories = db.Categories,
                Posts = db.Posts
            };
            return View( indexViewModel );
        }

        public PartialViewResult PostSearch(string text)
        {
            var searchFilterList = db.Posts.Where(a => a.Content.Contains(text)).ToList();
            return PartialView("PostSearch", searchFilterList);
        }

        public PartialViewResult CategoryFilter(string text)
        {
            var searchFilterList = db.Posts.Where(a => a.Category == text).ToList();
            return PartialView("CategoryFilter", searchFilterList);
        }

        public PartialViewResult AuthorFilter( string text )
        {
            var searchFilterList = db.Posts.Where( a => a.Author == text ).ToList();
            return PartialView( "AuthorFilter", searchFilterList );
        }

        
        public PartialViewResult PostViewUnauth( int id )
        {
            var viewModelDetail =
                new PostAndComment
                {
                    Posts = db.Posts.Where(a => a.Id == id).ToList(),
                    Comments = db.Comments.ToList()
                };
            return PartialView( "PostViewUnauth", viewModelDetail );
        }

        public PartialViewResult ApprovedStateFilter( bool state )
        {
            var searchFilterList = db.Posts.Where( a => a.IsApproved == state ).ToList();
            return PartialView( "StateFilter", searchFilterList );
        }
        public PartialViewResult DeclinedStateFilter( bool state )
        {
            var searchFilterList = db.Posts.Where( a => a.IsDeclined == state ).ToList();
            return PartialView( "StateFilter", searchFilterList );
        }
        public PartialViewResult DeletedStateFilter( bool state )
        {
            var searchFilterList = db.Posts.Where( a => a.IsDeleted == state ).ToList();
            return PartialView( "StateFilter", searchFilterList );
        }

        public PartialViewResult NewStateFilter( bool state )
        {
            var searchFilterList = db.Posts.Where( a => !a.IsDeleted && !a.IsApproved && !a.IsDeclined == state ).ToList();
            return PartialView( "StateFilter", searchFilterList );
        }


    }


}