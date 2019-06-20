using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Common.App_Data;
using Common.Models;
using Common.Services.Repositories;

namespace WebSite.Controllers
{
    public class CommentsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Comments
        public ActionResult Index()
        {
            var commentList = unitOfWork.Comment.GetList();
            return View( commentList);
        }

        // GET: Comments/Details/5
        public ActionResult Details( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var comment = unitOfWork.Comment.Get( id );
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View( comment );
        }


        [HttpPost]
        public void Create( Comment comment, int postId )
        {
            var post = unitOfWork.Post.Get(postId);
            var newComment = new Comment
            {
                CurrentPost = post,
                Author = comment.Author,
                Content = comment.Content,
                CurrentPostId = postId
            };
            if (newComment.Author == null)
                newComment.Author = "Unknown";
            unitOfWork.Comment.Create(newComment);
            unitOfWork.Save();
        }


        // GET: Comments/Edit/5
        public ActionResult Edit( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var comment = unitOfWork.Comment.Get(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View( comment );
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( [Bind( Include = "Id,Content,Author,PostId" )] Comment comment )
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Comment.Edit(comment);
                unitOfWork.Save();
                return RedirectToAction( "Index" );
            }
            return View( comment );
        }

        // GET: Comments/Delete/5
        public ActionResult Delete( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var comment = unitOfWork.Comment.Get( id );
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View( comment );
        }

        // POST: Comments/Delete/5
        [HttpPost,ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed( int id )
        {
            var comment = unitOfWork.Comment.Get( id );
            unitOfWork.Comment.Delete( comment );
            unitOfWork.Save();
            return RedirectToAction( "Index" );
        }
    }
}
