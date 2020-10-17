using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineStoreContext _dbContext;
        public OrderRepository(OnlineStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order FindById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public Order Create(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return order;
        }

        public void Delete(int id)
        {
            //var customer = FindById(id);
            var order = new Order
            {
                OrderId = id
            };
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.Orders.Any(e => e.OrderId == id);
        }
    }
}
