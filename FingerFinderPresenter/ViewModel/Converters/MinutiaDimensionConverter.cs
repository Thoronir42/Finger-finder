using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FingerFinderPresenter.ViewModel.Converters
{
    class MinutiaDimensionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Single value = (Single)values[0];
            if (values[1] == null || !values[1].GetType().Equals(typeof(Double)))
            {
                Console.WriteLine("Dimension conversion error: " + values[1]);
                return value;
            }

            double multipler = (double)values[1];
            Console.WriteLine(parameter.GetType() + " " + parameter);
            double radius = (parameter != null && parameter.GetType().Equals(typeof(Double))) ? (Double)parameter : 0;

            Double result = value * multipler - radius / 2;

            return  result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
