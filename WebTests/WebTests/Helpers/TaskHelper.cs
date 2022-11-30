using System.Threading;
using OpenQA.Selenium;
using WebTests.Models;

namespace WebTests.Helpers;

public class TaskHelper : HelperBase
{
    public TaskHelper(ApplicationManager manager) : base(manager)
    {
    }
    
    public void AddNewTask(TaskData task)
    {
        Driver.FindElement(By.CssSelector("#nav_add > span")).Click();
        Thread.Sleep(3000);
        Driver.FindElement(By.Id("firstTitle")).Click();
        Driver.FindElement(By.Id("firstTitle")).SendKeys(task.Title);
        Driver.FindElement(By.CssSelector(".editNote")).Click();
        Driver.FindElement(By.CssSelector(".editNote")).SendKeys(task.Description);
        Thread.Sleep(3000);
        Driver.FindElement(By.CssSelector(".btn")).Click();
    }

    public void UpdateTask(string newTitle)
    {
        Thread.Sleep(3000);
        
        Driver.FindElement(By.XPath("//div[@id='375196649']/div[2]")).Click();
        
        Thread.Sleep(1000);

        Driver.FindElement(By.CssSelector(".cellText")).SendKeys(Keys.Control + "a" + Keys.Delete);
        Driver.FindElement(By.CssSelector(".cellText")).SendKeys(newTitle);
        Driver.FindElement(By.CssSelector(".cellText")).SendKeys(Keys.Enter);
    }

    public string GetUpdatedTaskTitle()
    {
        return Driver.FindElement(By.XPath("//div[@id='375196649']/div[2]")).Text;
    }
    
    public string GetCreatedTaskTitle()
    {
        var taskTitle= Driver.FindElement(By.XPath("//div[@id='TasksContainer']/div[1]/span/div/div[2]")).Text;
        return taskTitle;
    }
}
