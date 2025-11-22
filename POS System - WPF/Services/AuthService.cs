using POS_System___WPF.Models;
using POS_System___WPF.Repositories;
using POS_System___WPF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
    }

    internal class AuthService : IAuthService
    {
        UserRepository _userRepository;
        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Login(string username, string password)
        {
            List<User> users = await _userRepository.GetAllUsers();

            return users.Any(u =>
                string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) // has the same username --(not case sensitive)--
                && u.Password == password // has the same password --(Case Sensitive)--
                );
        }
    }
}
