using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.RMQ.Models
{
    public class BaseMessage
    {
        public BaseMessage()
        {
            MessageId = Guid.NewGuid();
            MessageCreated = DateTime.Now;
        }
        public Guid MessageId { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
