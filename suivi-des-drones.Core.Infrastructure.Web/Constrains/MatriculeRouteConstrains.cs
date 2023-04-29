using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Web.Constrains
{
    public class MatriculeRouteConstrains : IRouteConstraint
    {
        #region Public methods

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool isValid = false;
            string value = (string)values[routeKey];
            isValid=(value!=null)&&value.ToString().Length>5;
            return isValid;
        }
        #endregion
    }
}
