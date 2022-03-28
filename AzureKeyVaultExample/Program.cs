using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AzureKeyVaultExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    var root = builder.Build();
                    var vaultName = root["KeyVault:Vault"];
                    builder.AddAzureKeyVault($"https://{vaultName}.vault.azure.net/",
                        root["KeyVault:ClientId"], root["KeyVault:ClientSecret"],
                        new PrefixKeyVaultSecretManager("AzureKeyVaultExample"));
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
    }
}