namespace ConsoleApp.Models;

public class TimelineMessage(DateTime timestamp, string message)
{
    public DateTime Timestamp { get; set; } = timestamp;
    public string Message { get; set; } = message;
}