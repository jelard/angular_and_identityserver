using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApiWithAngular.Startup))]
namespace WebApiWithAngular
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44300/identity",
                RequiredScopes = new[] { "gallerymanagement" }
            });

            // web api configuration
            var config = WebApiConfig.Register();

            app.UseWebApi(config);

        }

    }
}