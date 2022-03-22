namespace ASPNET_MongoDB_Quickstart.Models
{
    public class BankStoreDatabase : IBankStoreDatabase
    {
        public string BankCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
