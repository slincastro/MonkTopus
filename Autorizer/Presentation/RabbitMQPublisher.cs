using System;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

public class RabbitMQPublisher
{
    public void Publish(Transaction transaction)
    {
        var queueName = transaction.Next;
        try
        {
    
        var factory = new ConnectionFactory()
                                        {
                                            HostName = "rabbitmq",
                                            UserName = "user",
                                            Password = "password"
                                        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {

            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            var message = JsonConvert.SerializeObject(transaction);
            var body = Encoding.UTF8.GetBytes(message);


            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }}
        catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
    }
}
