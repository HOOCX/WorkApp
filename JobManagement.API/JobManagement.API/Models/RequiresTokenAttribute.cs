using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JobManagement.API.Models
{
    public class RequiresTokenAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Contains("xToken"))
            {
                var token = actionContext.Request.Headers.GetValues("xToken");

                if (String.IsNullOrEmpty(token.First()))
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
                    actionContext.Response.Content = new StringContent("El token no puede ser nulo, debe authenticarse");
                }

                else
                {
                    var service = new SecurityService();
                    var AuthWrapper = service.ParseAuthenticationToken(token.First());
                    var tokenValidation = AuthWrapper.ValidateToken();
                    if (tokenValidation.isValid)
                    {

                    }
                    else
                    {
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
                        actionContext.Response.Content = new StringContent("token vencido o token invalido, Vuelva iniciar sesion");
                    }
                }
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
                actionContext.Response.Content = new StringContent("El token no puede ser nulo, debe authenticarse");
            }




        }
    }
}