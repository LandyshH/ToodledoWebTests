using WebTests.Models;

namespace WebTests.Bases;

public class AuthBase : TestBase
{
    public AuthBase(ApplicationManager manager) : base(manager)
    {
        if (ApplicationManager.Auth.IsLoggedIn())
        {
            if (ApplicationManager.Auth.IsLoggedIn(Settings.Email))
            {
                return;
            }
            
            ApplicationManager.Auth.Logout();
        }
        
        ApplicationManager.Navigation.OpenLoginPage();
        var user = new AccountData(Settings.Email, Settings.Password);
        ApplicationManager.Auth.Login(user);
    }
}