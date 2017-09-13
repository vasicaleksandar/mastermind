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
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp1.Klase;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Igra.xaml
    /// </summary>
    public partial class Igra : Window
    {
        private string ime;
        private int tezina;
        private int[] komb;
        private int vreme;
        private int red = 0;
        private DispatcherTimer timer;
        public Igra()
        {
            InitializeComponent();
        }
        private void startTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (vreme == 0) {
                gubitak();
            }
            lblVreme.Content = "" + vreme.ToString();
            vreme--;
        }

        public void zapocni(string ime, int tezina) {
            this.ime = ime;
            this.tezina = tezina;
            lblIme.Content = ime;
            komb = new int[4];
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                komb[i] = random.Next(1, 7);
            }
            if (tezina==0)
                vreme = 100;
            else
                vreme = 50;
            for (int i = 1; i < 25; i++)
            {
                String name = "r" + i;
                Rectangle obj = (Rectangle)this.FindName(name);
                obj.MouseLeftButtonUp += ocisti;
            }
            startTimer();
        }

        public void ocisti(object obj, MouseButtonEventArgs e) {
            Rectangle pom = obj as Rectangle;
            pom.Fill = null;
        }
        public string kombinacija() {
            string tmp="";
            for (int i = 0; i < komb.Length; i++)
            {
                switch (komb[i])
                {
                    case 1:
                        tmp += "Skocko|";
                        break;
                    case 2:
                        tmp += "Tref|";
                        break;
                    case 3:
                        tmp += "Pik|";
                        break;
                    case 4:
                        tmp += "Srce|";
                        break;
                    case 5:
                        tmp += "Karo|";
                        break;
                    case 6:
                        tmp += "Zvezda";
                        break;
                }
            }
            return tmp;
        }
        private void dodaj(Rectangle r)
        {
            for (int i = 4 * red + 1; i < (4 * red) + 5; i++)
            {
                String name = "r" + i;
                Rectangle obj = (Rectangle)this.FindName(name);
                if (obj.Fill == null)
                {
                    obj.Fill = r.Fill;
                    break;
                }
            }
        }

        private void skocko_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(skocko);
        }

        private void tref_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(tref);
        }

        private void pik_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(pik);
        }

        private void srce_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(srce);
        }

        private void karo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(karo);
        }

        private void zvezda_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dodaj(zvezda);
        }

        private void provera_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int[] pom =new int[4];
            int[] uneto = new int[4];
            int n = 0;
            int zuto = 0;
            int crveno = 0;
            int m = 0;
            komb.CopyTo(pom, 0);

            for (int i = 4 * red + 1; i < (4 * red) + 5; i++) {
                string name = "r" + i;
                Rectangle obj = (Rectangle)this.FindName(name);
                if (obj.Fill == skocko.Fill)
                    uneto[m] = 1;
                else if (obj.Fill == tref.Fill)
                    uneto[m] = 2;
                else if (obj.Fill == pik.Fill)
                    uneto[m] = 3;
                else if (obj.Fill == srce.Fill)
                    uneto[m] = 4;
                else if (obj.Fill == karo.Fill)
                    uneto[m] = 5;
                else if (obj.Fill == zvezda.Fill)
                    uneto[m] = 6;
                else n--;
                n++;
                m++;
               
            }
            if (n > 3)
            {
                for (int i = 0; i < pom.Length; i++) {
                    if (uneto[i] == pom[i]) crveno++;
                }
                for (int i = 0; i < uneto.Length; i++) {
                    for (int j = 0; j < pom.Length; j++) {
                        if (uneto[i] == pom[j]) {
                            zuto++;
                            pom[j] = 0;
                            break;
                        }
                    }
                }
                for (int i = 4 * red + 1; i < (4 * red) + zuto+1; i++) {
                    string name = "e" + i;
                    Ellipse obj = (Ellipse)this.FindName(name);
                    obj.Fill = new SolidColorBrush(Colors.Yellow);
                }
                for (int i = 4 * red + 1; i < (4 * red) + crveno + 1; i++)
                {
                    string name = "e" + i;
                    Ellipse obj = (Ellipse)this.FindName(name);
                    obj.Fill = new SolidColorBrush(Colors.Red);
                }

                if (crveno == 4) pobeda();
                else if(red == 5) gubitak();

                red++;
            }
            else { MessageBox.Show("Popunite sva polja u redu!!!"); }
        }

        public void pobeda() {
            timer.Stop();
            Igrac igrac = new Igrac(ime, tezina);
            igrac.upisiUdatoteku(vreme, red);
            MessageBox.Show("Resili ste SKOCKA!!!");
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();

        }

        public void gubitak() {
            timer.Stop();
            MessageBox.Show("Niste uspeli da resite SKOCKA!!!");
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
