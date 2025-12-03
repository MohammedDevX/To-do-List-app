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

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todo"));
            todos.RemoveAt(id-1);
            string json = session.Serialized(HttpContext, todos);
            HttpContext.Session.SetString("todo", json);
            return RedirectToAction(nameof(Show));
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todo"));
            Todo todo = todos[id - 1];
            ViewBag.id = id;
            ViewBag.todo = todo;
            return View();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(int id, TodoVM todo)
        {
            Todo todoM = TodoM.TransformTodoVMToTodo(todo);
            List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todo"));
            todos[id - 1].Libelle = todoM.Libelle;
            todos[id - 1].Description = todoM.Description;
            todos[id - 1].State = todoM.State;
            todos[id - 1].DateLimite = todoM.DateLimite;
            string json = session.Serialized(HttpContext, todos);
            HttpContext.Session.SetString("todo", json);
            return RedirectToAction(nameof(Show));
        }
    }
}
