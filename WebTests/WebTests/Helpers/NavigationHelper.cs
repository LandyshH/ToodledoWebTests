using OpenQA.Selenium;

namespace WebTests.Helpers;

public class NavigationHelper : HelperBase
{
    private readonly string _baseUrl;
    
    public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
    {
        _baseUrl = baseUrl;
    }

    public void OpenLoginPage()
    {
        OpenPage(_baseUrl + "/signin.php");
    }

    private void OpenPage(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }
}