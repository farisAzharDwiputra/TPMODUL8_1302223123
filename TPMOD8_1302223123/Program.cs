// See https://aka.ms/new-console-template for more information

using System;
using System.Text.Json;
using static CovidConfig;
internal class Program
{
    public static void Main(string[] args)
    {
        AplikasiConfig Config = new AplikasiConfig();

        Config.UbahSatuan(); 

        Console.Write($"Berapa suhu badan anda saat ini? {Config.config.satuan_suhu} : ");
        double NilaiSuhu = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
        int lama_demam = int.Parse(Console.ReadLine());

        if (
               ((Config.config.satuan_suhu == "celcius" && NilaiSuhu >= 36.5 && NilaiSuhu <= 37.5) ||
               (Config.config.satuan_suhu == "fahrenheit" && NilaiSuhu >= 97.7 && NilaiSuhu <= 99.5)) &&
               lama_demam < Config.config.batas_hari_demam
           )
        {
            Console.WriteLine(Config.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(Config.config.pesan_ditolak);
        }

    }
}
