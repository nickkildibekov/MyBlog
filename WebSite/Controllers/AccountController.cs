using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.App_Data;
using Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        BlogContext db = BlogContext.Create();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register( RegisterModel model )
        {
            if (!ModelState.IsValid) return View(model);
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email};
            var result = await UserManager.CreateAsync( user, model.Password );
            if (result.Succeeded)
            {
                LoginModel loginModel = new LoginModel
                {
                    Email = model.Email,
                    Password = model.Password
                };
                string returnUrl = "";
                return await Login(loginModel,returnUrl);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View( model );
        }
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login( string returnUrl )
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login( LoginModel model, string returnUrl )
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync( model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError( "", "Wrong login or password" );
                }
                else
                {
                    var claim = await UserManager.CreateIdentityAsync( user,
                        DefaultAuthenticationTypes.ApplicationCookie );
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn( new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, claim );
                    if (string.IsNullOrEmpty( returnUrl ))
                        return RedirectToAction( "Index", "Home" );
                    return Redirect( returnUrl );
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction( "Index", "Home" );
        }
        [HttpGet]
        public async Task<ActionResult> Delete( string id )
        {
            ApplicationUser user = await UserManager.FindByIdAsync( id );
            if (user == null || user.Roles.ToString().Contains("Admin"))
            {
                return HttpNotFound();
            }
            return View( user );
        }

        [HttpPost]
        [ActionName( "Delete" )]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync( user );
                if (result.Succeeded)
                {
                    return RedirectToAction( "Index", "Home" );
                }
            }
            return RedirectToAction( "Index", "Home" );
        }

        public async Task<ActionResult> Edit(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync( id);
            if (user != null)
            {
                return View( user );
            }
            return RedirectToAction( "Login", "Account" );
        }

        [HttpPost]
        public async Task<ActionResult> Edit( ApplicationUser user )
        {
            if (user != null)
            {
                var result = await UserManager.UpdateAsync( user );
                if (result.Succeeded)
                {
                    return RedirectToAction( "Index", "Home" );
                }
                ModelState.AddModelError( "", "Something wrong" );
            }
            else
            {
                ModelState.AddModelError( "", "User not found" );
            }

            return View( user );
        }

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }
            var user = UserManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View( user );
        }
    }
}