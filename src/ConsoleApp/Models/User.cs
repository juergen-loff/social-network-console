namespace ConsoleApp.Models;

public class User(string name, List<TimelineMessage> timelineMessages, Wall wall)
{
    public string Name { get; set; } = name;

    public List<TimelineMessage> Timeline { get; set; } = timelineMessages;

    public List<string> PrivateMessages { get; set; } = [];
}