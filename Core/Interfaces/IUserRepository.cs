using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
         Task RegisterUserAsync(User user);
         Task<User> GetUserByEmailAsync(string email);
    }
}
