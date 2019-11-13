using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using System.Threading.Tasks;



namespace TShirtKings
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TShirtTable>().Wait();
        }

        public Task<List<TShirtTable>> GetItemsAsync()
        {
            return database.Table<TShirtTable>().ToListAsync();
        }

        public Task<List<TShirtTable>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TShirtTable>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TShirtTable> GetItemAsync(int id)
        {
            return database.Table<TShirtTable>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TShirtTable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TShirtTable item)
        {
            return database.DeleteAsync(item);
        }
    }
}
