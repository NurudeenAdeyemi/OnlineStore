using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly OnlineStoreContext _dbContext;
        public ItemRepository(OnlineStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Item FindById(int id)
        {
            return _dbContext.Items.Find(id);
        }

        public Item Create(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Item Update(Item item)
        {
            _dbContext.Items.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            //var customer = FindById(id);
            var item = new Item
            {
                ItemId = id
            };
            if (item != null)
            {
                _dbContext.Items.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public List<Item> GetAll()
        {
            return _dbContext.Items.ToList();

        }

        public List<Item> GetAll(IEnumerable<int> itemIds)
        {
            return _dbContext.Items.Where(item => itemIds.Contains(item.ItemId)).ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.Items.Any(e => e.ItemId == id);
        }

        public IList<Item> Search(string searchText)
        {
            return _dbContext.Items.Where(item => EF.Functions.Like(item.ItemName, $"%{searchText}%")).ToList();
        }
    }
}
