using System;

namespace BeerProcessor
{
    public class BeerOrder : Common.IOrder
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("Name cannot be null");
                else
                    _title = value;
            }
        }
        private void DisplayWithPause(String phrase)
        {
            Console.WriteLine(phrase);
            System.Threading.Thread.Sleep(2000);
        }
        public void Process()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Code\UJ\CSharp2\08_Reflection\BeerProcessor\bin\Debug\net5.0\recipe.txt");

            Console.WriteLine("Title: {0}", _title);
            
            foreach (string line in lines)
            {
                DisplayWithPause(line);
            }
        }
    }
}
