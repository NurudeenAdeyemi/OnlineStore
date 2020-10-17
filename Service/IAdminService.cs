using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public interface IAdminService
    {
        public Admin FindById(int id);
        public Admin Create(Admin admin);
        public Admin Update(Admin admin);
        public void Delete(int id);
        public List<Admin> GetAll();
        public bool Exists(int id);
        public Admin Login(string email, string password);
    }
}
