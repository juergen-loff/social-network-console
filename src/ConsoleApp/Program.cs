// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using Spectre.Console;

Console.ForegroundColor = ConsoleColor.White;

Setup.DisplayWelcomeMessage();
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("Welcome to the social network!");
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = (ConsoleColor)(-1);

var socialService = new SocialService();

string? userInput;
do
{
    SocialService.DisplayMenu();
    userInput = Console.ReadLine();

    if(!string.IsNullOrWhiteSpace(userInput) && !string.Equals(userInput, "exit"))
        socialService.Handle(userInput);

} while (!string.Equals(userInput, "exit"));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Thank you for using the social network!");