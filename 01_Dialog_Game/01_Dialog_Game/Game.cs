using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab1
{
    
    class Game
    {
        List<Location> locations;
        void TalkTo(NonPlayerCharacter npc, DialogParser parser)
        {
            if (npc.GetName() == "Akara")
            {

                Akara.TalkToAkara(npc, parser);
            }
            else if (npc.GetName() == "Pesa")
            {
                Pesa.TalkToPesa(npc, parser);
            }
            else
            {
                throw new Exception("Not implemented character");
            }
        }
        List<Location> AddLocations()
        {
            var locations = new List<Location>();
            Location location1 = new Location("Hogwart", true, new NonPlayerCharacter("Akara", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Pesa", "Do you want to buy some new stuff?"));
            Location location2 = new Location("Kraków", true, new NonPlayerCharacter("Maslo", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Skoda", "Do you want to buy some new stuff?"));
            Location location3 = new Location("Bayview", true, new NonPlayerCharacter("John", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Maulchy", "Do you want to buy some new stuff?"));
            Location location4 = new Location("London", true, new NonPlayerCharacter("Ada", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Turing", "Do you want to buy some new stuff?"));
            Location location5 = new Location("Starter", false, new NonPlayerCharacter("Ender", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Gigabyte", "Do you want to buy some new stuff?"));
            Location location6 = new Location("Gdańsk", false, new NonPlayerCharacter("Ender", "Hello can you help me to get to a different city"), new NonPlayerCharacter("Gigabyte", "Do you want to buy some new stuff?"));
            locations.Add(location1);
            locations.Add(location2);
            locations.Add(location3);
            locations.Add(location4);
            locations.Add(location5);
            locations.Add(location6);
            return locations;

        }
        int GetIdLocation(string name)
        {
            int i = 0;
            foreach (var item in locations)
            {
                if (item.getName() == name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        void PlaySpecificGame(Hero hero, string currLocation)
        {
            var locationID = GetIdLocation(currLocation);
            Tuple<NonPlayerCharacter, int> result = locations[locationID].StartNewLocation();
            if (result.Item2 == 1)
            {
                return;
            }
            if (result.Item2 == 0)
            {
                
                int i = 1;
                var filtered = locations.Where(a => !(a.getName().Equals(currLocation))).Where(a=>a.isUnlocked).OrderBy(a=>a.getName());
                foreach (var item in filtered)
                {
                    Console.WriteLine("[" + i + "] " + item.getName());
                    i++;
                }
                Console.WriteLine("press "+ (i) +" to go to previous location.");
                int command = Convert.ToInt32(Console.ReadLine());
                if (command < i)
                {
                    PlaySpecificGame(hero, filtered.ElementAt(command - 1).getName());
                }
                else
                {
                    PlaySpecificGame(hero, currLocation);
                }
                
            }
            else
            {
                DialogParser parser = new DialogParser(hero);
                TalkTo(result.Item1, parser);
                PlaySpecificGame(hero, currLocation);
            }
            Console.Clear();

        }
        void Play()
        {
            string characterNameAfterCleanup = "";
            string characterName = "";
            EHeroClass heroType;
            Hero heroClass;
            MenuDialogs.ShowNewGameScreen();
            characterNameAfterCleanup = Console.ReadLine();
            while (true)
            {
                if (StringOperations.ValidateString(characterNameAfterCleanup))
                {
                    characterName = StringOperations.removeWhiteChars(characterNameAfterCleanup);
                    MenuDialogs.AskForCharacterType(characterName);
                    heroType = MenuDialogs.SelectHeroType();
                    heroClass = new Hero(characterName, heroType);
                    heroClass.DisplayCharacter();
                    locations = AddLocations();
                    PlaySpecificGame(heroClass, locations[0].getName());
                    MenuDialogs.PressAnyKey();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    MenuDialogs.WrongCharacter();
                    characterNameAfterCleanup = Console.ReadLine();
                }
            }

        }
        public void Run()
        {
            string command = "";
            while (true)
            {
                Console.Clear();
                MenuDialogs.ShowWelcomeScreen();
                command = Console.ReadLine();
                MenuDialogs.NewLine();
                switch (command)
                {
                    case "1":
                        Play();
                        break;
                    case "X":
                        MenuDialogs.EndGame();
                        return;
                    default:
                        MenuDialogs.ReselectCharacter();
                        break;
                }
            }
        }
    }
}
