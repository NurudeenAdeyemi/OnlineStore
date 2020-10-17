using OnlineStore.Models;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        public Admin FindById(int id)
        {
            return adminRepository.FindById(id);
        }

        public Admin Create(Admin admin)
        {
            return adminRepository.Create(admin);
        }

        public Admin Update(Admin admin)
        {
            return adminRepository.Update(admin);
        }

        List<Admin> IAdminService.GetAll()
        {
            return adminRepository.GetAll();
        }

        public void Delete(int id)
        {
            adminRepository.Delete(id);
        }

        public bool Exists(int id)
        {
            return adminRepository.Exists(id);
        }

        public Admin Login(string email, string password)
        {
            var user = adminRepository.FindByEmail(email);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }
    }
}
