using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Common.Models;
using Common.Services.Repositories;

namespace WebSite.Controllers
{
    public class PostsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

       
        public ActionResult Index()
        {
            var postList = unitOfWork.Post.GetList();
            return View( postList );
        }


        public ActionResult Details( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var post = unitOfWork.Post.Get( id );
            if (post == null)
            {
                return HttpNotFound();
            }
            return View( post );
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind( Include = "Id,Title,Description,Content,Category,PostedDateTime,ModifiedDateTime" )] Post post, HttpPostedFileBase file )
        {

            post.Author = User.Identity.Name;
            if (!ModelState.IsValid || file == null)
                return View( post );
            //attach the uploaded image to the object before saving to Database
            post.ImageMimeType = "image / jpeg" /*image.ContentLength*/;
            post.ImageData = new byte[file.ContentLength];
            file.InputStream.Read( post.ImageData, 0, file.ContentLength );

            //Save image to file
            var filename = file.FileName;
            var filePathOriginal = Server.MapPath( "~/Images/Original" );
            var savedFileName = Path.Combine( filePathOriginal, filename );
            file.SaveAs( savedFileName );

            //Read image back from file and create thumbnail from it
            var imageFile = Path.Combine( Server.MapPath( "~/Images/Original" ), filename );
            using (var srcImage = Image.FromFile( imageFile ))
            using (var newImage = new Bitmap( 100, 100 ))
            using (var graphics = Graphics.FromImage( newImage ))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage( srcImage, new Rectangle( 0, 0, 100, 100 ) );
                newImage.Save( stream, ImageFormat.Png );
                var thumbNew = File( stream.ToArray(), "image/png" );
                post.ImageThumbnail = thumbNew.FileContents;
            }
            post.PostedDateTime = DateTime.Now;
            unitOfWork.Post.Create( post );
            unitOfWork.Save();
            return RedirectToAction( "Index", "Home" );
        }

        [HttpGet]
        public ActionResult Edit( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var post = unitOfWork.Post.Get( id );
            if (post == null)
            {
                return HttpNotFound();
            }
            return View( post );
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind( Include = "Id,Title,Description,Content,Category,Author,ImageData,ImageThumbnail,ImageMimeType,PostedDateTime,ModifiedDateTime" )] Post post, HttpPostedFileBase file )
        {
            if (!ModelState.IsValid)
                return View( post );
            if (file != null)
            {
                //attach the uploaded image to the object before saving to Database
                post.ImageMimeType = "image / jpeg" /*image.ContentLength*/;
                post.ImageData = new byte[file.ContentLength];
                file.InputStream.Read( post.ImageData, 0, file.ContentLength );

                //Save image to file
                var filename = file.FileName;
                var filePathOriginal = Server.MapPath( "~/Images/Default" );
                var savedFileName = Path.Combine( filePathOriginal, filename );
                file.SaveAs( savedFileName );

                //Read image back from file and create thumbnail from it
                var imageFile = Path.Combine( Server.MapPath( "~/Images/Default" ), filename );
                using (var srcImage = Image.FromFile( imageFile ))
                using (var newImage = new Bitmap( 350, 200 ))
                using (var graphics = Graphics.FromImage( newImage ))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage( srcImage, new Rectangle( 0, 0, 350, 200 ) );
                    newImage.Save( stream, ImageFormat.Png );
                    var thumbNew = File( stream.ToArray(), "image/png" );
                    post.ImageThumbnail = thumbNew.FileContents;
                }
            }
            unitOfWork.Post.Edit( post );
            unitOfWork.Save();
            return RedirectToAction( "Index", "Home" );
        }

        public ActionResult Delete( int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var post = unitOfWork.Post.Get( id );
            if (post == null)
            {
                return HttpNotFound();
            }
            return View( post );
        }

        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed( int id )
        {
            {
                var post = unitOfWork.Post.Get( id );
                unitOfWork.Post.Delete( post );
                unitOfWork.Save();
                return RedirectToAction( "Index" );
            }
        }
        public FileContentResult GetThumbnailImage( int? id )
        {
            var post = unitOfWork.Post.Get( id );
            if (post.ImageThumbnail != null)
            {
                return File( post.ImageThumbnail, post.ImageMimeType );
            }
            else if (post.ImageThumbnail == null && post.ImageData == null)
            {
                var imageFile = Path.Combine( Server.MapPath( "~/Images/Original/NoImageAvailable.jpg" ) );
                post.ImageMimeType = "image / jpeg";
                using (var srcImage = Image.FromFile( imageFile ))
                using (var newImage = new Bitmap( 350, 200 ))
                using (var graphics = Graphics.FromImage( newImage ))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage( srcImage, new Rectangle( 0, 0, 350, 200 ) );
                    newImage.Save( stream, ImageFormat.Png );
                    var thumbNew = File( stream.ToArray(), "image/png" );
                    post.ImageThumbnail = thumbNew.FileContents;
                }
                return File( post.ImageThumbnail, post.ImageMimeType );
            }
            else 
            {
                var imageFile = Path.Combine( Server.MapPath( "~/Images/Default" ), post.DefaultImageName );
                using (var srcImage = Image.FromFile( imageFile ))
                using (var newImage = new Bitmap( 350, 200 ))
                using (var graphics = Graphics.FromImage( newImage ))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage( srcImage, new Rectangle( 0, 0, 350, 200 ) );
                    newImage.Save( stream, ImageFormat.Png );
                    var thumbNew = File( stream.ToArray(), "image/png" );
                    post.ImageThumbnail = thumbNew.FileContents;
                }
                return File( post.ImageThumbnail, post.ImageMimeType );
            }
        }
        public ActionResult ChangeStatus( int id )
        {
            var post = unitOfWork.Post.Get( id );
            if (post != null && post.IsDeclined || post != null && !post.IsApproved)
            {
                post.IsDeclined = false;
                post.IsApproved = true;
            }
            else if (post != null && post.IsApproved || post !=null && !post.IsDeclined)
            {
                post.IsApproved = false;
                post.IsDeclined = true;
            }
            unitOfWork.Post.Edit( post );
            unitOfWork.Save();
            return RedirectToAction( "Index","Home" );
        }
    }
}
