using MongoDB.Bson.Serialization.Attributes;

namespace ASPNET_MongoDB_Quickstart.Models
{
    public class Transfers
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("transfer_id")]
        public string TransferId { get; set; } = String.Empty;
        [BsonElement("to_account")]
        public string ToAccount { get; set; } = String.Empty;
        [BsonElement("from_account")]
        public string FromAccount { get; set; } = String.Empty;
        [BsonElement("amount")]
        public int Amount { get; set; }
        [BsonElement("memo")]
        public string Memo { get; set; } = String.Empty;
    }
}
