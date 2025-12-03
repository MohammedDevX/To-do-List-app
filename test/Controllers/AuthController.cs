using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace test.Controllers
{
    public class AuthController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Here we respectin the (L) principale, Liskove principal, the children class must call the 
            // mother functionality of the method, in c# we use keywoord (base) who ref (super) in java
            base.OnActionExecuting(context);

            // N.B : Here You are free to use context before HttpContext, because we extend from Controller class 
            // who contain the HttpContext attribut, but if you are using filters you must use context
            if (context.HttpContext.Session.GetString("user") == null)
            {
                // Il ya 3 methodes pour la redirection :

                // 1) Utiliser RedirectResult class : 
                // context.Result permet de faire la redirection à la place du controller
                // L'instanciation de le la class RedirectResult() permet de faire une redirection direct 
                // vers un url
                //context.Result = new RedirectResult("/login");

                // 2) Utiliser method Redirect() : 
                // Cette method permet de faire un redirection retarder, faire par le js, donc le seveur va 
                // executer la totalite du code controller est envoyer une response qui à une status code 301 
                //context.HttpContext.Response.Redirect("/login");

                // 3) Utiliser RedirectToActionResult : 
                // Faire le meme travaille que RedirectResult, mais ceci redige vers une action d'un controller 
                context.Result = new RedirectToActionResult("LoginForm", "User", null);
            }
        }
    }
}