using OnlineStore.Enum;
using OnlineStore.Models;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineStore.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;

        public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            this.orderRepository = orderRepository;
            this.itemRepository = itemRepository;
        }
        public Order FindById(int id)
        {
            return orderRepository.FindById(id);
        }

        public Order Create(Order order)
        {

            return orderRepository.Create(order);
        }

        public Order Update(Order order)
        {
            return orderRepository.Update(order);
        }

        public void Delete(int id)
        {
            orderRepository.Delete(id);
        }

        public List<Order> GetAll()
        {
            return orderRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return orderRepository.Exists(id);
        }

        public List<OrderItem> Checkout(int customerId, IEnumerable<CheckoutOrder> orderItems, string fullname, string phone, string deliveryAddress)
        {
            var itemDictionary = orderItems.ToDictionary(o => o.ItemId);
            var items = itemRepository.GetAll(itemDictionary.Keys);
            var order = new Order
            {
                CustomerId = customerId,
                Fullname = fullname,
                Phone = phone,
                DeliveryAddress = deliveryAddress,
                Status = OrderStatus.Default,
                OrderDate = DateTime.UtcNow
            };
            foreach (var item in items)
            {
                var quantity = itemDictionary[item.ItemId].Quantity;
                var price = item.Price;
                var orderItem = new OrderItem
                {
                    ItemId = item.ItemId,
                    Quantity = quantity,
                    Order = order,
                    UnitPrice = price,
                    Item = item
                };
                order.Total += price * quantity;
                order.OrderItems.Add(orderItem);
            }

            orderRepository.Create(order);
            return order.OrderItems.ToList();
        }
    }
}
