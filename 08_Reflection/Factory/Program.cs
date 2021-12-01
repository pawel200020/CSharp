using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Factory
{
    public static class Extensions
    {
        public static string reverse(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }

    class Program
    {
        static string[] ArgParser(string arg)
        {
            //c:\\BeerProcessor.dll;Piwo dla Franka
            var result = new string[2];
            int i = 0;
            foreach(var item in arg){
                if (item == ';') { i++; }
                else result[i] += item;


            }
            return result;
            
        }
        static string GetDLLName(string path)
        {
            int i = path.Length - 1-4;
            var result = "";
            while (path[i] != (char)92)
            {
                result += path[i];
                i--;
            }
            return result.reverse();
        }
        static string GetClassName(string dll)
        {
            string result = "";
            foreach (var item in dll)
            {      
                if (item == 'P') {
                    return result + "Order";
                }
                result += item;
            }
            return null;
        }
        static void Main(string[] args)

        {
            foreach (var item in args)
            {
                var temp = ArgParser(item);          
                //FileInfo f = new FileInfo(@"D:\Code\UJ\CSharp2\08_Reflection\BeerProcessor\bin\Debug\net5.0\BeerProcessor.dll"); //plik z assembly
                FileInfo f = new FileInfo(temp[0]); //plik z assembly        
                Assembly assembly = Assembly.LoadFrom(f.FullName); // Wczytywanie assembly. 

                //Nastepnie musimy pobrac typ klasu jaki chemy wiciągnąc z assemlby. 
                string dllName = GetDLLName(temp[0]);
                Type t = assembly.GetType( dllName+ "."+GetClassName(dllName));

                MethodInfo method = t.GetMethod("Process"); //pobieranie adresu delagaty do metody hello
                PropertyInfo p = t.GetProperty("Title");

                object o = Activator.CreateInstance(t);
                p.SetValue(o, temp[1], null);

                method.Invoke(o, null); //wywoływanie hello
                Console.ReadLine();
            }

        }
    }
}
