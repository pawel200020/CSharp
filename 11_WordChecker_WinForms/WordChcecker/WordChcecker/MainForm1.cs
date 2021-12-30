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
        private void button1_Click(object sender, System.EventArgs e)
        {
            var statusBarsForm= new Please_wait(this);
            statusBarsForm.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}