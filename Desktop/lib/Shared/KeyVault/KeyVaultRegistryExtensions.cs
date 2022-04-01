using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desktop.Shared
{
    public static partial class KeyVaultRegistryExtensions
    {
        public const string StoragePrimaryKey = "AzureStoragePrimaryKey";
        public const string StorageAccountName = "AzureStorageAccountName";
        public const string SignalRConnectionString = "AzureSignalRPrimaryConnectionString";
        public const string StoragePrimaryConnectionString = "AzureStoragePrimaryConnectionString";

        public static void AddKeyVaultSecrets(this IServiceCollection services, IConfiguration Config)
        {
            //Get Azure Key Value Secrets Base Url
            string BaseUrl = Config.GetSection("KeyVault").GetValue<string>("BaseUrl");

            KeyVaultSecrets.SecretBaseUrl = Config.GetSection("KeyVault").GetValue<string>("SecretsBaseUrl");
            KeyVaultKeys.KeyBaseUrl = Config.GetSection("KeyVault").GetValue<string>("KeysBaseUrl");

            services.AddKeyVault(o =>
            {
                o.SetVaultUri(BaseUrl);
            });

            //Get Key Vault Client for Requests
            var Client = new SecretClient(new Uri(BaseUrl), new DefaultAzureCredential());

            ///Get Key Vault Secret
            KeyVaultSecrets.AzureStorageConnectionString = Client.GetSecret(StoragePrimaryConnectionString).Value.Value;
            ///Get Key Vault Secret
            KeyVaultSecrets.AzureSignalRConnectionString = Client.GetSecret(SignalRConnectionString).Value.Value;
            ///Get Key Vault Secret
            KeyVaultSecrets.AzureStoragePrimaryKey = Client.GetSecret(StoragePrimaryKey).Value.Value;
            ///Get Key Vault Secret
            KeyVaultSecrets.AzureStorageAccountName = Client.GetSecret(StorageAccountName).Value.Value;            
        }
    }
}
