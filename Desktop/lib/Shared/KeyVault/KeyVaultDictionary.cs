using Activu.KeyVault.Interfaces;
using System.Collections.Concurrent;

namespace Desktop.Shared
{
    public static class KeyVaultDictionary
    {
        public static ConcurrentDictionary<string, ISecret> Secrets { get; } = new ConcurrentDictionary<string, ISecret>();

        public static void AddSecret(string Key, ISecret Secret)
        {
            Secrets.AddOrUpdate(Key, Secret, (k, v) => Secret);
        }
    }
}
