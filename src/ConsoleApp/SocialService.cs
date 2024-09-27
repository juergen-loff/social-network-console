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
                secondUsername = commandArray[2].Split(" ", 2)[0];
                message = commandArray[2].Split(" ", 2)[1];
                result = SendMessage(username, secondUsername, message);
                break;

            case "/view_messages":
                result = ViewMessages(username);
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }

        // 3. call appropriate method

        //if success, return true, else false
        return result;
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("Commands:");
        Console.WriteLine("\t/post - Usage: Alice /post What a wonderfully sunny day!");
        Console.WriteLine("\t\tMention a user: Bob /post @Charlie what are your plans tonight?");
        Console.WriteLine("\t/timeline - Usage: Bob /timeline Alice");
        Console.WriteLine("\t/follow - Usage: Charlie /follow Alice");
        Console.WriteLine("\t/wall - Usage: Charlie /wall");
        Console.WriteLine("\t/send_message - Usage: Mallory /send_message Alice Hi There?");
        Console.WriteLine("\t/view_messages - Usage: Alice /view_messages");
        Console.WriteLine("\texit - Quit the application");
        Console.WriteLine("*********************************************************************");
    }

    public bool Post(string username, string msg)
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
            secondUser.Name = mention;

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
                    var result = _users.First(x => x.Name == secondUser.Name);
                    secondUser = result;
                }
                catch (Exception ex)
                {
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

        Console.WriteLine(mention);
        if (!string.IsNullOrWhiteSpace(mention))
        {
            secondUser.Timeline.Add(timelineMessage);
            secondUser.PrintTimelineMessages();
        }
        else
        {
            user.Timeline.Add(timelineMessage);
            user.PrintTimelineMessages();
        }

        return true;
    }

    public bool Timeline(string username, string secondUsername)
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

    public bool Follow(string username, string secondUsername)
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

    public bool Wall(string username)
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

    public bool SendMessage(string username, string secondUsername, string message)
    {
        // search list of users with the username
        User user;
        User secondUser;

        if (_users.Any())
        {
            try
            {
                var result = _users.First(x => x.Name == username);
                user = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: User does not exist");
                return false;
            }

            try
            {
                var result = _users.First(x => x.Name == secondUsername);
                secondUser = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: User does not exist");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Please post a message to create an account");
            return false;
        }

        var privateMessage = new PrivateMessage
        {
            Sender = user,
            Recipient = secondUser,
            Message = message,
            Timestamp = DateTime.Now,
            MessageType = MessageTypes.Sent
        };

        user.PrivateMessages.Add(privateMessage);

        privateMessage.MessageType = MessageTypes.Received;
        secondUser.PrivateMessages.Add(privateMessage);

        return true;
    }

    public bool ViewMessages(string username)
    {
        // search list of users with the username
        var user = new User(" ");

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
        }

        if (string.IsNullOrWhiteSpace(user.Name)) return false;

        user.PrintPrivateMessages();

        return true;
    }
}