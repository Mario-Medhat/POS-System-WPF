using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
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

        public Task<IReadOnlyList<User>> GetAllUsers() => _repo.ListAsync();

        public Task AddUser(User u) => _repo.AddAsync(u);

        public Task DeleteUser(User u) => _repo.DeleteAsync(u);

        public Task UpdateUser(User u) => _repo.UpdateAsync(u);
    }
}
