using WebTests.Models;

namespace DataGenerator;

public static class TaskDataGenerator
{
    public static List<TaskData> GenerateTaskDataList(int count)
    {
        var tasks = new List<TaskData>();
        for (var i = 0; i < count; i++)
        {
            var title = GenerateRandomString(10);
            var description = GenerateRandomString(20);
            tasks.Add(new TaskData(title, description));
        }
        
        return tasks;
    }

    private static string GenerateRandomString(int size)
    {
        var random = new Random();
        var str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var res = "";
  
        for (var i = 0; i < size; i++)
        {
            var x = random.Next(str.Length);
            res += str[x];
        }

        return res;
    }
}