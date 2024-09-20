using ConsoleApp.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConsoleApp.Tests;

public class Tests
{

    private SocialService _socialService;

    [SetUp]
    public void Setup()
    {
        _socialService = new SocialService();
    }

    [Test]
    public void Post_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Alice";
        const string message = "What a wonderfully sunny day!";

        // Act
        var action = _socialService.Post(username, message);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void Mention_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Bob";
        const string message = "@Charlie what are your plans tonight?";
        var user = new User(username);
        var secondUser = new User("Charlie");
        _socialService._users.Add(user);
        _socialService._users.Add(secondUser);

        // Act
        var action = _socialService.Post(username, message);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void Timeline_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Bob";
        const string secondUsername = "Alice";
        var user = new User("Bob");
        var secondUser = new User("Alice");
        _socialService._users.Add(user);
        _socialService._users.Add(secondUser);

        // Act
        var action = _socialService.Timeline(username, secondUsername);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void Follow_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Charlie";
        const string secondUsername = "Alice";
        var user = new User("Charlie");
        var secondUser = new User("Alice");
        _socialService._users.Add(user);
        _socialService._users.Add(secondUser);

        // Act
        var action = _socialService.Follow(username, secondUsername);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void Wall_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Charlie";
        var user = new User("Charlie");
        _socialService._users.Add(user);

        // Act
        var action = _socialService.Wall(username);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void SendMessage_UserExists_ShouldReturnTrue()
    {
        // Arrange
        const string command = "Mallory /send_message Alice";

        // Act
        var action = _socialService.Handle(command);

        // Assert
        Assert.That(action, Is.True);
    }

    [Test]
    public void ViewMessages_TimelineNotEmpty_ShouldReturnTrue()
    {
        // Arrange
        const string command = "Alice /view_messages";

        // Act
        var action = _socialService.Handle(command);

        // Assert
        Assert.That(action, Is.True);
    }
}