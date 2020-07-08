using UnityEngine;

public class Hacker : MonoBehaviour
{
    //init variables for class
    int level;
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    string password;

    enum Screen { MainMenu, Password, Win }  //3 states of the screen
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
    }

    void showMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("BruteForce.exe is running..............");
        Terminal.WriteLine("Hello \nWhere shall we venture today?");
        Terminal.WriteLine("1) Radio Station \nFirewall level : weak");
        Terminal.WriteLine("2) College server \nFirewall level : medium");
        Terminal.WriteLine("3) Big data Corporation \nFirewall level : Strong");
        Terminal.WriteLine("Hack The World My Friend.");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") //so that we can always go direct to main menu
        {
            showMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Goodbye.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)      
        {
            runMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    void runMainMenu(string input)      //select level 
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            startGame();
        }
        else
        {
            Terminal.WriteLine("Error : invalid input");
        }
    }

    void startGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        setRandomPassword();
        Terminal.WriteLine("Logging in to servers....... \nConnection Established. \nPlease enter the password: \n(hint :" + password.Anagram() + ")");
        Terminal.WriteLine("type menu to return to main menu or quit to leave the game");
    }

    void setRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("error : invalid input");
                break;
        }
    }

    public void checkPassword(string input)
    {
        if (input == password)
        {
            winScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }

    public void winScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Congratulations, You can hack the world now.  \ntype menu to return to main menu or quit to quit the game");
    }

    /*
    public string ScrambleWord(string word)
    {
        StringBuilder jumbleSB = new StringBuilder();
        Random rand = new Random();
        jumbleSB.Append(theWord);
        int lengthSB = jumbleSB.Length;
        for (int i = 0; i < lengthSB; ++i)
        {
            int index1 = (rand.Next() % lengthSB);
            int index2 = (rand.Next() % lengthSB);

            Char temp = jumbleSB[index1];
            jumbleSB[index1] = jumbleSB[index2];
            jumbleSB[index2] = temp;

        }
    }*/
}


