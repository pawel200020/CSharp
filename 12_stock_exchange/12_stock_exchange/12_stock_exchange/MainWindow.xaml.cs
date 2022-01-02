using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _12_stock_exchange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
            Random r = new Random();
            LaunchProcess(r,leftTop,leftTop_Price, leftTop_Change);
            LaunchProcess(r, rightTop, rightTop_Price, rightTop_Change);
            LaunchProcess(r, rightBotton, rightBotton_Price, rightBotton_Change);
            LaunchProcess(r, leftBotton, leftBotton_Price, leftBotton_Change);
        }
        private void LaunchProcess(Random r, Border border, TextBlock currPriceFiled, TextBlock diffPriceFiled)
        {
            var t = Task.Run(() =>
            {
                double a1 = ((r.Next(5000, 10000)) / ((double)100));
                this.Dispatcher.Invoke((Action)(() =>
                {
                    currPriceFiled.Text = a1.ToString();
                }));
                Thread.Sleep(1000);
                while (true)
                {
                    double a2 = ((r.Next(0, 200)) / ((double)100));
                    a2 -= 1;
                    a1 +=a2;
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        if (a2 < 0)
                        {
                            border.Background = new SolidColorBrush(Colors.Red);
                            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AF0505"));
                        }
                        else
                        {
                            border.Background = new SolidColorBrush(Colors.Green);
                            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A7F90E"));
                        }
                        currPriceFiled.Text = a1.ToString("0.##") + " PLN";
                        diffPriceFiled.Text=a2.ToString("0.##")+" PLN";
                    }));
                    Thread.Sleep(1000);

                }
            });
        }
    }
}
