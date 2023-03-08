using System.Reflection.Metadata.Ecma335;

namespace uygulamaSinavi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exam:
            KarsilamaMesajiOlustur(out string cizgi1, out string cizgi2);
            AdimMesafesiAl(cizgi1, cizgi2, out double adimMesafesi);
            double girilenAdimSayisi = OrtalamaAdimSayisiniOgren(cizgi1, cizgi2);
            KosuMesafesiniOgren(cizgi1, cizgi2, out double kosuGirilenSaat, out double kosuGirilenDakika);
            TumBilesenleriHesaplayipYazdir(cizgi1, cizgi2, adimMesafesi, girilenAdimSayisi, kosuGirilenSaat, kosuGirilenDakika);
            #endregion
        }
        #region Solution for A Exam:
        static void KarsilamaMesajiOlustur(out string cizgi1, out string cizgi2)  //Konsol Ekranindaki Karsilama MesajLarinin Olusturuldugu Kisim
        {
            cizgi1 = "<<<<<<<<<<";
            cizgi2 = ">>>>>>>>>>";
            Console.WriteLine($"{cizgi1}Gunluk Kosu Mesafesi Olcer Uygulamasina Hosgeldiniz{cizgi2}");
        }
        static void AdimMesafesiAl(string cizgi1, string cizgi2, out double adimMesafesi)  //Kullanici Girdigi Degerlere Sinirlandirilma Getirilerek Ulasilacak Verilerin Daha Makul Bir Seviyede Olmasi Goz Onune Alinmistir
        {
            for (; ; )
            {
                Console.Write($"{cizgi1}{cizgi2}Ortalama Olarak Bir Adiminizin Uzunlugunu Giriniz('cm' Olarak)(0-100 ex.):");
                bool adimMesafesiIsDbl = double.TryParse(Console.ReadLine(), out double adim);
                if (adimMesafesiIsDbl)
                {
                    if (adim > 0 && adim <= 100)
                    {
                        Console.WriteLine($"{cizgi1}Gerekli Islemleri Yapmak Uzere Yonlendiriliyorsunuz{cizgi2}\n");
                        adimMesafesi = adim;
                        break;
                    }
                    else if (adim > 100)
                    {
                        Console.WriteLine($"Lutfen Bu Uygulamayi Ciddiye Alip INSANI Olcutlerde Bir Rakamsal Veri Girisi Saglayiniz!!! ");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{cizgi1}{cizgi1}Adim Sayiniz Negatif Ya da Sifir Gibi Bir Deger Olamaz!!!{cizgi2}{cizgi2}");
                        continue;
                    }
                }
                else  // Kullaniciya Klavyeden Herhangi Bir Girdi Alinmasi Durumunda Istenen Girdi Tipinde Degilse Sonuna Kadar Zorlayip En Kotu Durumda Programi Kapatmayi Secenek Olarak Sunmaktadir   
                {
                    Console.WriteLine($"{cizgi1}{cizgi2} Lutfen CM Cinsinden Bir Sayisal Deger Giriniz{cizgi1}{cizgi2}");
                    bool alinanCevap = DevamEtmekIstiyorMuyuAl(cizgi1, cizgi2);
                    adimMesafesi = 0;
                    if (alinanCevap) continue;
                    else
                    {
                        Console.WriteLine($"{cizgi1}Isteginiz Uzere Isleminiz Sonlandiriliyor{cizgi2}");
                        break;
                    }
                }
            }


        }
        static bool DevamEtmekIstiyorMuyuAl(string cizgi1, string cizgi2)
        {
            bool cevap = false;
            Console.WriteLine($"Isleminize Devam Etmek Istiyor Musunuz(Evet / Hayir) ");
            string devamMiCevabi = Console.ReadLine();
            devamMiCevabi.ToLower();
            if (devamMiCevabi == "evet")
            {
                cevap = true;
            }
            else
            {
                cevap = false;
            }
            return cevap;
        }
        static double OrtalamaAdimSayisiniOgren(string cizgi1, string cizgi2)
        {  /*Bu Blok Icerisinde Yapilan Girdi Degeri Dogru Olana Kadar Kendisini Tekrar Ettirip Bu Noktada Kullaniciya Tekrardan Islemleri Sonlandırma
            firsati verilmektedir.*/
            for (; ; )
            {
                double adimSayisi = 0;
                Console.Write($"{cizgi1}Yaklasik 1 Dakikadaki Koşulan Ortalama Adim Sayisini Giriniz(0-200): ");
                bool adimSayisiIsInt = double.TryParse(Console.ReadLine(), out adimSayisi);
                if (adimSayisiIsInt && (adimSayisi > 0) && adimSayisi <= 200)
                {
                    Console.WriteLine($"{cizgi1}Gerekli Veri Aliniyor{cizgi2}\n");
                    return adimSayisi;
                    break;
                }
                else if (adimSayisiIsInt && (adimSayisi > 200))
                {
                    Console.WriteLine("Bir USAIN BOLT Degilsiniz. Ruya Gormeyi Birakip Gercekci Veriler Giriniz!!!");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{cizgi1}Lutfen Gireceginiz Deger Rakamsal Bir Deger ve Pozitif Deger Olmalidir!!!{cizgi2}");
                    Console.Write("Islemlere Devam Etmek Istiyor Musunuz(Evet / Hayir):");
                    string islemCevabi = Console.ReadLine();
                    islemCevabi.ToLower();
                    if (islemCevabi == "evet") continue;
                    else
                    {
                        Console.WriteLine($"{cizgi1}Yanlis Bir Komut Vermis Olabilirsiniz Ya da Cikmak Istediginiz Icin Cikis ISlemi Yapiliyor{cizgi2}");
                        Console.WriteLine($"{cizgi1}{cizgi1}PROGRAM SONLANDIRILIYOR{cizgi2}{cizgi2}");
                        return 0;
                        break;
                    }
                }
            }
        }
        static void KosuMesafesiniOgren(string cizgi1, string cizgi2, out double kosuGirilenSaat, out double kosuGirilenDakika)
        { //Kosu Mesafesi Girdisi Kullanicidan Dogru Alinana Kadar Kullanici Dogru Veriyi Girmesi Icin Zorlamak Uzere Olusturulmus Blok Yapilari
            for (; ; )
            {
                Console.Write("Kosu Mesafeniz 1 Saatin Uzerinde Mi?(Evet / Hayir):");
                string kosuMesafesiCevabi = Console.ReadLine();
                kosuMesafesiCevabi.ToLower();
                if (kosuMesafesiCevabi == "evet")
                {
                    kosuGirilenSaat = KosuMesafesiSaatiniOgren(cizgi1, cizgi2);
                    kosuGirilenDakika = KosuMesafesiDakikasiniOgren(cizgi1, cizgi2);
                    break;
                }
                else
                {
                    Console.Write($"Kosu Mesafeniz 1 Saatin Altinda Mi(Evet / Hayir):");
                    string kosuMesafesiCevabiVarMi = Console.ReadLine();
                    kosuMesafesiCevabiVarMi.ToLower();
                    if (kosuMesafesiCevabiVarMi == "evet")
                    {
                        kosuGirilenSaat = 0;
                        kosuGirilenDakika = KosuMesafesiDakikasiniOgren(cizgi1, cizgi2);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{cizgi1}Kosu Mesafesini Bir Deger Olarak Girmek Zorundasiniz!!{cizgi2}");
                        continue;
                    }
                }
            }

        }
        static double KosuMesafesiSaatiniOgren(string cizgi1, string cizgi2)
        { //Kosu Mesafesi Saati Girdisi Kullanicidan Dogru Alinana Kadar Kullanici Dogru Veriyi Girmesi Icin Zorlamak Uzere Olusturulmus Blok Yapilari
            for (; ; )
            {
                double kosuSaati;
                Console.Write("Kosu Mesafenizi Saat Olarak Giriniz(1 - 6 Araliginda): ");
                bool kosuSaatiIsDbl = double.TryParse(Console.ReadLine(), out kosuSaati);
                if (kosuSaatiIsDbl)
                {
                    if (kosuSaati >= 1 && kosuSaati <= 6)
                    {
                        return kosuSaati;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{cizgi1}Gireceginiz Deger 0'dan Buyuk ve Insani Degerlere Gore 6 veya 6'dan Kucuk Olmalidir!!{cizgi2}");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"{cizgi1}Kosu Saatini Sayisal Bir Deger Olarak Giriniz!!{cizgi2}");
                    continue;
                }
            }
        }
        static double KosuMesafesiDakikasiniOgren(string cizgi1, string cizgi2)
        { //Kosu Mesafesi Dakikasi Girdisi Kullanicidan Dogru Alinana Kadar Kullanici Dogru Veriyi Girmesi Icin Zorlamak Uzere Olusturulmus Blok Yapilari
            for (; ; )
            {
                double kosuDakikasi;
                Console.Write("Kosu Mesafenizi Dakika Olarak Giriniz(0 - 60 Araliginda): ");
                bool kosuSaatiIsDbl = double.TryParse(Console.ReadLine(), out kosuDakikasi);
                if (kosuSaatiIsDbl)
                {
                    if (kosuDakikasi > 0 && kosuDakikasi < 60)
                    {
                        return kosuDakikasi;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{cizgi1}Gireceginiz Deger 0'dan Buyuk ve 60'dan Kucuk Olmalidir!!{cizgi2}");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"{cizgi1}Kosu Saatini Sayisal Bir Deger Olarak Giriniz!!{cizgi2}");
                    continue;
                }
            }
        }
        static void TumBilesenleriHesaplayipYazdir(string cizgi1, string cizgi2, double adimMesafesi, double girilenAdimSayisi, double kosuGirilenSaat, double kosuGirilenDakika) //Kullanici Tarafindan Girilen Verilerin Elde Edilip Tek Bir Metod Catisi Altinda Hesaplanarak Geri Bildirim Olarak Kullaniciya Sunulan Metod Blogu
        {
            string cizgi3 = "*****";
            double toplamSonuc = (adimMesafesi * girilenAdimSayisi * kosuGirilenSaat * 60) + (adimMesafesi * girilenAdimSayisi * kosuGirilenDakika);
            Console.WriteLine($"{cizgi3}{cizgi3}Toplam Kosu Mesafeniz;\n\tCm OLARAK:{toplamSonuc} cm' dir.\n\tM  Olarak:{toplamSonuc / 100} m' dir.\n\tKm Olarak:{toplamSonuc / 1000000} km' dir.");
        }

        #endregion
    }
}
