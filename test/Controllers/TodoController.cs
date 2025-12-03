using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using test.Filters;
using test.Mappage;
using test.Models;
using test.Services;
using test.ViewModels;

namespace test.Controllers
{
    // If you use filters, you must use annotation [name of the class filter]
    [AuthFilter]
    public class TodoController : Controller // or using AuthController
    {
        private ISessionService session;
        public TodoController(ISessionService session)
        {
            this.session = session;
        }

        [HttpGet]
        [Route("todo")]
        public IActionResult TodoForm()
        {
            return View();
        }

        [HttpPost]
        [Route("todo")]
        public IActionResult Todo(TodoVM todo)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(TodoForm));
            }

            Todo todoM = TodoM.TransformTodoVMToTodo(todo);
            List<Todo> todos;

            todos = HttpContext.Session.GetString("todo") == null ? new List<Todo>()
                    : JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todo"));

            todos.Add(todoM);

            string json = session.Serialized(HttpContext, todos);
            HttpContext.Session.SetString("todo", json);
            return RedirectToAction(nameof(Show));
        }

        [Route("todo.show")]
        public IActionResult Show()
        {
            if (HttpContext.Session.GetString("todo") == null)
            {
                ViewBag.message = "Aucune todo existe pour l'instant";
            } else
            {
                List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todo"));
                ViewBag.todos = todos;
            }
            return View();
        }
    }
}
