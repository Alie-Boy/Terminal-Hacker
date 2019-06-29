using UnityEngine;

public class Hacker : MonoBehaviour
{

    int Level;

    string password;
    string[] levelOnePasswords = { "books", "aisle", "shelf", "librarian", "password"};
    string[] levelTwoPasswords = { "armory", "medals", "commemorate", "hackernohacking" };

    enum Screen { MainMenu, Password, Result };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What database do you want to hack?");
        Terminal.WriteLine("Press 1 for Library.");
        Terminal.WriteLine("Press 2 for Police Station.");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
		else if (input == "quit" || input == "close" || input == "exit")
		{
			Application.Quit();
		}
		else if (input == "clear")
        {
            Terminal.ClearScreen();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            TestPasswordScreen(input);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your pass phrase (hint: \"" + password.Anagram() + "\"):");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            Level = 1;
            password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
            AskForPassword();
        }
        else if (input == "2")
        {
            Level = 2;
            password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("G'Night Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Invalid Level.");
        }
    }

    void TestPasswordScreen(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Try again. (hint: \"" + password.Anagram() + "\"):");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Result;
        Terminal.ClearScreen();
        ShowRewardScreen();
    }

    void ShowRewardScreen()
    {
        switch (Level)
        {
            case 1:
                Terminal.WriteLine("Here's a book!");
                Terminal.WriteLine(@"
    ________
   /       //
  /       // 
 /_______//	
(_______()
                "
                );
                break;
            case 2:
                Terminal.WriteLine("Here's a gun.");
                Terminal.WriteLine(@"
       __________________________,
   ___/  ////////  \____/        |
  <__ |_////////______________|
  /     /  ||   //
 /     /____\__//
/     /
\----/
"
				);
                break;
        }
		Terminal.WriteLine("You may type 'menu' any time again.");
    }
}
