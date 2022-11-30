using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WebTests.Models;

namespace WebTests.Json;

public static class JsonParser
{
    public static List<TaskData> ParseJson(string fileName)
    {
        using StreamReader reader = new StreamReader(@"C:\Users\user\Desktop\WebTests\DataGenerator\GeneratedFiles\" + fileName);
        var json = reader.ReadToEnd();
        var tasks = JsonConvert.DeserializeObject<List<TaskData>>(json);
        return tasks ?? throw new NullReferenceException();
    }
}