using ConsoleApp.Models;

namespace ConsoleApp;

public class SocialService
{
    public List<User> _users = [];

    public bool Handle(string input)
    {
        // 1. split input into list of strings
        var commandArray = input.Split(" ", 3).ToArray();

        var username = commandArray[0];
        var secondUsername = "";
        var command = commandArray[1];

        var result = false;

        switch (command)
        {
            case "/post":
                var message = commandArray[2];
                result = Post(username, message);
                break;
            case "/timeline":
                secondUsername = commandArray[2].Split(" ", 2)[0];
                result = Timeline(username, secondUsername);
                break;

            case "/follow":
                secondUsername = commandArray[2].Split(" ", 2)[0];
                result = Follow(username, secondUsername);
                break;

            case "/wall":
                result = Wall(username);
                break;

            case "/send_message":
                break;

            case "/view_messages":
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }

        // 3. call appropriate method

        //if success, return true, else false
        return result;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Commands");
        Console.WriteLine("\t/post - Usage: Alice /post What a wonderfully sunny day!");
        Console.WriteLine("\t/timeline - Usage: Bob /timeline Alice");
        Console.WriteLine("\t/follow - Usage: Charlie /follow Alice");
        Console.WriteLine("\t/wall - Usage: Charlie /wall");
    }

    private bool Post(string username, string msg)
    {
        // search list of users with the username
        var user = new User(" ");
        var secondUser = new User(" ");
        var mention = "";
        var message = "";

        if (msg.StartsWith('@'))
        {
            var messageArray = msg.Split(" ", 2).ToArray();
            mention = messageArray[0].Substring(1);
            Console.WriteLine(mention);
            message = messageArray[1];
            Console.WriteLine(message);
        }
        else
        {
            message = msg;
        }

        var timelineMessage = new TimelineMessage(DateTime.Now, message);

        if (_users.Any())
        {
            try
            {
                var result = _users.First(x => x.Name == username);
                user = result;
            }
            catch (Exception ex)
            {
                user.Name = username;
                _users.Add(user);
            }

            if (!string.IsNullOrWhiteSpace(mention))
            {
                try
                {
                    var result = _users.First(x => x.Name == username);
                    secondUser = result;
                }
                catch (Exception ex)
                {
                    secondUser.Name = username;
                    _users.Add(secondUser);
                }
            }
        }
        else
        {
            // if user does not exist, create user and add message
            user.Name = username;
            _users.Add(user);
        }

        if (!string.IsNullOrWhiteSpace(mention))
        {
            secondUser.Timeline.Add(timelineMessage);
        }
        else
        {
            user.Timeline.Add(timelineMessage);
        }

        var addedUser = _users.First(x => x.Name == username);
        addedUser.PrintTimelineMessages();

        return true;
    }

    private bool Timeline(string username, string secondUsername)
    {
        // search list of users with the username
        var user = new User(" ");
        var secondUser = new User(" ");

        if (_users.Any())
        {
            try
            {
                var result1 = _users.First(x => x.Name == username);
                user = result1;
            }
            catch (Exception ex)
            {
                user.Name = username;
                _users.Add(user);
            }

            try
            {
                var result2 = _users.First(x => x.Name == secondUsername);
                secondUser = result2;
            }
            catch (Exception ex)
            {
                secondUser.Name = secondUsername;
                _users.Add(secondUser);
            }
        }

        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(secondUser.Name)) return false;

        secondUser.PrintTimelineMessages();
        return true;
    }

    private bool Follow(string username, string secondUsername)
    {
      // search list of users with the username
        var user  = new User(" ");
        var secondUser = new User(" ");

        if (_users.Any())
        {
            try
            {
                var result1 = _users.First(x => x.Name == username);
                user = result1;
            }
            catch (Exception ex)
            {
                user.Name = username;
                _users.Add(user);
            }

            try
            {
                var result2 = _users.First(x => x.Name == secondUsername);
                secondUser = result2;
            }
            catch (Exception ex)
            {
                secondUser.Name = secondUsername;
                _users.Add(secondUser);
            }
        }

        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(secondUser.Name)) return false;

        // user subscribes to secondUser
        user.Subscriptions.Add(secondUser);
        user.PrintSubscriptions();
        return true;
    }

    private bool Wall(string username)
    {
        // search list of users with the username
        var user  = new User(" ");

        if (_users.Any())
        {
            try
            {
                var result = _users.First(x => x.Name == username);
                user = result;
            }
            catch (Exception ex)
            {
                user.Name = username;
                _users.Add(user);
            }
        }
        else
        {
            // if user does not exist, create user and add message
            user.Name = username;
            _users.Add(user);
        }

        if (string.IsNullOrWhiteSpace(user.Name)) return false;

        // user can view
        user.PrintSubscriptions();
        return true;
    }

    private bool SendMessage(string username, string secondUsername, string message)
    {
        return false;
    }

    private bool ViewMessages(string username)
    {
        return false;
    }
}