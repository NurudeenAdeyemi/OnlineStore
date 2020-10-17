using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public interface ICategoryService
    {
        public Category FindById(int id);

        public Category Create(Category category);

        public Category Update(Category category);

        public void Delete(int id);

        public List<Category> GetAll();

        public bool Exists(int id);
    }
}
