using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, (string, double, int)> urunler = new Dictionary<int, (string, double, int)>
    {
        { 1, ("Çikolata", 5.0, 10) },
        { 2, ("Cips", 7.5, 8) },
        { 3, ("Kola", 10.0, 15) },
        { 4, ("Su", 2.5, 20) },
        { 5, ("Sandviç", 12.0, 5) }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== OTOMAT SİSTEMİ ===");
            Console.WriteLine("1. Ürünleri Görüntüle");
            Console.WriteLine("2. Ürün Satın Al");
            Console.WriteLine("3. Çıkış");
            Console.Write("Seçiminizi yapın: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    UrunleriGoster();
                    break;
                case "2":
                    UrunSatinAl();
                    break;
                case "3":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    PromptContinue();
                    break;
            }
        }
    }

    static void UrunleriGoster()
    {
        Console.WriteLine("\n=== MEVCUT ÜRÜNLER ===");
        foreach (var urun in urunler)
        {
            Console.WriteLine($"{urun.Key}. {urun.Value.Item1} - {urun.Value.Item2:C} (Stok: {urun.Value.Item3})");
        }
        PromptContinue();
    }

    static void UrunSatinAl()
    {
        UrunleriGoster();

        Console.Write("\nSatın almak istediğiniz ürün numarasını girin: ");
        if (int.TryParse(Console.ReadLine(), out int urunNo) && urunler.ContainsKey(urunNo))
        {
            var urun = urunler[urunNo];
            if (urun.Item3 > 0)
            {
                Console.WriteLine($"\n{urun.Item1} fiyatı: {urun.Item2:C}");
                Console.Write("Ödeme yapacağınız tutarı girin: ");

                if (double.TryParse(Console.ReadLine(), out double odeme))
                {
                    if (odeme >= urun.Item2)
                    {
                        double paraUstu = odeme - urun.Item2;
                        urunler[urunNo] = (urun.Item1, urun.Item2, urun.Item3 - 1);
                        Console.WriteLine($"\nTeşekkürler! {urun.Item1} aldınız. Para üstünüz: {paraUstu:C}");
                    }
                    else
                    {
                        Console.WriteLine("\nYetersiz ödeme. Lütfen tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine("\nGeçersiz ödeme tutarı.");
                }
            }
            else
            {
                Console.WriteLine("\nBu ürün stokta kalmadı.");
            }
        }
        else
        {
            Console.WriteLine("\nGeçersiz ürün numarası.");
        }
        PromptContinue();
    }

    static void PromptContinue()
    {
        Console.WriteLine("\nDevam etmek için bir tuşa basın...");
        Console.ReadKey();
    }
}
