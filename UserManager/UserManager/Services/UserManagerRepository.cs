using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.DataAccess;
using UserManager.Models;

namespace UserManager.Services
{
    public class UserManagerRepository : IDataStore
    {
        public DataContext _dbContext;


        public UserManagerRepository(string dbPath)
        {
            _dbContext = new DataContext(dbPath);
        }

        public async Task<bool> AddUserAsync(User User)
        {
            try
            {
                _dbContext.Users.Add(User);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            User UserRemove = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                _dbContext.Users.Remove(UserRemove);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;

            }

        }

        public async Task<User> GetUserAsync(string id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            var ListUsers = await _dbContext.Users.ToListAsync().ConfigureAwait(false);
            return ListUsers;
        }

        public async Task<bool> UpdateUserAsync(User User)
        {
            _dbContext.Users.Update(User);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }


    }
}
