using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public interface IAdminRepository
    {
        public Admin FindById(int id);
        public Admin Create(Admin admin);
        public Admin Update(Admin admin);
        public void Delete(int id);
        public List<Admin> GetAll();
        public bool Exists(int id);
        public Admin FindByEmail(string email);
    }
}
