using Azure.Security.KeyVault.Secrets;

namespace SmallsOnline.IntuneLAPS.AzFunctions.Services
{
    public interface IKeyVaultService
    {
        SecretClient SecretClient { get; }
    }
}