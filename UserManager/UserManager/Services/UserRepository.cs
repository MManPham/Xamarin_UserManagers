using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManager.DataAccess;
using UserManager.Models;

namespace UserManager.Services
{
    public class UserRepository : IDataStore<User>
    {
        public  DataContext _dbContext;

        
        public UserRepository(string dbPath)
        {
            _dbContext = new DataContext(dbPath);
        }

        public async Task<bool> AddItemAsync(User item)
        {
            try
            {
                _dbContext.Users.Add(item);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            User itemRemove = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                 _dbContext.Users.Remove(itemRemove);
                 _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;

            }

        }

        public async Task<User> GetItemAsync(string id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return user;
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            var ListUsers = await _dbContext.Users.ToListAsync().ConfigureAwait(false);
            return ListUsers;
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            _dbContext.Users.Update(item);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }
}
