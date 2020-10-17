using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public interface IOrderRepository
    {
        public Order FindById(int id);

        public Order Create(Order order);

        public Order Update(Order order);

        public void Delete(int id);

        public List<Order> GetAll();

        public bool Exists(int id);
    }
}
