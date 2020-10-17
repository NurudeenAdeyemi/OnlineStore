using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public interface ICategoryRepository
    {
        public Category FindById(int id);

        public Category Create(Category category);

        public Category Update(Category category);

        public void Delete(int id);

        public List<Category> GetAll();

        public bool Exists(int id);
    }
}
