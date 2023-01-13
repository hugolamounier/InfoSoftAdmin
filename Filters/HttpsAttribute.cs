using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InfoSoftAdmin.Filters;

public class HttpsAttribute: RequireHttpsAttribute
{
    public bool RequireSecure = false;

    public override void OnAuthorization(AuthorizationFilterContext filterContext)
    {
        if (RequireSecure is false)
        {
            if (filterContext.HttpContext.Request.IsHttps && 
                (!filterContext.HttpContext.User.Identity?.IsAuthenticated ?? true))
                HandleNonHttpRequest(filterContext);
            
            return;
        }
        
        base.OnAuthorization(filterContext);
    }

    private void HandleNonHttpRequest(AuthorizationFilterContext filterContext)
    {
        var url = $"http://{filterContext.HttpContext.Request.Host}{filterContext.HttpContext.Request.Path}";
        filterContext.Result = new RedirectResult(url);
    }
}