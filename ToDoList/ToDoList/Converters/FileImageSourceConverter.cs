using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoList.Converters
{
    public class FileImageSourceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string filename = parameter as string;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                default:
                    return filename;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
