using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Ödev2
{
    class Program {
        static void Main(string[] args) {
            Oyun oyun = new Oyun();
            oyun.Baslat();
        }
        class Oyun {
            public Oyuncu oyuncu;
            public int atışSayısı = 0;
            public int atışHakkı = 10;
            public int puan = 0;
            public List<int> atışlar = new List<int>();
            public void Baslat() {
                
                Console.Write("Ad: ");
                string ad = Console.ReadLine();
                Console.Write("Soyad: ");
                string soyad = Console.ReadLine();
                Console.Write("Tarih (dd/mm/YYYY): ");
                string tarih = Console.ReadLine();
                this.oyuncu = new Oyuncu(ad, soyad, tarih);

                while (this.atışHakkı > 0) { 
                    ZarAt();
                }

                string atışlarListesi = string.Join(" | ", this.atışlar.Select(x => x.ToString()).ToArray());
                int kazanmaSayısı = this.atışlar.FindAll(x => x == 6).Count;
                int kaybetmeSayısı = this.atışlar.FindAll(x => x == 1).Count;

                this.puan += (kazanmaSayısı * 100) - (kaybetmeSayısı * 75);
                puan += (this.oyuncu.ay <= 6) ? 30 : -20;
                puan += (this.oyuncu.ad.Length < this.oyuncu.soyad.Length) ? -10 : 50;
                puan += (this.oyuncu.ad.Length == this.oyuncu.soyad.Length) ? -25 : 0; // Eşitse (50 - 25) puan ekle 

                Console.WriteLine((puan < 500) ? "OYUNU KAYBETTİN" : "OYUNU KAZANDIN");
                Console.WriteLine($"Puan: {this.puan}\nToplam Kazanma Sayısı: {kazanmaSayısı}\nToplam Kaybetme Sayısı: {kaybetmeSayısı}");
                Console.WriteLine($"Toplam Atış Sayısı: {this.atışSayısı}\nAtışlar:\n{atışlarListesi}");
            }

            public void ZarAt() {
                Random rastgele = new Random();
                int sayi = rastgele.Next(1, 7);
                if (sayi == 1 || sayi == 6) { this.atışHakkı -= 1; }
                this.atışSayısı += 1;
                this.atışlar.Add(sayi);
            }
        }

        class Oyuncu {
            public string ad;
            public string soyad;
            public string tarih;
            public DateTime doğumGünü;
            public int ay;

            public Oyuncu(string ad, string soyad, string tarih) {
                this.ad = ad;
                this.soyad = soyad;
                this.tarih = tarih;
                this.doğumGünü = DateTime.ParseExact(tarih, "dd/MM/yyyy", new CultureInfo("tr-TR"));
                this.ay = doğumGünü.Month;

            }
        }
    }
}