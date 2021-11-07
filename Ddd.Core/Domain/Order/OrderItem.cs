using Ddd.Core.Base;

namespace Ddd.Core.Domain.Order
{
    public class OrderItem : BaseEntity
    {
        public string ItemName { get; private set; }
        public OrderItem(string itemName)
        {
            ItemName = itemName;
        }
    }
}
