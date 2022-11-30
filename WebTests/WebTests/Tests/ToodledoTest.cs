using System.Collections.Generic;
using System.Threading;
using WebTests.Bases;
using WebTests.Json;
using WebTests.Models;
using Xunit;

namespace WebTests.Tests;

[CollectionDefinition("Toodledo collection")]
public class ToodledoCollection : ICollectionFixture<ApplicationManager>
{
  
}

[Collection("Toodledo collection")]
public class ToodledoTest : AuthBase {

  public ToodledoTest(ApplicationManager manager) : base(manager)
  {
  }
  
  /*[Fact]
  public void ToodledoLogin() {
    
    ApplicationManager.Auth.Logout();
    
    ApplicationManager.Navigation.OpenLoginPage();
    var user = new AccountData("zhabkakisa@gmail.com", "Muffin21021");
    ApplicationManager.Auth.Login(user);
    
    Assert.True(ApplicationManager.Auth.IsDropDownMenuExists());
  }*/

  private static IEnumerable<TaskData> TaskDataFromJsonFile()
  {
     return JsonParser.ParseJson("tasks.json");
  }

  public static TheoryData<TaskData> TaskData
  {
    get
    {
      var data = new TheoryData<TaskData>();
      var tasks = TaskDataFromJsonFile();
      foreach (var task in tasks)
      {
        data.Add(task);
      }

      return data;
    }
  }

  [Theory]
  [MemberData(nameof(TaskData), MemberType = typeof(ToodledoTest))]
  public void AddTask(TaskData task) {

    Thread.Sleep(2000);

    //var guid = Guid.NewGuid();
    //var title = guid.ToString();
    //var task = new TaskData(title, "Add task test title description");
    
    ApplicationManager.Task.AddNewTask(task);
    
    Thread.Sleep(3000);

    var createdTask = ApplicationManager.Task.GetCreatedTaskTitle();
    
    Assert.Equal(task.Title, createdTask);
  }

  [Fact]
  public void UpdateTask()
  {
    const string newTitle = "A new text!!";
    ApplicationManager.Task.UpdateTask(newTitle);
    var updatedTaskTitle = ApplicationManager.Task.GetUpdatedTaskTitle();
    
    Assert.Equal(newTitle, updatedTaskTitle);
  }
}