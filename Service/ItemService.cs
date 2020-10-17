using OnlineStore.Models;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        public Item FindById(int id)
        {
            return itemRepository.FindById(id);
        }

        public Item Create(Item item)
        {
            return itemRepository.Create(item);
        }

        public Item Update(Item item)
        {
            return itemRepository.Update(item);
        }

        public void Delete(int id)
        {
            itemRepository.Delete(id);
        }

        public List<Item> GetAll()
        {
            return itemRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return itemRepository.Exists(id);
        }

        public IList<Item> Search(string searchText)
        {

            return itemRepository.Search(searchText);
        }
    }
}
