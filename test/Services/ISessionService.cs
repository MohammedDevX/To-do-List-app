namespace test.Services
{
    public interface ISessionService
    {
        public string Serialized(HttpContext sess, object ob);
    }
}
