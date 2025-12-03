using test.Models;
using test.ViewModels;

namespace test.Mappage
{
    public class TodoM
    {
        public static Todo TransformTodoVMToTodo(TodoVM todo)
        {
            Todo todom = new Todo();
            todom.Libelle = todo.Libelle;
            todom.Description = todo.Description;
            todom.State = todo.State;
            todom.DateLimite = todo.DateLimite;
            return todom;
        }
    }
}
