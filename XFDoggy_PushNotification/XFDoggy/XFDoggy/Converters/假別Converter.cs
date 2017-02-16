using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDoggy.Converters
{
    public class 假別Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fooValue = value as string;
            var fooResult = "";
            switch (fooValue)
            {
                case "事假":
                    fooResult = "\uf290";
                    break;
                case "病假":
                    fooResult = "\uf236";
                    break;
                case "特休假":
                    fooResult = "\uf243";
                    break;
                default:
                    fooResult = "\uf128";
                    break;
            }
            return fooResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
