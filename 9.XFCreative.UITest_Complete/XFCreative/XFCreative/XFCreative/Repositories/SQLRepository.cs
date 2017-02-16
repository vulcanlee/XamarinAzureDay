using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCreative.Services;

namespace XFCreative.Repositories
{
    public class SQLRepository<T> where T : class, new()
    {
        static object locker = new object();
        public string DBPath { get; set; }
        //public SQLiteConnection database;
        public SQLiteAsyncConnection databaseAsync;
        public SQLRepository()
        {
            databaseAsync = DependencyService.Get<ISQLite>().GetConnectionAsync();
            databaseAsync.CreateTableAsync<T>().Wait(); ;
        }

        #region 非同步的 SQLiteAsyncConnection 用法
        public async Task<List<T>> GetAllAsync()
        {
            return await databaseAsync.Table<T>().ToListAsync();
        }

        public async Task<int> InsertAsync(T item)
        {
            return await databaseAsync.InsertAsync(item);
        }

        public async Task<int> UpdateAsync(T item)
        {
            return await databaseAsync.UpdateAsync(item);
        }

        public async Task<int> DeleteAsync(T item)
        {
            return await databaseAsync.DeleteAsync(item);
        }

        #endregion
    }
}
