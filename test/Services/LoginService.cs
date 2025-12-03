using Microsoft.VisualBasic;
using test.Models;

namespace test.Services
{
    public class LoginService
    {
        public bool Login(User user)
        {
            string rev = Strings.StrReverse(user.Login);
            if (user.Pass != rev)
            {
                return false;
            }
            return true;
        }
    }
}