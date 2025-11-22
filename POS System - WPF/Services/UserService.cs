using POS_System___WPF.Models;
using POS_System___WPF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<List<User>> GetAllUsers() => _repo.GetAllAsync();

        public Task AddUser(User p) => _repo.AddAsync(p);

        public Task DeleteUser(int id) => _repo.DeleteAsync(id);

        public Task UpdateUser(User p) => _repo.UpdateAsync(p);
    }
}
