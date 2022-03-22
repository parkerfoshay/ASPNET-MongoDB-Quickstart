using ASPNET_MongoDB_Quickstart.Models;
using MongoDB.Driver;

namespace ASPNET_MongoDB_Quickstart.Services
{
    public class BankService : IBankService
    {
        private readonly IMongoCollection<Accounts> _accounts;

        public BankService(IBankStoreDatabase settings)
        {
            Console.WriteLine(settings);
            var mongoClient = new MongoClient(
            settings.ConnectionString);
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _accounts = database.GetCollection<Accounts>(GetBankCollectionName(settings));
        }

        private static string GetBankCollectionName(IBankStoreDatabase settings)
        {
            return settings.BankCollectionName;
        }

        public async Task<Accounts> CreateAccountAsync(Accounts account)
        {
            await _accounts.InsertOneAsync(account);

            return account;
        }

        public Task DeleteAccountByIdAsync(string id)
        {
             return _accounts.DeleteOneAsync(x => x.Id == id);
        }

        public Accounts GetAccountByIdAsync(string id)
        {
            return _accounts.Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task<List<Accounts>> GetAllAccountsAsync()
        {
            var results = await _accounts.FindAsync(_ => true);
            return results.ToList();
        }

        public void Update(string id, Accounts account)
        {
            var filter = Builders<Accounts>.Filter.Eq("Id", account.Id);
            _accounts.ReplaceOneAsync(filter, account, new ReplaceOptions { IsUpsert = true });
        }
    }
}
