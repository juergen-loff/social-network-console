using ConsoleApp.Models;

namespace ConsoleApp.Tests;

[TestFixture]
public class Tests
{

    private SocialService _socialService;

    [SetUp]
    public void Setup()
    {
        _socialService = new SocialService();
    }

    [Test]
    public void Post_NewUser_ShouldReturnTrueAndUserAddedAndMessageAdded()
    {
        // Arrange
        const string username = "Alice";
        const string message = "What a wonderfully sunny day!";

        // Act
        var action = _socialService.Post(username, message);

        // Assert
        var user = _socialService._users.Find(x => x.Name == username);
        Assert.Multiple(() =>
        {
            Assert.That(action, Is.True);
            Assert.That(user, Is.Not.Null);

            var timelineMessage = user!.Timeline.Find(x => x.Message == message);
            Assert.That(timelineMessage, Is.Not.Null);
        });
    }

    [Test]
    public void Mention_UserExists_ShouldReturnTrueAndTimelineMessageAdded()
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
        Assert.Multiple(() =>
        {
            Assert.That(action, Is.True);
            Assert.That(secondUser.Timeline, Has.Count.EqualTo(1));
        });
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
    public void Follow_UserExists_ShouldReturnTrueAndSubscriptionAdded()
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
        Assert.Multiple(() =>
        {
            Assert.That(action, Is.True);
            Assert.That(user.Subscriptions, Has.Count.EqualTo(1));
        });
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
    public void SendMessage_UserExists_ShouldReturnTrueAndPrivateMessageAdded()
    {
        // Arrange
        const string username = "Mallory";
        const string secondUsername = "Alice";
        const string message = "Hi there!";
        var user = new User(username);
        var secondUser = new User(secondUsername);
        _socialService._users.Add(user);
        _socialService._users.Add(secondUser);

        // Act
        var action = _socialService.SendMessage(username, secondUsername, message);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(action, Is.True);
            Assert.That(user.PrivateMessages, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void ViewMessages_TimelineNotEmpty_ShouldReturnTrue()
    {
        // Arrange
        const string username = "Mallory";
        var user = new User(username);
        _socialService._users.Add(user);

        // Act
        var action = _socialService.ViewMessages(username);

        // Assert
        Assert.That(action, Is.True);
    }
}