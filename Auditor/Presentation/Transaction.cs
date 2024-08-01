using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Transaction
{
        [BsonElement("Id")]
        public Guid Id { get; set; }

        [BsonElement("CorrelationId")]
        public Guid CorrelationId { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Payload")]
        public string Payload { get; set; }
}