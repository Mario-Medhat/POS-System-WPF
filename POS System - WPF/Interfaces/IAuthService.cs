using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
    }
}
