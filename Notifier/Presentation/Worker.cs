// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 2.0.
// Copyright (c) 2007-2020 VMware, Inc.

namespace rabbitmq_backgroundservice;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Worker : BackgroundService
{
    private const string _queueName = "toNotify";
    private readonly TimeSpan _stoppingCheckInterval = TimeSpan.FromSeconds(5);
    private readonly ILogger<Worker> _logger;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly EventingBasicConsumer _consumer;
    private readonly string _consumerTag;
    private readonly int _retryCount = 20;
    private readonly int _retryDelay = 10000;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        int attempts = 0;

        var factory = new ConnectionFactory {
            HostName = "rabbitmq",
            UserName = "user",
            Password = "password"
        };

        while (true)
        {
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: "testQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                _consumer = new EventingBasicConsumer(_channel);
                _consumer.Received += ReceivedHandler;

                _consumerTag = _channel.BasicConsume(_queueName, false, _consumer);
                break;
            }
            catch (Exception ex)
            {
                attempts++;
                if (attempts >= _retryCount)
                {
                    Console.WriteLine("Failed to connect after several attempts: " + ex.Message);
                    break;
                }
                Console.WriteLine($"Attempt {attempts} failed, retrying in {_retryDelay/1000} seconds...");
                Thread.Sleep(_retryDelay);
            }
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (_connection)
        using (_channel)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(_stoppingCheckInterval, stoppingToken);
            }

            _logger.LogInformation("Worker STOPPING at: {time}", DateTimeOffset.Now);
            _channel.BasicCancel(_consumerTag);
        }
    }

    private void ReceivedHandler(object? sender, BasicDeliverEventArgs ea)
    {
        var tag = ea.DeliveryTag;
        _logger.LogInformation("-------------------Received message. tag: {tag}  at: {time}-------------", tag, DateTimeOffset.Now);
        _channel.BasicAck(tag, false);
    }
}