using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using test.Mappage;
using test.Models;
using test.Services;
using test.ViewModels;

namespace test.Controllers
{
    [LogsFilter]
    public class UserController : Controller
    {
        private LoginService login;
        private ISessionService sess;
        public UserController(LoginService login, ISessionService sess)
        {
            this.login = login;
            this.sess = sess;
        }

        [HttpGet]
        //[Route("login")]
        public IActionResult LoginForm()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                return RedirectToAction(nameof(Show));
            }
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(LoginForm));
            }

            User userM = UserM.GetDataFromUserVM(user);
            bool isT = login.Login(userM);
            if (isT == false)
            {
                return View(nameof(LoginForm));
            }
            sess.Add("user", HttpContext, userM);
            return RedirectToAction(nameof(Show));
        }

        [Route("show")]
        public IActionResult Show()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            ViewBag.user = user;
            return View();
        }

        [Route("logout")]
        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(LoginForm));
        }
    }
}
