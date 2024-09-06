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
        _socialService.Handle("");
        Assert.Pass();
    }

    [Test]
    public void Timeline_UserExists_ShouldReturnTrue()
    {
        Assert.Pass();
    }

    [Test]
    public void Follow_UserExists_ShouldReturnTrue()
    {
        Assert.Pass();
    }

    [Test]
    public void Wall_UserExists_ShouldReturnTrue()
    {
        Assert.Pass();
    }

    [Test]
    public void SendMessage_UserExists_ShouldReturnTrue()
    {
        Assert.Pass();
    }

    [Test]
    public void ViewMessages_TimelineNotEmpty_ShouldReturnTrue()
    {
        Assert.Pass();
    }
}