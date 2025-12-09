
using System.Text.Json;

namespace test.Services
{
    public class SessionService : ISessionService
    {
        public void Add(string key, HttpContext sess, object ob)
        {
            sess.Session.SetString(key, JsonSerializer.Serialize(ob));
        }
    }
}
