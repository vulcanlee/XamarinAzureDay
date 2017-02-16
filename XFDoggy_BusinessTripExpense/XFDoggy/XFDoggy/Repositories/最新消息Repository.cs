using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Models;
using XFDoggy.ViewModels;

namespace XFDoggy.Repositories
{
    /// <summary>
    /// 進行請假記錄的檔案存取 Repository
    /// </summary>
    class 最新消息Repository
    {
        public List<最新消息項目ViewModel> 最新消息 { get; set; }

        /// <summary>
        /// 從檔案中讀取資料出來
        /// </summary>
        /// <returns></returns>
        public Task Read(int pInt = 0)
        {
            Random fooRM = new Random();
            最新消息 = new List<最新消息項目ViewModel>();

            return Task.Run(async () =>
            {
                for (int i = 0; i < 30; i++)
                {
                    最新消息.Add(new 最新消息項目ViewModel
                    {
                        ID = Guid.NewGuid().ToString(),
                        名稱 = $"最新消息項目 {DateTime.Now.Ticks}"
                    });
                }
                await Task.Delay(fooRM.Next(1000, 3000));
            });
        }
    }
}
