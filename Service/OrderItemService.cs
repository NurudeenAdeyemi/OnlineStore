using OnlineStore.Models;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }
        public OrderItem FindById(int id)
        {
            return orderItemRepository.FindById(id);
        }

        public OrderItem Create(OrderItem orderItem)
        {
            return orderItemRepository.Create(orderItem);
        }

        public OrderItem Update(OrderItem orderItem)
        {
            return orderItemRepository.Update(orderItem);
        }

        public void Delete(int id)
        {
            orderItemRepository.Delete(id);
        }

        public List<OrderItem> GetAll()
        {
            return orderItemRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return orderItemRepository.Exists(id);
        }
    }
}
