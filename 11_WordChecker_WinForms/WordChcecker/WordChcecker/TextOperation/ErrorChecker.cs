

namespace WordChcecker
{
    static internal class ErrorChecker
    {
        public static List<string> ErrorWords(this List<string> input, IProgress<int> progress)
        {
            int i = 1;
            List<string> result = new List<string>();
            bool wasFound = false;
            string[] lines = File.ReadAllLines("dictionary.txt");
            foreach (var VARIABLE in input)
            {
                foreach (var VARIABLE2 in lines)
                {
                    if ((VARIABLE2.ToLower()).Equals(VARIABLE))
                    {
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                {
                   if(!result.Contains(VARIABLE))
                        result.Add(VARIABLE);
                }

                wasFound = false;
                progress.Report(i * 100 / input.Count);
                i++;
                Thread.Sleep(50);
            }
            return result;
        }
    }
}
