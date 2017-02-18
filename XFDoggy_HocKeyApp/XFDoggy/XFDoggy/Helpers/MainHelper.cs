using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Models;
using XFDoggy.Repositories;

namespace XFDoggy.Helpers
{
    public static class MainHelper
    {
        /// <summary>
        /// 指向 Azure Mobile App 服務的主要網址
        /// </summary>
        public static string MainURL = "https://xamarinazureday.azurewebsites.net";
        /// <summary>
        /// Azure Mobile App 線上版本的用戶端
        /// </summary>
        public static MobileServiceClient client = new MobileServiceClient(MainURL);
        /// <summary>
        /// 設定離線資料庫的檔案名稱
        /// </summary>
        public static string offlineDbPath = @"localstore.db";
        /// <summary>
        /// Azure Mobile App 離線版本的SQLite
        /// </summary>
        public static MobileServiceSQLiteStore store = new MobileServiceSQLiteStore(offlineDbPath);

        public static 請假紀錄Manager 請假紀錄Manager = new 請假紀錄Manager();

        /// <summary>
        /// 進行 Azure Mobile App 的離線資料庫初始化動作
        /// </summary>
        public static void AzureMobileOfflineInit()
        {
            //取得Azure Mobile App 線上版本的用戶端
            var store = MainHelper.store;
            // 定義要用到的離線資料表
            store.DefineTable<LeaveRecord>();
            // 進行離線資料庫初始化
            MainHelper.client.SyncContext.InitializeAsync(store);
        }
    }
}
