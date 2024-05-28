using Store.RMQ.Models;

namespace Store.RMQ;

public interface IMessageBus
{    
    Task PublicMessage(BaseMessage message, string queueName);
}
