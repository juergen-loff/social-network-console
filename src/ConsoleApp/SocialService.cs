using ConsoleApp.Models;

namespace ConsoleApp;

public class SocialService
{
    private IEnumerable<User> _users = new List<User>();

    public void Handle(string input)
    {
        Console.WriteLine("Handled");
    }

    public void Post(string username, string message)
    {
        throw new NotImplementedException();
    }

    public void Timeline(string username, string secondUsername)
    {
        throw new NotImplementedException();
    }

    public void Follow(string username, string secondUsername)
    {
        throw new NotImplementedException();
    }

    public void Wall(string username)
    {
        throw new NotImplementedException();
    }

    public void SendMessage(string username, string secondUsername, string message)
    {
        throw new NotImplementedException();
    }

    public void ViewMessages(string username)
    {
        throw new NotImplementedException();
    }
}