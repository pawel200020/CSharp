
using System.Windows.Forms;

namespace WordChcecker.TextOperation
{
    internal static class WordCounter
    {
        public static Dictionary<string, int> CountWords(this List<string> input, IProgress<int> progress)
        {
            int i = 1;
            Dictionary<string, int> wordsWithQuantity = new Dictionary<string, int>();
            foreach (var VARIABLE in input)
            {
                if (!wordsWithQuantity.ContainsKey(VARIABLE))
                {
                    wordsWithQuantity.Add(VARIABLE,1);
                }
                else
                {
                    wordsWithQuantity[VARIABLE] += 1;
                }
                progress.Report(i*100/input.Count);
                i++;
                Thread.Sleep(50);
            }
            return wordsWithQuantity;
        }
    }
}
