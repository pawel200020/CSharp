using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordChcecker.TextOperation;

namespace WordChcecker
{
    public partial class Please_wait : Form
    {
        private Text_Analyzer an;
        public static Task<Dictionary<string, int>> CountAsync(List<string> result, Progress<int> progress)
        {
            return Task.Run(() =>
            {
                var tem = result.CountWords(progress);
                return tem;
            });
        }
        public static Task<List<string>> ErrorAsync(List<string> result, Progress<int> progress)
        {
            return Task.Run(() =>
            {
                var tem = result.ErrorWords(progress);
                return tem;
            });
        }
        public Please_wait(Text_Analyzer an)
        {
            InitializeComponent();
            this.an = an;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void button1_Click(object sender, System.EventArgs e)
        {
            button2.Visible = false;
            
            an.countText.Text = "";
            an.errorText.Text = "";

            string text = an.inputText.Text;
            var result = text.WordsToList();

            progressBar1.Value = 0;
            progressBar2.Value = 0;

            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;

            });
            var progress2 = new Progress<int>(percent =>
            {
                progressBar2.Value = percent;

            });

            var countedWords =  CountAsync(result, progress);
            var errorWords =  ErrorAsync(result, progress2);
            await Task.WhenAll(countedWords, errorWords);
            foreach (var VARIABLE in countedWords.Result)
            {
                an.countText.AppendText(VARIABLE.Key + " " + VARIABLE.Value);
                an.countText.AppendText(Environment.NewLine);
            }
            foreach (var VARIABLE in errorWords.Result)
            {
                an.errorText.AppendText(VARIABLE);
                an.errorText.AppendText(Environment.NewLine);
            }
            button1.Visible = true;
        }
    }
}
