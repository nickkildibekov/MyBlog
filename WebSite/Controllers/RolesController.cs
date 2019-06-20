using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.App_Data;
using Common.Models;
using Common.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebSite.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationRoleManager RoleManager => HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            return View( db.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create( ApplicationRole model )
        {
            if (!ModelState.IsValid) return View(model);
            var result = await RoleManager.CreateAsync( new ApplicationRole
            {
                Name = model.Name,
            } );
            if (result.Succeeded)
            {
                return RedirectToAction( "Index" );
            }
            else
            {
                ModelState.AddModelError( "", "Something went wrong!" );
            }
            return View( model );
        }

        public async Task<ActionResult> Edit( string id )
        {
            var role = await RoleManager.FindByIdAsync( id );
            if (role != null)
            {
                return View( new ApplicationRole { Id = role.Id, Name = role.Name} );
            }
            return RedirectToAction( "Index" );
        }
        [HttpPost]
        public async Task<ActionResult> Edit( ApplicationRole model )
        {
            if (!ModelState.IsValid) return View(model);
            var role = await RoleManager.FindByIdAsync( model.Id );
            if (role == null) return View(model);
            role.Name = model.Name;
            var result = await RoleManager.UpdateAsync( role );
            if (result.Succeeded)
            {
                return RedirectToAction( "Index","Home" );
            }
            else
            {
                ModelState.AddModelError( "", "Something went wrong!" );
            }
            return View( model );
        }

        public async Task<ActionResult> Delete( string id )
        {
            var role = await RoleManager.FindByIdAsync( id );
            if (role != null)
            {
                var result = await RoleManager.DeleteAsync( role );
            }
            return RedirectToAction( "Index","Home" );
        }
    }
}