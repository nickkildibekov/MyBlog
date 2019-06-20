using System;
using Common.App_Data;
using Common.Models;
using Common.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebSite;

[assembly: OwinStartup( typeof( Startup ) )]

namespace WebSite
{
    public class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            // setup context and manager
            app.CreatePerOwinContext<BlogContext>( BlogContext.Create );
            app.CreatePerOwinContext<ApplicationUserManager>( ApplicationUserManager.Create );

            // RoleManager registration
            app.CreatePerOwinContext<ApplicationRoleManager>( ApplicationRoleManager.Create );

            app.UseCookieAuthentication( new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(30),
                LoginPath = new PathString( "/Account/Login" ),
            } );
        }
    }
}