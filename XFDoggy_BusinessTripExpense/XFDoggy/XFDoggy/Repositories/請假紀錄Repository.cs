using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Models;

namespace XFDoggy.Repositories
{
    /// <summary>
    /// 進行請假記錄的檔案存取 Repository
    /// </summary>
    class 請假紀錄Repository
    {
        public List<請假紀錄項目> 請假紀錄 { get; set; }
        string Repository資料夾名稱 = "Repositories";
        string Repository檔案名稱 = "請假紀錄Repository.dat";
        IFile file;

        /// <summary>
        /// 從檔案中讀取資料出來
        /// </summary>
        /// <returns></returns>
        public async Task Read()
        {
            // 取得這個應用程式在這台裝置下的本機目錄
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            // 開啟或建立指定資料夾，用於儲存資料之用
            IFolder folder = await rootFolder.CreateFolderAsync(Repository資料夾名稱,
                CreationCollisionOption.OpenIfExists);

            var fooCheck = await folder.CheckExistsAsync(Repository檔案名稱);
            if (fooCheck == ExistenceCheckResult.FileExists)
            {
                // 這個檔案存在
                file = await folder.GetFileAsync(Repository檔案名稱);
                // 讀取所有 Json 資料出來
                var fooReadContent = await file.ReadAllTextAsync();
                請假紀錄 = JsonConvert.DeserializeObject<List<請假紀錄項目>>(fooReadContent);
                if (請假紀錄 == null)
                {
                    請假紀錄 = new List<請假紀錄項目>();
                }
            }
            else
            {
                // 這個檔案不存在
                // 設定預設展示用的資料紀錄
                請假紀錄 = new List<請假紀錄項目>();
                請假紀錄.Add(new 請假紀錄項目
                {
                    ID = Guid.NewGuid().ToString(),
                    申請人 = "",
                    假別 = "特休假",
                    請假日期 = DateTime.Now.AddDays(+3),
                    開始時間 = new TimeSpan(9, 0, 0),
                    請假時數 = 8,
                    請假理由 = "旅遊",
                    職務代理人 = "王小明",
                });
                請假紀錄.Add(new 請假紀錄項目
                {
                    ID = Guid.NewGuid().ToString(),
                    申請人 = "",
                    假別 = "事假",
                    請假日期 = DateTime.Now.AddDays(+13),
                    開始時間 = new TimeSpan(14, 0, 0),
                    請假時數 = 4,
                    請假理由 = "申辦護照",
                    職務代理人 = "王小明",
                });
                請假紀錄.Add(new 請假紀錄項目
                {
                    ID = Guid.NewGuid().ToString(),
                    申請人 = "",
                    假別 = "病假",
                    請假日期 = DateTime.Now.AddDays(+21),
                    開始時間 = new TimeSpan(9, 0, 0),
                    請假時數 = 8,
                    請假理由 = "牙痛",
                    職務代理人 = "王小明",
                });

                await Write();
            }
        }

        /// <summary>
        /// 將資料寫入檔案中
        /// </summary>
        /// <returns></returns>
        public async Task Write()
        {
            // 取得這個應用程式在這台裝置下的本機目錄
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            // 開啟或建立指定資料夾，用於儲存資料之用
            IFolder folder = await rootFolder.CreateFolderAsync(Repository資料夾名稱,
                CreationCollisionOption.OpenIfExists);

            var fooWriteContent = JsonConvert.SerializeObject(請假紀錄);

            // 建立檔案
            file = await folder.CreateFileAsync(Repository檔案名稱, CreationCollisionOption.ReplaceExisting);
            // 將 Json 內容寫入檔案
            await file.WriteAllTextAsync(fooWriteContent);
        }
    }
}
