using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public interface IOrderService
    {
        public Order FindById(int id);
        public Order Create(Order order);

        public Order Update(Order order);

        public void Delete(int id);

        public List<Order> GetAll();

        public bool Exists(int id);
        List<OrderItem> Checkout(int customerId, IEnumerable<CheckoutOrder> orderItems, string fullname, string phone, string deliveryAddress);
    }
}
