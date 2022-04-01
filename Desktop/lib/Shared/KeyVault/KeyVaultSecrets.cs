namespace Desktop.Shared
{
    public static class KeyVaultSecrets
    {
        public static string SecretBaseUrl { get; set; } = string.Empty;
        public static string AzureStorageConnectionString { get; set; } = string.Empty;
        public static string AzureSignalRConnectionString { get; set; } = string.Empty;
        public static string AzureStorageAccountName { get; set; } = string.Empty;
        public static string AzureStoragePrimaryKey { get; set; } = string.Empty;
    }
}
