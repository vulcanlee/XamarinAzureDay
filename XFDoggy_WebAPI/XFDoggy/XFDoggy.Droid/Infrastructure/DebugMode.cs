using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFDoggy.Infrastructure;
using XFDoggy.Droid.Infrastructure;


[assembly: Xamarin.Forms.Dependency(typeof(DebugMode))]
namespace XFDoggy.Droid.Infrastructure
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