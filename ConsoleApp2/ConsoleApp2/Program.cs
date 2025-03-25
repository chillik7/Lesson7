using System;
using System.IO;
public class ConfigurationException : Exception
{
    public ConfigurationException(string message, Exception innerException)
        : base(message, innerException) { }
}
public class ConfigLoader
{
    public void LoadConfig(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Файл конфигурации не найден.", path);
        }
        Console.WriteLine("Конфигурация успешно загружена.");
    }
}
public class ConfigurationManager
{
    private ConfigLoader _configLoader = new ConfigLoader();
    public void LoadConfiguration(string path)
    {
        try
        {
            _configLoader.LoadConfig(path);
        }
        catch (FileNotFoundException ex)
        {
            throw new ConfigurationException("Ошибка загрузки конфигурации.", ex);
        }
    }
}
class Program
{
    static void Main()
    {
        ConfigurationManager configManager = new ConfigurationManager();
        string filePath = "config.json"; // Файл, которого нет

        try
        {
            configManager.LoadConfiguration(filePath);
        }
        catch (ConfigurationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
            Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        }
    }
}

