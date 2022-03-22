using ASPNET_MongoDB_Quickstart.Models;

namespace ASPNET_MongoDB_Quickstart.Services
{
    public interface IBankService
    {
        Task<List<Accounts>> GetAllAccountsAsync();
        Accounts GetAccountByIdAsync(string id);
        Task<Accounts> CreateAccountAsync(Accounts account);
        void Update(string id, Accounts account);
        Task DeleteAccountByIdAsync(string id);
    }
}
