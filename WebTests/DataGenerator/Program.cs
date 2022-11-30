using DataGenerator;
using Newtonsoft.Json;
using WebTests.Models;

//cd C:\Users\user\Desktop\WebTests\DataGenerator\bin\Release\net6.0
// DataGenerator.exe task 3 tasks.json json
var dataType = args[0];
var count = Convert.ToInt32(args[1]);
var fileName = args[2];
var format = args[3];

if (dataType == "task")
{
    var tasks = TaskDataGenerator.GenerateTaskDataList(count);
    var writer = new StreamWriter(@"C:\Users\user\Desktop\WebTests\DataGenerator\GeneratedFiles\" 
                                  + fileName);

    switch (format)
    {
        case "json":
            WriteTasksToJsonFile(tasks, writer);
            break;
        default:
            Console.Write("Неизвестный формат: " + format);
            break;
    }

    writer.Close();
}
else
{
    Console.Write("Неизвестный тип: " + dataType);
}

void WriteTasksToJsonFile(List<TaskData> tasks, TextWriter writer)
{
    writer.Write(JsonConvert
        .SerializeObject(tasks, Formatting.Indented));
}