using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using _0217orai.Models;

namespace _0217orai
{
    public partial class MainWindow : Window
    {
        private static List<Kerdes> kerdesek = new List<Kerdes>();
        private static int aktKerdesIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    KerdesBeolvas(openFileDialog.FileName);
                    MessageBox.Show("Sikeres betöltés", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (kerdesek.Count > 0)
                    {
                        aktKerdesIndex = 0;
                        MutatKerdes(aktKerdesIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a fájl beolvasásakor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void KerdesBeolvas(string filename)
        {
            kerdesek.Clear();
            try
            {
                string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 5)
                    {
                        kerdesek.Add(new Kerdes(parts[0], parts[1], parts[2], parts[3], parts[4]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a kérdések beolvasásakor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MutatKerdes(int index)
        {
            if (kerdesek.Count > 0)
            {
                Kerdes aktualisKerdes = kerdesek[index];
                tbkKerdesSzovege.Text = aktualisKerdes.KerdesSzovege;
                ValaszA.Content = aktualisKerdes.ValaszA;
                ValaszB.Content = aktualisKerdes.ValaszB;
                ValaszC.Content = aktualisKerdes.ValaszC;
            }
        }

        private void Kiertekeles_Click(object sender, RoutedEventArgs e)
        {
            int helyesValaszok = kerdesek.Count(k => k.ValaszEllenorzes());
            MessageBox.Show($"Helyes válaszok száma: {helyesValaszok} / {kerdesek.Count}", "Kiértékelés", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Elozo_Click(object sender, RoutedEventArgs e)
        {
            if (aktKerdesIndex > 0)
            {
                aktKerdesIndex--;
                MutatKerdes(aktKerdesIndex);
            }
        }

        private void Kovetkezo_Click(object sender, RoutedEventArgs e)
        {
            if (aktKerdesIndex < kerdesek.Count - 1)
            {
                aktKerdesIndex++;
                MutatKerdes(aktKerdesIndex);
            }
        }

        private void Valaszmentes_Click(object sender, RoutedEventArgs e)
        {
            if (kerdesek.Count > 0)
            {
                Kerdes aktualisKerdes = kerdesek[aktKerdesIndex];
                if (ValaszA.IsChecked == true) aktualisKerdes.FelhValasz = "A";
                else if (ValaszB.IsChecked == true) aktualisKerdes.FelhValasz = "B";
                else if (ValaszC.IsChecked == true) aktualisKerdes.FelhValasz = "C";
            }
        }
    }
}