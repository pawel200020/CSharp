using System;
using System.Reflection;
using System.Security;

namespace _07_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldInfo[] myFieldInfo;
            Type myType = typeof(Customer);
            myFieldInfo = myType.GetFields(BindingFlags.Instance | BindingFlags.Public);

            Console.WriteLine("\nPublic Fileds\n");
            for (int i = 0; i < myFieldInfo.Length; i++)
            {
                Console.WriteLine("Name            : {0}", myFieldInfo[i].Name);
                Console.WriteLine("FieldType       : {0}", myFieldInfo[i].FieldType);
            }
            myFieldInfo = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            Console.WriteLine("\nNonPublic Fileds\n");
            for (int i = 0; i < myFieldInfo.Length; i++)
            {
                Console.WriteLine("Name            : {0}", myFieldInfo[i].Name);
                Console.WriteLine("FieldType       : {0}\n", myFieldInfo[i].FieldType);
            }

            MethodInfo[] myMethodsInfo;
            myMethodsInfo = myType.GetMethods();
            Console.WriteLine("\nMethods\n");
            for (int i = 0; i < myMethodsInfo.Length; i++)
            {
                MethodInfo myMethodInfo = (MethodInfo)myMethodsInfo[i];
                Console.WriteLine("Name              : {0}", myMethodInfo.Name);
                Console.WriteLine("Is public         : {0}", myMethodInfo.IsPublic);
                Console.WriteLine("Return type       : {0}\n", myMethodInfo.ReturnType);
            }

            Type[] myNestedClassesInfo;
            myNestedClassesInfo = myType.GetNestedTypes();
            Console.WriteLine("\nNestedTypes\n");
            for (int i = 0; i < myNestedClassesInfo.Length; i++)
            {
                Type myNestedClasses = (Type)myNestedClassesInfo[i];
                Console.WriteLine("Name              : {0}", myNestedClasses.Name);
                if (myNestedClasses.IsClass)
                {
                    Console.WriteLine("IsClass           : {0}", myNestedClasses.IsClass);
                }
                if (myNestedClasses.IsEnum)
                {
                    Console.WriteLine("IsEnum            : {0}", myNestedClasses.IsEnum);
                }
                Console.WriteLine("Is public         : {0}\n", myNestedClasses.IsPublic);
            }

            PropertyInfo[] myProperites;
            myProperites = myType.GetProperties();
            Console.WriteLine("\nProperites\n");
            for (int i = 0; i < myProperites.Length; i++)
            {
                PropertyInfo PropertyInfo = (PropertyInfo)myProperites[i];
                Console.WriteLine("Name              : {0}", PropertyInfo.Name);
                Console.WriteLine("Type              : {0}", PropertyInfo.PropertyType);
                Console.WriteLine("Can read          : {0}", PropertyInfo.CanRead);
                Console.WriteLine("Can write         : {0}\n", PropertyInfo.CanWrite);
            }

            try
            {
                MemberInfo[] myMemberInfo;

                myMemberInfo = myType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                Console.WriteLine("\nThe members of class '{0}' are :\n", myType);
                for (int i = 0; i < myMemberInfo.Length; i++)
                {
                    // Display name and type of the concerned member.
                    Console.WriteLine("'{0}' is a {1}", myMemberInfo[i].Name, myMemberInfo[i].MemberType);
                }
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            
            Customer myObject = new Customer("Janek");
            try
            {
                myType.GetProperty("Address").SetValue(myObject, "Ujastek 4");
                myType.GetProperty("SomeValue").SetValue(myObject, 221);
                //myType.GetProperty("Name").SetValue(myObject, "Janek");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The property does not exist in MyClass." + e.Message);
            }
            try
            {
                Console.WriteLine("\nSetted properties: ");
                Console.WriteLine("Address: {0}", myType.GetProperty("Address").GetValue(myObject));
                Console.WriteLine("SomeValue: {0}",myType.GetProperty("SomeValue").GetValue(myObject));
                Console.WriteLine("Name not set but constructor devired: {0}", myType.GetProperty("Name").GetValue(myObject));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The property does not exist in MyClass." + e.Message);
            }

        }
    }
}

