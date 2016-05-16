using System;
using System.Globalization;
using System.Windows.Data;

namespace FingerFinderPresenter.ViewModel.Converters
{
    class MinutiaDimensionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach(object o in values)
            {
                Console.WriteLine($"{o.GetType()} - {o}");
            }

            Single value = (Single)values[0];
            Double result = value * 100;
            Console.WriteLine($"{value} * 100 = {result}");
            return  result;
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private double parseDimension(double value, double parameter, bool back = false)
        {
            return back ? value / parameter : value * parameter;
        }
    }
}
