﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Auth0HackBackend.Controllers
{
    // Controllers/ScopeAuthorizeAttribute.cs

    public class ScopeAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string scope;
        public IConfiguration Configuration { get; }
        public ScopeAuthorizeAttribute(string scope)
        {
            this.scope = scope;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            // Get the Auth0 domain, in order to validate the issuer
            var domain = $"https://agentender.auth0.com/";

            // Get the claim principal
            ClaimsPrincipal principal = actionContext.ControllerContext.RequestContext.Principal as ClaimsPrincipal;

            // Get the scope clain. Ensure that the issuer is for the correcr Auth0 domain
            var scopeClaim = principal?.Claims.FirstOrDefault(c => c.Type == "scope" && c.Issuer == domain);
            if (scopeClaim != null)
            {
                // Split scopes
                var scopes = scopeClaim.Value.Split(' ');

                // Succeed if the scope array contains the required scope
                if (scopes.Any(s => s == scope))
                    return;
            }

            HandleUnauthorizedRequest(actionContext);
        }
    }
}
