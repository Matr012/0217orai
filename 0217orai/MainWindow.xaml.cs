using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using _0217orai.Models;

namespace _0217orai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Kerdes> kerdesek = new List<Kerdes>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kiertekeles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Valaszmentes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Elozo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kovetkezo_Click(object sender, RoutedEventArgs e)
        {

        }
        private static void BetoltesClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(';');
                    Kerdes kerdes = new Kerdes(parts[0], parts[1], parts[2], parts[3], parts[4]);
                    kerdesek.Add(kerdes);
                }
            }

        }
    }

}