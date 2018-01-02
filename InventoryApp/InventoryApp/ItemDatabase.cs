using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryApp
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemAsync()
        {
            return database.Table<Item>().ToListAsync();
        }



        public Task<Item> GetItemAsync(int id)
        {
            return database.Table<Item>().Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ItemId == 0)
            {
                return database.InsertAsync(item);
            }
            else
            {
                return database.UpdateAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }
}
