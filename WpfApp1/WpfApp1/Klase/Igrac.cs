using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Klase
{
    [Serializable]
    class Igrac
    {
        private string ime;
        private int tezina;
        private int bodovi;

        public Igrac(){}

        public Igrac(string ime, int tezina)
        {
            this.ime = ime;
            this.tezina = tezina;
        }

        public override string ToString()
        {
            return ime + " --- " + bodovi;
        }

        public void upisiUdatoteku(int vreme, int red)
        {
            Poeni poeni = new Poeni();
            List<Igrac> niz;
            if (this.tezina == 0)
                niz = poeni.lako();
            else
                niz = poeni.tesko();
            switch (red)
            {
                case 1:
                    bodovi = vreme + 25;
                    break;
                case 2:
                    bodovi = vreme + 20;
                    break;
                case 3:
                    bodovi = vreme + 15;
                    break;
                case 4:
                    bodovi = vreme + 10;
                    break;
                case 5:
                    bodovi = vreme + 5;
                    break;
                case 6:
                    bodovi = vreme;
                    break;
                default:
                    bodovi = 0;
                    break;
            }
            if (tezina == 1) bodovi = (bodovi+50) * 2;
            if(this.bodovi>0)niz.Add(this);

            FileStream fs;
            if (this.tezina == 0)
                fs = File.OpenWrite("../../ranglista/lako.txt");
            else
                fs = File.OpenWrite("../../ranglista/tesko.txt");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, niz);
            MessageBox.Show("Upisani ste u datoteku(poeni: " +this.bodovi+ ").");
            fs.Dispose();

        }
    }
}
