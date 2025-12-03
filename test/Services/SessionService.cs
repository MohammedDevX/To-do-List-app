
using System.Text.Json;

namespace test.Services
{
    public class SessionService : ISessionService
    {
        public string Serialized(HttpContext sess, object ob)
        {
            return JsonSerializer.Serialize(ob);
        }
    }
}
