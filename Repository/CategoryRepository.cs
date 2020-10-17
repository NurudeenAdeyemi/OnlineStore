using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineStoreContext _dbContext;
        public CategoryRepository(OnlineStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category FindById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public Category Create(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            //var customer = FindById(id);
            var category = new Category
            {
                ID = id
            };
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();

        }

        public bool Exists(int id)
        {
            return _dbContext.Categories.Any(e => e.ID == id);
        }
    }
}
