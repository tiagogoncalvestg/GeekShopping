﻿using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using Store.ProductApi.Contracts.RabbitMQSender;
using Store.ProductApi.Models.Dtos;
using Store.RMQ.Models;
using System.Text;
using System.Text.Json;

namespace Store.ProductApi.Models
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostName = "127.0.0.1";
            _password = "guest";
            _userName = "guest";
        }
        public void SendMessage(BaseMessage message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };

            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            byte[] body = GetMessageAsByteArray(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true                
            };
            var json = JsonSerializer.Serialize<ProductDto>((ProductDto)message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
    }
}
