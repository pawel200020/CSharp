using System;

namespace Lab1
{
    public class Hero
    {
        string name;
        EHeroClass type;
        public Hero(String name, EHeroClass type)
        {
            this.name = name;
            this.type = type;
        }
        public void DisplayCharacter()
        {
            Console.WriteLine(type + " " + name + " is starting a new journey");
        }
        public string GetName()
        {
            return name;
        }
    }
}