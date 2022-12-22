using WebTests.Bases;
using WebTests.Models;
using Xunit;

namespace WebTests.Tests;


[Collection("Toodledo collection")]
public class AuthTests : TestBase
{
    [Fact]
    public void LoginWithValidData()
    {
        ApplicationManager.Navigation.OpenLoginPage();
        
        ApplicationManager.Auth.Logout();
        
        var user = new AccountData( Settings.Email,  Settings.Password);
        ApplicationManager.Auth.Login(user);
    
        Assert.True(ApplicationManager.Auth.IsDropDownMenuExists());
    }

    [Fact]
    public void LoginWithInvalidData()
    {
        ApplicationManager.Navigation.OpenLoginPage();
        
        ApplicationManager.Auth.Logout();
        
        var user = new AccountData("yijgf@gmail.com", "wphjkhg");
        ApplicationManager.Auth.Login(user);
    
        Assert.False(ApplicationManager.Auth.IsDropDownMenuExists());
    }

    public AuthTests(ApplicationManager manager) : base(manager)
    {
    }
}
