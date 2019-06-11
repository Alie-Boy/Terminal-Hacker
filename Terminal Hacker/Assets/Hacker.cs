using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    int Level;

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
        else if (input == "1" || input == "2")
        {
            if (input == "1") Level = 1;
            if (input == "2") Level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("G'Night Mr. Bond.");
        }
        else if (input == "clear")
        {
            Terminal.ClearScreen();
        }
        else
        {
            Terminal.WriteLine("Invalid Level.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen Level " + Level);
        Terminal.WriteLine("Please enter your pass phrase:");
    }
}
