using System;
using System.Linq;

namespace Lab1
{
    static class StringOperations {
        public static string removeWhiteChars(string a)
        {
            char prevSign = ' ';
            string result = "";
            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i] == ' ' && i == 0)
                {
                    while (i < a.Count())
                    {
                        if (a[i] != ' ')
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                if (i < a.Count())
                {
                    if (!(prevSign == ' ' && a[i] == ' '))
                    {
                        result += a[i];
                    }
                    prevSign = a[i];
                }

            }
            return result;

        }
        static Boolean isNormal(char a)
        {
            if (a == 'ą' || a == 'Ą' || a == 'ć' || a == 'Ć' || a == 'ę' || a == 'Ę' || a == 'ł' || a == 'Ł' || a == 'ń' || a == 'Ń' || a == 'ó' || a == 'Ó' || a == 'ś' || a == 'Ś' || a == 'ż' || a == 'Ż' || a == 'ź' || a == 'Ź')
            {
                return true;
            }
            if (((int)a >= 65 && (int)a <= 90) || ((int)a >= 97 && (int)a <= 122) || ((int)a >= 48 && (int)a <= 57) || (int)a == 32)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean ValidateString(string a)
        {
            int couter = 0;
            foreach (var item in a)
            {
                if (!isNormal(item))
                {
                    return false;
                }
                if (item != ' ')
                {
                    couter++;
                }
            }

            if (couter >= 2)
            {
                return true;
            }
            return false;
        }
    }
}