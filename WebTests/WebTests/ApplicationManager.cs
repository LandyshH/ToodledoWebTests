using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using WebTests.Helpers;

namespace WebTests;

public class ApplicationManager : IDisposable
{
    public ApplicationManager()
    {
        Driver = new ChromeDriver();
        
        Navigation = new NavigationHelper(this, "https://www.toodledo.com");
        Auth = new LoginHelper(this);
        Task = new TaskHelper(this);
    }
    
    private static ThreadLocal<ApplicationManager> _app = new();

    public IWebDriver Driver { get; }

    public NavigationHelper Navigation{ get; }
    public LoginHelper Auth{ get; }
    public TaskHelper Task{ get; }
    
    
    public void Dispose()
    {
        Driver.Quit();
    }

    /*public static ApplicationManager GetInstance()
    {
        if (!_app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.OpenLoginPage();
            _app.Value = newInstance;
        }
        return _app.Value;
    }*/

    /*public void Stop()
     {
         Driver.Quit();
     }*/
    
    /*~ApplicationManager()
    {
        try
        {
            Driver.Quit();
        }
        catch (Exception)
        {
            throw new Exception("Не удалось вызвать деструктор");
        }
    }*/
}