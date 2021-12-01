using System;

namespace Lab1
{
    static class MenuDialogs
    {
        public static void ShowWelcomeScreen()
        {
            Console.WriteLine("Welcome in game <C# init app> \n"
                + "[1] Launch a new game\n" + "[X] End Game \n");
        }
        public static void ShowNewGameScreen()
        {
            Console.Clear();
            Console.WriteLine("New game has been selected");
            Console.WriteLine("Please enter a character name");
        }
        public static void AskForCharacterType(String characterName)
        {
            Console.WriteLine("Hi, " + characterName + " please select character type \n" +
                        "[i] barbarian\n" +
                        "[ii] paladin\n" +
                        "[iii] amazon");
        }
        public static EHeroClass SelectHeroType()
        {
            while (true)
            {
                String typeString = Console.ReadLine();
                if (typeString == "i")
                {
                    return (EHeroClass)0;
                }
                if (typeString == "ii")
                {
                    return (EHeroClass)1;
                }
                if (typeString == "iii")
                {
                    return (EHeroClass)2;
                }
                else
                {
                    Console.WriteLine("please try again");
                }
            }
        }
        public static void EndGame()
        {
            Console.WriteLine("This is the end of a game");
        }
        public static void ReselectCharacter()
        {
            Console.WriteLine("wrong command, please try again!");
        }
        public static void WrongCharacter()
        {
            Console.WriteLine("Wrong character name, please try again");
        }
        public static void NewLine()
        {
            Console.WriteLine("");
        }
        public static void WrongCommand()
        {
            Console.WriteLine("Wrong command number, please try again!");
        }
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continiue");
        }
    }
}