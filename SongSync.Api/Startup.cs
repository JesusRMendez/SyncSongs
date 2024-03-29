﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Configuration;
using System.Security.Claims;
using IdentityModel.Client;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(SongSync.Api.Startup))]

namespace SongSync.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = ConfigurationManager.AppSettings["Authority"],
                ClientId = ConfigurationManager.AppSettings["clientId"],
                ClientSecret = "secret",
                RequiredScopes = new string[] { "access_api" },
                ValidationMode = ValidationMode.ValidationEndpoint
            });
        }
    }
}
