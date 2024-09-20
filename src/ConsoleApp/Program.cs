// See https://aka.ms/new-console-template for more information

using ConsoleApp;

Setup.DisplayWelcomeMessage();
Console.WriteLine("Welcome to the social network!");

var socialService = new SocialService();

string? userInput;
do
{
    SocialService.DisplayMenu();
    userInput = Console.ReadLine();

    if(!string.IsNullOrWhiteSpace(userInput) && !string.Equals(userInput, "exit"))
        socialService.Handle(userInput);

} while (!string.Equals(userInput, "exit"));