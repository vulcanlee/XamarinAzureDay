using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDoggy.Converters
{
    public class 取得月份或天數Converter : IValueConverter
    {
        public string 轉換格式 { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fooValue = (DateTime)value;
            var fooResult = "";
            fooResult = fooValue.ToString(轉換格式);
            return fooResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
