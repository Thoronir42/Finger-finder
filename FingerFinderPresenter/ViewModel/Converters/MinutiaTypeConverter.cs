using FingerprintAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FingerFinderPresenter.ViewModel.Converters
{
    class MinutiaTypeConverter : IValueConverter
    {
        private static Dictionary<MinutiaType, Color> TypeToColor { get; } = prepareDictionary();

        private static Dictionary<MinutiaType, Color> prepareDictionary()
        {
            var d = new Dictionary<MinutiaType, Color>();
            d[MinutiaType.Core] = Colors.DarkCyan;
            d[MinutiaType.CrossoverOrBridge] = Colors.Orange;
            d[MinutiaType.Delta] = Colors.DarkCyan;
            d[MinutiaType.Island] = Colors.DarkTurquoise;
            d[MinutiaType.RidgeBifurcation] = Colors.ForestGreen;
            d[MinutiaType.RidgeEnclosure] = Colors.Goldenrod;
            d[MinutiaType.RidgeEnding] = Colors.DarkOliveGreen;
            d[MinutiaType.ShortRidge] = Colors.HotPink;
            d[MinutiaType.Spur] = Colors.Indigo;
            d[MinutiaType.Unspecified] = Colors.Magenta;
            return d;
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || !value.GetType().Equals(typeof(MinutiaType)))
            {
                Console.WriteLine("Nothing on " + value.GetType());
                return Binding.DoNothing;
            }
            Color c = TypeToColor[(MinutiaType)value];
            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || !value.GetType().Equals(typeof(Color)))
            {
                Console.WriteLine("Type Conversion error");
                return Binding.DoNothing;
            }
            Color col = (Color)value;
            var i = TypeToColor.GetEnumerator();
            do
            {
                var keyVal = i.Current;
                if (keyVal.Value != col)
                {
                    continue;
                }
                i.Dispose();
                return keyVal.Key;
            } while (i.MoveNext());

            Console.WriteLine("Type Conversion error");
            return Binding.DoNothing;

        }
    }
}
