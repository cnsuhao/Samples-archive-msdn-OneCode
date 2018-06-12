using System;
using Windows.UI.Xaml.Data;

namespace CSUnvsAppDataFilter.Converters
{
    class DoubleToMoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double price = (double)value;
            return string.Format("{0:C2}", price);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
