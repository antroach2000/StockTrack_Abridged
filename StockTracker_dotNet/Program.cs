using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Enrichers;

namespace StockTrade.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ConfigureLogging();

			var host = CreateHostBuilder(args)
					.UseSerilog() // Add Serilog
					.Build(); // Build the Host

			if (!args.Contains("skipHost"))
				host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					var port = Environment.GetEnvironmentVariable("PORT") ?? "44360";
					var url = $"http://0.0.0.0:{port}";
					webBuilder.UseStartup<Startup>().UseUrls(url);				
				});

		public static void ConfigureLogging()
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.Enrich.With(new ThreadIdEnricher())
				.Enrich.FromLogContext()
				.CreateLogger();
		}
	}
}
