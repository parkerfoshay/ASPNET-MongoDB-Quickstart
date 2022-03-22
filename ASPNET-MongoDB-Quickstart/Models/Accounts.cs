using MongoDB.Bson.Serialization.Attributes;

namespace ASPNET_MongoDB_Quickstart.Models
{
    public class Accounts
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("account_id")]
        public string AccountId { get; set; } = String.Empty;
        [BsonElement("account_holder")]
        public string AccountHolder { get; set; } = String.Empty;
        [BsonElement("account_type")]
        public string AcountType { get; set; } = String.Empty;
        [BsonElement("balance")]
        public double Balance { get; set; } 
        [BsonElement("transfers_complete")]
        public string[] TransfersCompleted { get; set; } = Array.Empty<string>();
    }
}
