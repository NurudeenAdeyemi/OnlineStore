using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OnlineStoreContext _dbContext;
        public OrderItemRepository(OnlineStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderItem FindById(int id)
        {
            return _dbContext.OrderItems.Find(id);
        }

        public OrderItem Create(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
            return orderItem;
        }

        public OrderItem Update(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            _dbContext.SaveChanges();
            return orderItem;
        }

        public void Delete(int id)
        {
            //var customer = FindById(id);
            var orderItem = new OrderItem
            {
                OrderItemId = id
            };
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                _dbContext.SaveChanges();
            }
        }

        public List<OrderItem> GetAll()
        {
            return _dbContext.OrderItems.ToList();

        }


        public bool Exists(int id)
        {
            return _dbContext.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}
