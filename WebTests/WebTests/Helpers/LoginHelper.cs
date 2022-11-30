using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using WebTests.Models;

namespace WebTests.Helpers;

public class LoginHelper : HelperBase
{
    public LoginHelper(ApplicationManager manager) : base(manager)
    {
    }

    public void Login(AccountData user)
    {
        if (IsLoggedIn())
        {
            if (IsLoggedIn(Settings.Email))
            {
                return;
            }
            
            Logout();
        }
        
        Driver.FindElement(By.Id("email")).SendKeys(user.Email); 
        Driver.FindElement(By.Id("pass")).Click(); 
        Driver.FindElement(By.Id("pass")).SendKeys(user.Password); 
        Driver.FindElement(By.CssSelector(".arw:nth-child(1)")).Click(); 
    }

    public void Logout()
    {
        if (!IsDropDownMenuExists()) return;
        Driver.FindElement(By.Id("tn_disclose")).Click();
        Thread.Sleep(3000);
        Driver.FindElement(By.CssSelector("input:nth-child(3)")).Click();
        Driver.FindElement(By.LinkText("Sign In")).Click();
    }

    public bool IsDropDownMenuExists()
    {
        return Driver.FindElements(By.CssSelector(".arw-dwn:nth-child(1)")).Any();
    }

    public bool IsLoggedIn()
    {
        var result = IsDropDownMenuExists();
        return result;
    }

    public bool IsLoggedIn(string email)
    {
        var userEmail = GetUserEmail();
        var result = IsLoggedIn() && userEmail.Contains(email);
        return result;
    }

    private string GetUserEmail()
    {
        Driver.FindElement(By.Id("tn_disclose")).Click();
        Thread.Sleep(3000);
        return Driver.FindElement(By.XPath("//li[@class='email']")).Text;
        //li[@class='email'][1]/a[1]/text()[1]
    }
}