using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDoggy.Infrastructure
{
    /// <summary>
    /// 判斷現在是否是在 Visual Studio 除錯模式下
    /// </summary>
    public interface IDebugMode
    {
        /// <summary>
        /// 回傳 True : 正在除錯模式下
        /// </summary>
        /// <returns></returns>
        bool IsDebugMode();
    }
}
