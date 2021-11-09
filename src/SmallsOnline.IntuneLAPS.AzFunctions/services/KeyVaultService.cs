using System;

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace SmallsOnline.IntuneLAPS.AzFunctions.Services
{
    public class KeyVaultService: IKeyVaultService
    {
        public KeyVaultService()
        {
            DefaultAzureCredentialOptions azureCredentialOptions = new();
            azureCredentialOptions.ManagedIdentityClientId = Environment.GetEnvironmentVariable("managedIdentityClientId");

            _secretClient = new(
                new Uri(Environment.GetEnvironmentVariable("keyVaultUrl")),
                new DefaultAzureCredential(azureCredentialOptions)
            );
        }

        public SecretClient SecretClient { get => _secretClient; }

        private readonly SecretClient _secretClient;
    }
}