using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Transaction
{
        public Guid Id { get; set; }
        
        [BsonElement("transactionId")]
        public Guid TransactionId { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Payload")]
        public string Payload { get; set; }


}