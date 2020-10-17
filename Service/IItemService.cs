using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public interface IItemService
    {
        public Item FindById(int id);
        public Item Create(Item item);
        public Item Update(Item item);
        public void Delete(int id);
        public List<Item> GetAll();
        public bool Exists(int id);
        public IList<Item> Search(string searchText);
    }
}
