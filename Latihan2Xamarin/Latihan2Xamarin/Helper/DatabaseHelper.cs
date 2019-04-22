using Latihan2Xamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Latihan2Xamarin.Helper
{
    public class DatabaseHelper
    {
        private SQLiteAsyncConnection database;
        private static DatabaseHelper instance;

        public static DatabaseHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Latihan2Xamarin.db3");
                    instance = new DatabaseHelper(path);
                }
                return instance;
            }
        }

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Sale>().Wait();
        }

        public Task<List<Sale>> GetSalesAsync()
        {
            return database.Table<Sale>().ToListAsync();
        }

        public Task<Sale> GetSaleAsync(int id)
        {
            return database.Table<Sale>().Where(item => item.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> DeteleSaleAsync(Sale item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> SaveItemAsync(Sale item)
        {
            if (item.ID != 0)
                return database.UpdateAsync(item);
            else
                return database.InsertAsync(item);
        }

    }
}
