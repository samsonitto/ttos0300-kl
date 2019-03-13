using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTOS0300
{
    public static class Joukkue
    {
        public static List<Pelaaja> HaePelaajat()
        {
            //luodaan 5 pelaajaa testausta varten
            List<Pelaaja> pelaajat = new List<Pelaaja>();
            pelaajat.Add(new Pelaaja("Lasse", "Kukkonen", "puolustaja", "left", 5));
            pelaajat.Add(new Pelaaja("Kimmo", "Timonen", "puolustaja", "left", 44));
            pelaajat.Add(new Pelaaja("Jarkko", "Ruutu", "hyökkääjä", "left", 25));
            pelaajat.Add(new Pelaaja("Jarkko", "Immonen", "hyökkääjä", "right", 26));
            pelaajat.Add(new Pelaaja("Mikko", "Rantanen", "hyökkääjä", "left", 68));
            pelaajat.Add(new Pelaaja("Pekka", "Rinne", "maalivahti", "left", 35));
            return pelaajat;
        }
    }
    public class Pelaaja
    {
        //PROPERTIES
        public string Enimi { get; set; }
        public string Snimi { get; set; }
        public string Pelipaikka { get; set; }
        public string Kätisyys { get; set; }
        public int Numero { get; set; }
        //CONSTRUCTORS
        public Pelaaja()
        {

        }
        public Pelaaja(string enimi, string snimi, string pelipaikka, string kätisyys, int numero)
        {
            Enimi = enimi;
            Snimi = snimi;
            Pelipaikka = pelipaikka;
            Kätisyys = kätisyys;
            Numero = numero;
        }
        //METHODS
        public override string ToString()
        {
            return $"{Enimi} {Snimi} {Pelipaikka} {Kätisyys} #{Numero}";
        }
    }
}
