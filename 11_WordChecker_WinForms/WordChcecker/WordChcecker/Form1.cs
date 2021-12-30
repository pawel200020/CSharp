using System.ComponentModel;
using WordChcecker.TextOperation;

namespace WordChcecker
{
    public partial class Text_Analyzer : Form
    {

        public Text_Analyzer()
        {
            InitializeComponent();
        }
        public static Task<Dictionary<string, int>> CountAsync(List<string> result, Progress<int> progress)
        {
            return Task.Run(() =>
            {
                var tem = result.CountWords(progress);
                return tem;
            });
        }
        private async void button1_Click(object sender, System.EventArgs e)
        {
            progressBar1.Visible = true;
            countText.Text = "";
            errorText.Text = "";

            string text = inputText.Text;
            var result = text.WordsToList();

            progressBar1.Value = 0;

            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;

            });

            var countedWords = await CountAsync(result, progress);
            //Task<Dictionary<string, int>> t1 = Task<Dictionary<string, int>>.Factory.StartNew(() =>
            //{
            //    return result.CountWords(progress);
            //});
            //Task<List<string>> t2 = Task < List<string>>.Factory.StartNew(() =>
            //{
            //    return result.ErrorWords();
            //});
            //var countedWords = t1.Result;
            //var errorWords = t2.Result;
            
            //foreach (var VARIABLE in errorWords)
            //{
            //    errorText.AppendText(VARIABLE);
            //    errorText.AppendText(Environment.NewLine);
            //}
            foreach (var VARIABLE in countedWords)
            {
                countText.AppendText(VARIABLE.Key+" "+VARIABLE.Value);
                countText.AppendText(Environment.NewLine);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}