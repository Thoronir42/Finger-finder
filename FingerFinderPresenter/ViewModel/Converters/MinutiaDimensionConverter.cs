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
            Single value;
            double dimension;
            double radius;
            try
            {
                value = (Single)values[0];
                dimension = (Int32)values[1];
                radius = (Double)parameter;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Dimension conversion error: ({values[1].GetType()} {values[1]}) \n+ {e}");
                return Binding.DoNothing;
            }

            Double result = value * dimension - radius / 2;
            //Console.WriteLine($"{value} * {dimension} - {radius / 2}= {result}");
            return  result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
