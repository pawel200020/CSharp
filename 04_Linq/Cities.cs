using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Linq
{
    class Cities
    {
        Dictionary<int, string> ReadData()
        {
            var cities = new Dictionary<int, string>();
            Console.WriteLine("Enter cities, when finish press X key");
            string city;
            int i = 0;
            do
            {
                city = Console.ReadLine();
                if (city.Length > 1)
                {
                    cities.Add(i, city);
                    i++;
                }
            } while (city != "X");
            return cities;
        }
        IEnumerable<KeyValuePair<int, string>> SortData(Dictionary<int, string> data)
        {
           var groupByCities = (from city in data
                                group city by city.Value.First() into newGroup
                                orderby newGroup.Key
                                from cityInGroup in newGroup
                                select cityInGroup);
            return groupByCities;
        }
        IOrderedEnumerable<IGrouping<char, KeyValuePair<int, string>>> SortData2(Dictionary<int, string> cities)
        {
            return cities.GroupBy(city => city.Value.First()).OrderBy(b => b.Key);
        }
        void DisplayData(IOrderedEnumerable<IGrouping<char, KeyValuePair<int, string>>> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine("letter: " + item.Key);
                var sortgroup = from city in item orderby city.Value select city;
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.Value);
                }

            }
        }
        void MenuDisplayGroup(IOrderedEnumerable<IGrouping<char, KeyValuePair<int, string>>> data)
        {
            Console.WriteLine("Enter first letter of city group which you want to display, while finish put \"END\"");
            Console.WriteLine("Enter \"ALL\" to display full list");
            string command;
           
            while (true)
            {
                bool wasDisplayed = false;
                command = Console.ReadLine();
                if(command== "END") { break; }
                if (command == "ALL") { DisplayData(data); wasDisplayed = true; }
                foreach (var item in data)
                {
                    if (item.Key == command.First())
                    {
                        wasDisplayed = true;
                        Console.WriteLine("Group: " + item.Key);
                        foreach (var item2 in item)
                        {
                            Console.WriteLine(item2.Value);
                        }

                    }
                }
                if (!wasDisplayed)
                {
                    Console.WriteLine("Empty");
                }
            }
            
        }
        public void Run()
        {
            var cities = SortData2(ReadData());
            MenuDisplayGroup(cities);
        }
    }
}
