using System;
using System.Text.Json;

	public class CovidConfig
	{
		public string satuan_suhu { get; set; }
		public int batas_hari_demam { get; set; }
		public string pesan_ditolak { get; set; }
		public string pesan_diterima { get; set; }

		public CovidConfig() { }
	}

	public class AplikasiConfig
	{
		public CovidConfig config;
		private const string filePath = "C:\\Users\\LENOVO\\Desktop\\semester 4\\Kontruksi Perangkat Lunak (KPL)\\TPMOD8_1302223123\\TPMOD8_1302223123\\covid_config.json";
		
		public AplikasiConfig()
		{
			try
			{
				ReadConfigJson();
			}
			catch 
			{
				Default();
				PrintConfig();
			}
		}

		public void Default()
		{
			config = new CovidConfig();

			config.satuan_suhu = "celcius";
			config.batas_hari_demam = 14;
			config.pesan_ditolak = "Anda tidak diperbolehkan masuk kedalam gedung ini";
			config.pesan_diterima = "Anda dipersilahkan untuk masuk kedalam gedung ini";
		}

		public void  ReadConfigJson()
		{
			string configDataJson = File.ReadAllText(filePath);
			config = JsonSerializer.Deserialize<CovidConfig>(configDataJson);

		}

		public void PrintConfig()
		{
			JsonSerializerOptions Option = new JsonSerializerOptions()
			{
				WriteIndented = true,
			};

			string output = JsonSerializer.Serialize(config);
			File.WriteAllText(filePath,output);

		}

		public void UbahSatuan ()
		{
	
		Console.WriteLine("Apa satuan Suhu yang ingin kamu inputkan : ");
        string input = Console.ReadLine();

        if (input == "celcius")
			{
				this.config.satuan_suhu = "celcius";
			}
			else if (input == "fahrenheit")
			{
				this.config.satuan_suhu = "fahrenheit";
			}

			string output = JsonSerializer.Serialize(config);
			File.WriteAllText(filePath,output);	
	}
}
