using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;

namespace UserManager.Services
{
    public interface IDataStore
    {
        //User
        Task<bool> AddUserAsync(User User);

        Task<bool> UpdateUserAsync(User User);

        Task<bool> DeleteUserAsync(string id);

        Task<User> GetUserAsync(string id);

        Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false);
        




    }
}
