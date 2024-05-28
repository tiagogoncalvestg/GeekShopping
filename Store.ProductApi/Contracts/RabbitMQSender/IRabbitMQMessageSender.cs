using Store.RMQ.Models;

namespace Store.ProductApi.Contracts.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
