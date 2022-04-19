using BookApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Data
{
    public class BooksListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public object Search { get; private set; }

        public BooksListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
            _database.CreateTableAsync<Review>().Wait();
            _database.CreateTableAsync<ListReview>().Wait();
        }
        public Task<List<Book>> GetBookListsAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }
        public Task<Book> GetBookListAsync(int id)
        {
            return _database.Table<Book>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveBookListAsync(Book blist)
        {
            if (blist.ID != 0)
            {
                return _database.UpdateAsync(blist);
            }
            else
            {
                return _database.InsertAsync(blist);
            }
        }
        public Task<int> DeleteBookListAsync(Book blist)
        {
            return _database.DeleteAsync(blist);
        }
        public Task<Book> SearchBookAsync(string search)
        {
            return _database.Table<Book>().Where(c => c.Title.ToLower().Contains(search) || c.Author.ToLower().Contains(search)).FirstOrDefaultAsync();
        }
        

        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }
        public Task<int> SaveListReviewAsync(ListReview listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Review>> GetListReviewsAsync(int reviewid)
        {
            return _database.QueryAsync<Review>(
            "select R.ID, R.Description from Review R"
            + " inner join ListReview LR"
            + " on R.ID = LR.ReviewID where LR.BookID = ?",
            reviewid);
        }
    }
}
