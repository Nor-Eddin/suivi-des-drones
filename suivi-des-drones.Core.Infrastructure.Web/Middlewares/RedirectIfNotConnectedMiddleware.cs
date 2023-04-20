using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Web.Middlewares
{
    public class RedirectIfNotConnectedMiddleware
    {
        #region Fields
        private readonly RequestDelegate next;
        #endregion
        #region Constructors
        public RedirectIfNotConnectedMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        #endregion
        #region Public methods
        public async Task InvokeAsync(HttpContext context)
        {
            var id = context.Session.GetString("UserId");
            var isLoginPage = context.Request.Path.Value?.ToLower().Contains("login");

            if (string.IsNullOrEmpty(id) && (!isLoginPage.HasValue || !isLoginPage.Value))
            {
                    context.Response.Redirect("/Login");
                    return;
            }

            await this.next.Invoke(context);
        }
        #endregion
    }

    public static class AuthenticationMiddleWares
    {
        #region Public methods
        public static IApplicationBuilder UseRedirectIfNotConnected(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<RedirectIfNotConnectedMiddleware>();
            
        }
        #endregion
    }
}
