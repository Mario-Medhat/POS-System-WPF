using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllUsers();
    }
}
