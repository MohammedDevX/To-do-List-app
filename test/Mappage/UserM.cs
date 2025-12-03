using test.Models;
using test.ViewModels;

namespace test.Mappage
{
    public class UserM
    {
        public static User GetDataFromUserVM(UserVM userVM) 
        {
            User user = new User();
            user.Login = userVM.Login;
            user.Pass = userVM.Pass;
            return user;
        }
    }
}
