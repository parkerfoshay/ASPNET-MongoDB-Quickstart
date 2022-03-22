namespace ASPNET_MongoDB_Quickstart.Models
{
    public interface IBankStoreDatabase
    {
        string BankCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
