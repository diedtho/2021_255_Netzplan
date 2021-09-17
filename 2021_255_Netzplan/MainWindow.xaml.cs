using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
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
using System.Linq;
using System.Collections.Generic;

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
            listeVorgaenge.Add(new Vorgang() { vorgangBuchstb = "A"[0], beschreibung = "Elektrische Leitungen verlegen", dauerInTagen = 3, vorgaenger = new List<char>() });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "B"[0],
                beschreibung = "Maschinenfundamente erstellen",
                dauerInTagen = 4,
                vorgaenger = new List<char> { "A"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "C"[0],
                beschreibung = "Stromanschlusskasten aufstellen",
                dauerInTagen = 3,
                vorgaenger = new List<char> { "A"[0] },
                nachfolger = new List<char>()
            }); ;

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "D"[0],
                beschreibung = "Materialzuführungsbänder aufbauen",
                dauerInTagen = 18,
                vorgaenger = new List<char> { "B"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "E"[0],
                beschreibung = "Aufstellen der Maschinen",
                dauerInTagen = 21,
                vorgaenger = new List<char> { "B"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "F"[0],
                beschreibung = "Beseitigung des Bauschutts",
                dauerInTagen = 21,
                vorgaenger = new List<char> { "C"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "G"[0],
                beschreibung = "Elektrische Anschlüsse anbringen",
                dauerInTagen = 6,
                vorgaenger = new List<char> { "D"[0], "E"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "H"[0],
                beschreibung = "Reinigung der Maschinenhalle",
                dauerInTagen = 7,
                vorgaenger = new List<char> { "F"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "I"[0],
                beschreibung = "Probelauf der Maschinen",
                dauerInTagen = 18,
                vorgaenger = new List<char> { "G"[0] },
                nachfolger = new List<char>()
            });

            listeVorgaenge.Add(new Vorgang()
            {
                vorgangBuchstb = "J"[0],
                beschreibung = "Einweihung durch den Vorstand",
                dauerInTagen = 1,
                vorgaenger = new List<char> { "H"[0], "I"[0] },
                nachfolger = new List<char>()
            });

        }



        List<Vorgang> listeVorgaenge = new List<Vorgang>();


        private void btnClickVorgangHinzufuegen(object sender, RoutedEventArgs e)
        {
            VorgangCreate secondWindow = new();
            secondWindow.ShowDialog();
            List<char> listeNachfolger = new List<char>();
            List<char> listeVorgaenger = new List<char>();
            if (secondWindow.tbVorgaenger1.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger1.Text[0]); }
            if (secondWindow.tbVorgaenger2.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger2.Text[0]); }
            if (secondWindow.tbVorgaenger3.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger3.Text[0]); }
            if (secondWindow.tbVorgaenger4.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger4.Text[0]); }
            if (secondWindow.tbVorgaenger5.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger5.Text[0]); }
            if (secondWindow.tbVorgaenger6.Text != "") { listeVorgaenger.Add(secondWindow.tbVorgaenger6.Text[0]); }

            Vorgang vorgNeu = new Vorgang(secondWindow.tbVorgang.Text[0], secondWindow.tbBeschreibung.Text,
                int.Parse(secondWindow.tbDauerInTagen.Text), listeVorgaenger.ToList(), null);
            listeVorgaenge.Add(vorgNeu);

            listeBerechnen();
            showListViewVorgaenge();
        }

        private void showListViewVorgaenge()
        {
            if (listeVorgaenge == null)
            {
                return;
            }

            for (int a = 0; a < listeVorgaenge.Count; a++)
            {
                string strVorg = "";
                foreach (char vorgaenger in listeVorgaenge[a].vorgaenger)
                {
                    strVorg += vorgaenger + ",";
                }
                listeVorgaenge[a].strVorg = strVorg;
            }

            for (int a = 0; a < listeVorgaenge.Count; a++)
            {
                string strNachf = "";
                if (listeVorgaenge[a].nachfolger != null)
                {
                    foreach (char nachfolger in listeVorgaenge[a].nachfolger)
                    {
                        strNachf += nachfolger + ",";
                    }
                    listeVorgaenge[a].strNachf = strNachf;
                }
            }

            //MessageBox.Show(listeVorgaenge.Last().strVorg, "Letzter Vorgang StringVorgänger", MessageBoxButton.OK);

            lvVorgaenge.ItemsSource = null;
            lvVorgaenge.ItemsSource = listeVorgaenge;
        }

        private void mnuitmExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mnuitmSpeichern(object sender, RoutedEventArgs e)
        {
            var data = listeVorgaenge;

            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };

            using (var writer = new StreamWriter(@"C:\Users\Thorsten\source\repos\2021_255_Netzplan\2021_255_Netzplan\netzplan.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Vorgang>();
                csv.WriteRecords(data);
            }

        }

        private void listeBerechnen()
        {
            if (listeVorgaenge == null)
            {
                return;
            }

            // Liste vorwärts vom ersten Vorgang
            listeVorgaenge[0].faz = 0;
            listeVorgaenge[0].fez = 0 + listeVorgaenge[0].dauerInTagen;

            for (int i = 1; i < listeVorgaenge.Count; i++)
            {
                if (listeVorgaenge[i].vorgaenger.Count > 0)
                {
                    for (int nr = 0; nr < listeVorgaenge[i].vorgaenger.Count; nr++)
                    {
                        char x = listeVorgaenge[i].vorgaenger[nr];
                        int faz = listeVorgaenge[i].faz;
                        int fezVorgaenger = listeVorgaenge.Find(fund => fund.vorgangBuchstb == x).fez;
                        if (faz < fezVorgaenger)
                        {
                            listeVorgaenge[i].faz = fezVorgaenger;
                        }
                        listeVorgaenge[i].fez = listeVorgaenge[i].faz + listeVorgaenge[i].dauerInTagen;
                        for (int vrgNr = 0; vrgNr < listeVorgaenge.Count; vrgNr++)
                        {
                            if (listeVorgaenge[vrgNr].vorgangBuchstb == x && listeVorgaenge[vrgNr].nachfolger != null)
                            {
                                listeVorgaenge[vrgNr].nachfolger.Add(listeVorgaenge[i].vorgangBuchstb);
                            }
                        }
                    }
                }
            }

            // Liste rückwärts vom letzten Vorgang
            //MessageBox.Show("Liste rückwärts!", "Listenberechnung", MessageBoxButton.OK);
            listeVorgaenge.Last().sez = listeVorgaenge.Last().fez;
            listeVorgaenge.Last().saz = listeVorgaenge.Last().sez - listeVorgaenge.Last().dauerInTagen;

            for (int j = listeVorgaenge.Count - 1; j >= 0; j--)
            {

                //MessageBox.Show(listeVorgaenge[j].vorgangBuchstb + "", "Aktueller Vorgang", MessageBoxButton.OK);
                //MessageBox.Show(listeVorgaenge[j].vorgangBuchstb + "", "Aktueller Vorgang SEZ=" + listeVorgaenge[j].sez, MessageBoxButton.OK);
                if (listeVorgaenge[j].vorgaenger.Count > 0)
                {
                    for (int nr = 0; nr < listeVorgaenge[j].vorgaenger.Count; nr++)
                    {
                        char vorgaengerBuchstb = listeVorgaenge[j].vorgaenger[nr];
                        int sazNachfolger = listeVorgaenge[j].saz;


                        for (int k = 0; k < listeVorgaenge.Count; k++)
                        {
                            if (listeVorgaenge[k].vorgangBuchstb == vorgaengerBuchstb)
                            {
                                if (listeVorgaenge[k].sez == 0 || listeVorgaenge[k].sez > sazNachfolger)
                                {
                                    listeVorgaenge[k].sez = sazNachfolger;
                                    listeVorgaenge[k].saz = sazNachfolger - listeVorgaenge[k].dauerInTagen;
                                    listeVorgaenge[k].gp = listeVorgaenge[k].saz - listeVorgaenge[k].faz;
                                    if (listeVorgaenge[k].fp == 0 || listeVorgaenge[j].faz - listeVorgaenge[k].fez < listeVorgaenge[k].fp)
                                    {
                                        listeVorgaenge[k].fp = listeVorgaenge[j].faz - listeVorgaenge[k].fez;
                                    }
                                }

                            }

                        }
                    }
                }

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listeBerechnen();
            showListViewVorgaenge();
        }
    }
}
