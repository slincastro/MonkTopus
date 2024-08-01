public interface IPublisher
{
    void Publish(Transaction message);

    void Publish(Transaction message, string queueName);
}