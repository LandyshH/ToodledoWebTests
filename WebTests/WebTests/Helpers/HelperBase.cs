using OpenQA.Selenium;

namespace WebTests.Helpers;

public class HelperBase
{
    protected readonly ApplicationManager Manager;
    protected readonly IWebDriver Driver;

    protected HelperBase(ApplicationManager manager)
    {
        Manager = manager;
        Driver = manager.Driver;
    }
}