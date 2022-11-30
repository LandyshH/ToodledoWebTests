namespace WebTests.Models;

public class TaskData
{
    public TaskData(){}
    public TaskData(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
}