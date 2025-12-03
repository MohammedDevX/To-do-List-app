using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace test.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (context.HttpContext.Session.GetString("user") == null)
            {
                context.Result = new RedirectResult("/");
                //context.HttpContext.Response.Redirect("/");
            }
        }
    }
}
