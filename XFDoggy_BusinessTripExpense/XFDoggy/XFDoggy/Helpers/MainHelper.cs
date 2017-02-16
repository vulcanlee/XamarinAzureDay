using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.Helpers
{
    public class MainHelper
    {
        /// <summary>
        /// 指向 Azure Mobile App 服務的主要網址
        /// </summary>
        public static string MainURL = "https://xamarinazureday.azurewebsites.net";
        /// <summary>
        /// Azure Mobile App 線上版本的用戶端
        /// </summary>
        public static MobileServiceClient client = new MobileServiceClient(MainURL);
    }
}
