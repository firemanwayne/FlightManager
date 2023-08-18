using Desktop.Shared;
using AirportManagement.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Desktop.Clients;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IConfiguration? config;
        IServiceProvider? provider;
        IConfigurationBuilder? builder;

        protected override void OnStartup(StartupEventArgs e)
        {
            builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            config = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            provider = services.BuildServiceProvider();           

            var mainWindow = provider.GetRequiredService<MainWindow>();

            if (mainWindow != null)
                mainWindow.Show();
        }

        void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazorWebView();

            services.AddWpfBlazorWebView();

            services.AddSingleton(sp =>
            {
                return Options.Create(new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = false,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            });

            services.AddHttpClient<FlightHttpClient>(c => c.BaseAddress = new Uri("https://localhost:7106/"));

            //services.AddKeyVaultSecrets(config);

            services.AddSingleton<MainWindow>(sp => 
            {
                return new(sp);
            });

            Resources.Add("services", services.BuildServiceProvider());
        }
    }
}
