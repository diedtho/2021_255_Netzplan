using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2021_255_Netzplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        List<Vorgang> listeVorgaenge = new List<Vorgang>();

        private void btnClickVorgangHinzufuegen(object sender, RoutedEventArgs e)
        {            
            VorgangCreate secondWindow = new();
            secondWindow.ShowDialog();            
            listeVorgaenge.Add(new Vorgang(secondWindow.tbVorgang.Text, secondWindow.tbBeschreibung.Text,
                secondWindow.tbDauerInTagen.Text, secondWindow.tbVorgaenger.Text));
            lvVorgaenge.ItemsSource = listeVorgaenge.ToList();
        }

        private void mnuitmExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mnuitmSpeichern(object sender, RoutedEventArgs e)
        {

        }
    }
}
