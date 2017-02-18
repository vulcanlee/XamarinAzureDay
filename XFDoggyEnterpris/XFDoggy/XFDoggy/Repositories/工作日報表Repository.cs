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
    class 工作日報表Repository
    {
        public List<工作日報表> 工作日報表 { get; set; }
        string Repository資料夾名稱 = "Repositories";
        string Repository檔案名稱 = "工作日報表Repository.dat";
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
                工作日報表 = JsonConvert.DeserializeObject<List<工作日報表>>(fooReadContent);
                if (工作日報表 == null)
                {
                    工作日報表 = new List<工作日報表>();
                }
            }
            else
            {
                // 這個檔案不存在
                // 設定預設展示用的資料紀錄
                工作日報表 = new List<工作日報表>();
                工作日報表.Add(new 工作日報表
                {
                    ID = Guid.NewGuid().ToString(),
                    專案名稱 = "專案A",
                    工作內容 = "與客戶開會，進行專案驗收",
                    日期 = DateTime.Now.Date,
                    處理時間 = 8,
                });
                工作日報表.Add(new 工作日報表
                {
                    ID = Guid.NewGuid().ToString(),
                    專案名稱 = "專案B",
                    工作內容 = "與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。與客戶開會，討論系統規格問題。",
                    日期 = DateTime.Now.Date,
                    處理時間 = 8,
                });
                工作日報表.Add(new 工作日報表
                {
                    ID = Guid.NewGuid().ToString(),
                    專案名稱 = "專案C",
                    工作內容 = "處理客戶提出的Bug",
                    日期 = DateTime.Now.Date,
                    處理時間 = 8,
                });
                工作日報表.Add(new 工作日報表
                {
                    ID = Guid.NewGuid().ToString(),
                    專案名稱 = "專案A",
                    工作內容 = "撰寫驗收報告",
                    日期 = DateTime.Now.Date.AddDays(-1),
                    處理時間 = 8,
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

            var fooWriteContent = JsonConvert.SerializeObject(工作日報表);

            // 建立檔案
            file = await folder.CreateFileAsync(Repository檔案名稱, CreationCollisionOption.ReplaceExisting);
            // 將 Json 內容寫入檔案
            await file.WriteAllTextAsync(fooWriteContent);
        }
    }
}
