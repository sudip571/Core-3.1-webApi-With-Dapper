using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.API.FilterAttribute
{
    public class CustomAuthorizeFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                string controllerName = controllerActionDescriptor?.ControllerName;
                string actionName = controllerActionDescriptor?.ActionName;
                //to return unauthorized
                //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //context.Result = new JsonResult(new { message="Unauthorized"});

            }

        }
    }
}
