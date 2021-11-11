using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Ddd.Core.Domain.Order.Events;
using System.Threading;

namespace Ddd.Events.Handlers.Orders
{
    public class OrderAddedEventHandler : INotificationHandler<NewOrderAddedEvent>
    {
        public OrderAddedEventHandler()
        {

        }

        public async Task Handle(NewOrderAddedEvent notification, CancellationToken cancellationToken)
        {
            string path = @"C:\Users\gwhit\Desktop\Test.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{notification.DateOccurred}: {notification.Order.CustomerName} ordered {notification.Order.OrderItems.Count} items");
            }

           
        }

        
    }
}
