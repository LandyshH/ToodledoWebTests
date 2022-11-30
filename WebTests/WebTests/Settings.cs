using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;

namespace WebTests;

public class Settings
{
    public static string BaseUrl { get; }

    public static string Email { get; }

    public static string Password { get; }

    static Settings()
    {
        const string file = @"C:\Users\user\Desktop\WebTests\WebTests\settings.json";
        
        if (!File.Exists(file))
        {
            throw new Exception("Problem: settings file not found: " + file);
        }

        var json = File.ReadAllText(file);
        var settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) 
                       ?? throw new Exception("No settings");

        BaseUrl = settings[nameof(BaseUrl)];
        Email = settings[nameof(Email)];
        Password = settings[nameof(Password)];
    }

}