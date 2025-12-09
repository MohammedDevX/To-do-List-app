namespace test.Services
{
    public interface ISessionService
    {
        public void Add(string key, HttpContext sess, object ob);
    }
}
