using MongoDB.Driver;
using System;

public class MongoStorer
{
    private readonly IMongoCollection<Transaction> _transactionsCollection;

    public MongoStorer(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _transactionsCollection = database.GetCollection<Transaction>(collectionName);
    }

    public void InsertTransaction(Transaction transaction)
    {
        
        _transactionsCollection.InsertOne(transaction);
    }
}
