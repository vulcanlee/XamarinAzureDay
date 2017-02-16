using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Infrastructure;
using XFDoggy.UWP.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(DebugMode))]
namespace XFDoggy.UWP.Infrastructure
{
    public class DebugMode : IDebugMode
    {
        public bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
