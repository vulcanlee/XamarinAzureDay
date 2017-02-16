using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Helpers;
using XFDoggy.Models;

namespace XFDoggy.Repositories
{
    /// <summary>
    /// 進行請假記錄的檔案存取功能
    /// </summary>
    public class 請假紀錄Manager
    {
        // 取得 Azure Mobile App 中的 請假紀錄 離線資料表物件
        public IMobileServiceSyncTable<LeaveRecord> 請假紀錄Table;
        // 進行同步工作的時候，產生的錯誤訊息
        public string ErrorMessage = "";

        public 請假紀錄Manager()
        {
            // 取得 請假記錄 離線資料表物件
            請假紀錄Table = MainHelper.client.GetSyncTable<LeaveRecord>();
        }

        /// <summary>
        /// 取得請假記錄清單
        /// </summary>
        /// <param name="是否要先進行同步工作"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<LeaveRecord>> GetAsync(bool 是否要先進行同步工作 = false)
        {
            ErrorMessage = "";
            try
            {
                if (是否要先進行同步工作)
                {
                    // 將本地端的異動與伺服器端的紀錄進行同步處理
                    ErrorMessage = await SyncAsync();
                }

                // 取得所有的請假記錄集合
                IEnumerable<LeaveRecord> items = await 請假紀錄Table
                    .OrderByDescending(x => x.請假日期)
                    .ToEnumerableAsync();

                return new ObservableCollection<LeaveRecord>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                ErrorMessage = string.Format(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        /// <summary>
        /// 使用 Id 鍵值進行查詢出這筆紀錄
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LeaveRecord> LookupAsync(string id)
        {
            var fooObj = await 請假紀錄Table.LookupAsync(id);
            return fooObj;
        }

        /// <summary>
        /// 進行記錄更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateAsync(LeaveRecord item)
        {
            await 請假紀錄Table.UpdateAsync(item);
        }

        /// <summary>
        /// 新增一筆紀錄
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task InsertAsync(LeaveRecord item)
        {
            await 請假紀錄Table.InsertAsync(item);
        }

        /// <summary>
        /// 刪除這筆紀錄
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task DeleteAsync(LeaveRecord item)
        {
            await 請假紀錄Table.DeleteAsync(item);
        }

        /// <summary>
        /// 進行資料同步，並且取得最新線上的紀錄
        /// </summary>
        /// <returns></returns>
        public async Task<string> SyncAsync()
        {
            var fooResult = "";
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                var fooClient = MainHelper.client;
                await fooClient.SyncContext.PushAsync();

                // 這裡可以設定要取得那些資料
                var fooK = 請假紀錄Table.Where(x => x.請假日期 > DateTime.Now.AddMonths(-3));

                await 請假紀錄Table.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "請假紀錄", fooK);
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //這裡要解決本地與伺服器端資料衝突的問題，底下是使用伺服器版本，蓋掉本機版本
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // 取消這筆本地端的資料異動，該異動紀錄將會從本地端移除
                        //await error.CancelAndDiscardItemAsync();
                    }

                    fooResult = @"Error executing sync operation. Item: {error.TableName} (" + error.Item["id"] + "). Operation discarded.";
                }
            }
            return fooResult;
        }
    }
}
