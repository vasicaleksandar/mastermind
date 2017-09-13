using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Klase
{
    class Poeni
    {
        public Poeni() { }

        public List<Igrac> lako() {
            List<Igrac> niz = new List<Igrac>();
            FileStream file = File.OpenRead("../../ranglista/lako.txt");
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                niz = bf.Deserialize(file) as List<Igrac>;
                file.Dispose();
                return niz;
            }
            catch (Exception e)
            {
                file.Dispose();
                return niz;
            }
            
        }

        public List<Igrac> tesko()
        {
            List<Igrac> niz = new List<Igrac>();
            FileStream file = File.OpenRead("../../ranglista/tesko.txt");
            try{
                BinaryFormatter bf = new BinaryFormatter();
                niz = bf.Deserialize(file) as List<Igrac>;
                file.Dispose();
                return niz;
            }
            catch (Exception e){
                file.Dispose();
                return niz;
            }
            
        }
    }
}
