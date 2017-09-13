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
using WpfApp1.Klase;

namespace WpfApp1
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
        private string ime;
        private int tezina;
        public delegate void delPodaci(string playerName, int tezina);

        private void btnPoeniLako_Click(object sender, RoutedEventArgs e)
        {
            string tmp = "Poeni Lako";
            Poeni poeni = new Poeni();
            List<Igrac> niz = poeni.lako();
            for (int i = 0; i < niz.Count(); i++)
            {
                tmp += "\n" + niz.ElementAt(i).ToString();
            }
            MessageBox.Show(tmp);
        }

        private void btnPoeniTesko_Click(object sender, RoutedEventArgs e)
        {
            string tmp = "Poeni tesko";
            Poeni poeni = new Poeni();
            List<Igrac> niz = poeni.tesko();
            for (int i = 0; i < niz.Count(); i++)
            {
                tmp += "\n" + niz.ElementAt(i).ToString();
            }
            MessageBox.Show(tmp);
        }

        private void btnZapocni_Click(object sender, RoutedEventArgs e)
        {
            Igra igra = new Igra();

            this.ime = txtIme.Text;

            if (lako.IsChecked == true)this.tezina = 0;
            else this.tezina = 1;


            delPodaci delegat = new delPodaci(igra.zapocni);
            delegat(ime, tezina);
            igra.Show();
            this.Close();
        }
    }
}
