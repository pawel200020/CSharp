using System;
using System.Collections.Generic;

namespace Lab1
{
    class Location
    {
        string locationName;
        public bool isUnlocked;
        List<NonPlayerCharacter> list;
        public Location(string locationName, bool isUnlocked)
        {
            list = new List<NonPlayerCharacter>();
            this.locationName = locationName;
            this.isUnlocked = isUnlocked;
        }
        public Location(string locationName, bool isUnlocked,NonPlayerCharacter c1, NonPlayerCharacter c2)
        {
            list = new List<NonPlayerCharacter>();
            this.locationName = locationName;
            this.isUnlocked = isUnlocked;
            list.Add(c1);
            list.Add(c2);
        }
        public void AddCharacter(NonPlayerCharacter character)
        {
            list.Add(character);
        }
        public List<NonPlayerCharacter> getCharacterList()
        {
            return list;
        }
        public string getName()
        {
            return locationName;
        }
        public Tuple<NonPlayerCharacter, int> StartNewLocation()
        {
            Console.WriteLine("You are in " + locationName + " what do you want to do?");
            int i = 1;
            foreach (var item in list)
            {
                Console.WriteLine("["+ i+ "] talk to "+ item.GetName());
                i++;
            }
            Console.WriteLine("[" + i + "] Travel");
            i++;
            Console.WriteLine("press " + i + " to go to main menu");
            int command = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (command <= i && command>0)
                {
                    break;
                }
                else
                {
                    MenuDialogs.WrongCommand();
                }
                command = Convert.ToInt32(Console.ReadLine());
            }
            if (command < i-1 && command > 0)
                return Tuple.Create(list[command - 1],-1);
            else if (command == i-1)
                return Tuple.Create(new NonPlayerCharacter(), 0);
            else
            {
                return Tuple.Create(new NonPlayerCharacter(), 1);
            }
        }
    }
}
