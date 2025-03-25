using System;
public class TemperatureOutOfRangeException : Exception
{
    public TemperatureOutOfRangeException(string message) : base(message) { }
}
public class TemperatureSensor
{
    private int _temperature;

    public void SetTemperature(int temp)
    {
        if (temp < -50 || temp > 50)
        {
            throw new TemperatureOutOfRangeException($"Ошибка: Температура {temp}°C выходит за допустимый диапазон (-50 до 50).");
        }

        _temperature = temp;
        Console.WriteLine($"Температура установлена: {_temperature}°C");
    }
}
class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();

        try
        {
            sensor.SetTemperature(60); 
        }
        catch (TemperatureOutOfRangeException ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
        }

        try
        {
            sensor.SetTemperature(20); 
        }
        catch (TemperatureOutOfRangeException ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
        }
    }
}

