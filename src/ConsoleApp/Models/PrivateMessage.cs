namespace ConsoleApp.Models;

public class PrivateMessage
{
    public User Sender { get; set; }
    public User Recipient { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public MessageTypes MessageType { get; set; }
}

public enum MessageTypes
{
    Received,
    Sent
}