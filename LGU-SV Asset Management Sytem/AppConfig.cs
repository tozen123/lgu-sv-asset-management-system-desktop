using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public class AppConfig
{
    public string connectionString { get; set; }
    public static AppConfig LoadConfig(string filePath)
    {
        var config = new AppConfig();
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('~');
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();

                    switch (key)
                    {
                        case "connection_string":
                            config.connectionString = value;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
          
        }

        return config;
    }

}