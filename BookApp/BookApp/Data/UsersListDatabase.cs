using BookApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Data
{
    public class UsersListDatabase
    {
        readonly SQLiteAsyncConnection _database2;
        public UsersListDatabase(string dbPath)
        {
            _database2 = new SQLiteAsyncConnection(dbPath);
            _database2.CreateTableAsync<User>().Wait();
        }
        public Task<List<User>> GetUserListsAsync()
        {
            return _database2.Table<User>().ToListAsync();
        }
        public Task<User> GetUserListAsync(int id)
        {
            return _database2.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<User> LoginUser(string email,string password)
        {
            return _database2.Table<User>().Where(u => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserListAsync(User ulist)
        {
            if (ulist.Id !=0)
            {
                return _database2.UpdateAsync(ulist);
            } 
            else
            {
                return _database2.InsertAsync(ulist);
            }
        }
        public Task<int> DeleteUserListAsync(User ulist)
        {
            return _database2.DeleteAsync(ulist);
        }

    }
}
