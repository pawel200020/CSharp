using System.Text;

namespace WordChcecker.TextOperation
{
    internal static class StringConverter
    {
        private static bool IsInterpunction(char a)
        {
            if (a == ',' || a == ':' || a == ';' || a == '-' || a == '\"' || a == '(' || a == ')' || a == '?' ||
                a == '!'|| a == '.')
            {
                return true;
            }

            return false;
        }
        public static List<string> WordsToList(this string input)
        {
            
            long i = 0;
            List <string> result = new List<string>();
            StringBuilder word = new StringBuilder();
            foreach (var VARIABLE in input)
            {
                char VariableL = Char.ToLower(VARIABLE);
                Console.WriteLine("-"+VariableL);
                if (((IsInterpunction(VariableL) && !(i + 1 == input.Length) && input.ElementAt((Index)(i + 1)) == ' ')|| 
                     (IsInterpunction(VariableL) && i + 1 == input.Length)|| 
                     (VariableL == ' '))&& word.Length != 0)
                {
                    result.Add(word.ToString());
                    word = new StringBuilder();
                }
                else if(i + 1 == input.Length)
                {
                    word.Append(VariableL);
                    result.Add(word.ToString());
                }
                if ((word.Length == 0 && !IsInterpunction(VariableL) && VARIABLE!=' ')|| word.Length != 0)
                {
                    word.Append(VariableL);
                }

                ++i;
            }
            return result;
        }
    }
}
