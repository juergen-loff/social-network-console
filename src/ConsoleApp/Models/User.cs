namespace ConsoleApp.Models;

public class User(string name)
{
    public string Name { get; set; } = name;

    public List<TimelineMessage> Timeline { get; set; } = [];

    public List<PrivateMessage> PrivateMessages { get; set; } = [];

    public List<User> Subscriptions { get; set; } = [];

    public void PrintTimelineMessages()
    {
        Console.Clear();
        Console.WriteLine($"Timeline for {Name}\n================================================");
        foreach (var message in Timeline)
        {
            Console.WriteLine($"\nDate: {message.Timestamp}\nMessage: {message.Message}\n");
            Console.WriteLine("================================================\n");
        }
    }

    public void PrintSubscriptions()
    {
        Console.Clear();
        Console.WriteLine($"Subscriptions for {Name}\n================================================");
        foreach (var user in Subscriptions)
        {
            Console.WriteLine($"\nName: {user.Name}\n");
            Console.WriteLine("================================================\n");
        }
    }

    public void PrintPrivateMessages()
    {
        Console.Clear();
        Console.WriteLine($"Messages for {Name}\n================================================");
        foreach (var message in PrivateMessages)
        {
            Console.WriteLine($"\nSender: {message.Sender.Name}\n");
            Console.WriteLine($"\nRecipient: {message.Recipient.Name}\n");
            Console.WriteLine($"\nTimestamp: {message.Timestamp}\n");
            Console.WriteLine("================================================\n");
            Console.WriteLine($"{message.Message}");
            Console.WriteLine("================================================\n");
        }
    }
}