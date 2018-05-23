using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CLINICAMVC.Models.AnnotationsHelpers
{
    public class PorxAuthorize: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var autorizado = base.AuthorizeCore(httpContext);
            if (!autorizado)
            {
                return false;
            }

            using (var context = ApplicationDbContext.Create())
            {
                var up = new UsuariosPorx(context);

                var usuario = up.BuscarUsuarioID(httpContext.User.Identity.GetUserId());
                if (usuario != null)
                {
                    return usuario.EstadoUsuario;
                }

                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }

    }
}