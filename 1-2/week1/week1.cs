using System;
using System.Collections.Generic;
using System.Globalization;


namespace Ödev1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("No: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tarih (dd/mm/YYYY): ");
            string tarih = Console.ReadLine();
            Console.Write("Ders Sayısı: ");
            int dersSayı = Convert.ToInt32(Console.ReadLine());
            while (dersSayı < 9){
            Console.Write("Ders Sayısı: ");
            dersSayı = Convert.ToInt32(Console.ReadLine());
            }
            
            List<Ders> dersler = new List<Ders>();
            int sonRakam = (no % 10);
            double vizeOran;
            if (ad.Length > soyad.Length)
            {
                vizeOran = 0.3;
            }
            else if (ad.Length < soyad.Length)
            {
                vizeOran = 0.6;
            }
            else
            {
                if (sonRakam % 2 == 0)
                {
                    vizeOran = 0.35;
                }
                else
                {
                    vizeOran = 0.25;
                }
            }
            double finalOran = 1.0 - vizeOran;

            for (int i = 0; i < dersSayı; i++) 
            {
                Console.Write($"{i+1}.Ders Adı: ");
                string dersAdı = Console.ReadLine();
                Console.Write($"{i+1}.Ders Vize: ");
                int dersVize = Convert.ToInt32(Console.ReadLine());
                Console.Write($"{i+1}.Ders Final: ");
                int dersFinal = Convert.ToInt32(Console.ReadLine());
                int ortalama = Convert.ToInt32(dersVize * vizeOran + dersFinal * finalOran);
                dersler.Add(new Ders {ad = dersAdı, vize = dersVize, final = dersFinal, ort = ortalama});

            }
            

            DateTime doğumGünü = DateTime.ParseExact(tarih, "dd/MM/yyyy", new CultureInfo("tr-TR"));
            DateTime bugün = DateTime.Today;
            int yaş = bugün.Year - doğumGünü.Year;
            if (bugün.Month < doğumGünü.Month || (bugün.Month == doğumGünü.Month && bugün.Day < doğumGünü.Day)) yaş--;

            Console.WriteLine($"Sayın {ad} {soyad}, {yaş} yaşındasınız.");
            foreach(Ders ders in dersler)
            {
                Console.WriteLine($"Ders Adı: {ders.ad}, Vize Notu: {ders.vize}, Final Notu: {ders.final}, Ortalama Notu: {ders.ort} ");
            }

        }

        internal class Ders
        {
        public string ad { get; set; }
        public int vize { get; set; }
        public int final { get; set; }
        public int ort { get; set; }
        }
}
}
