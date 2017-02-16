using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDoggy.CustomControls
{
    /// <summary>
    /// 客製化一個 Label 控制項，這個控制項專門用來顯示 Font Awesome 字體圖示之用
    /// 這裡用的字體版本為 font-awesome-4.7.0
    /// </summary>
    public class FontAwesomeLabel : Label
    {
        public FontAwesomeLabel()
        {
            // 這裡使用 Device.OnPlatform 來根據不同作業系統平台，指定需要用到的 Font Awesome 字型檔案的來源
            FontFamily = Device.OnPlatform("fontawesome", "fontawesome", "/Assets/fontawesome.ttf#FontAwesome");
        }
    }
}
