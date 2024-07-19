using System;
using System.Text;
using RabbitMQ.Client;

public class RabbitMQPublisher
{
    public void Publish()
    {

        try
        {
            Console.WriteLine(" Hola que hace ....");
        var factory = new ConnectionFactory()
                                        {
                                            HostName = "rabbitmq",
                                            UserName = "user",
                                            Password = "password"
                                        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {

            channel.QueueDeclare(queue: "toAutorize",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);


            channel.BasicPublish(exchange: "",
                                 routingKey: "testQueue",
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
