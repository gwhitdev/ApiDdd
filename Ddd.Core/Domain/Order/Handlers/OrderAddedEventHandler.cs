using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Ddd.Core.Domain.Order.Events;
using System.Threading;

namespace Ddd.Core.Domain.Order.Handlers
{
    public class OrderAddedEventHandler : INotificationHandler<NewOrderAddedEvent>
    {
        public OrderAddedEventHandler()
        {

        }

        public async Task Handle(NewOrderAddedEvent notification, CancellationToken cancellationToken)
        {
            string path = @"/users/gareth/Desktop/Test.txt";
            await using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{notification.DateOccurred}: {notification.Order.CustomerName} ordered {notification.Order.OrderItems.Count} items");
            }
        }

        
    }
}
