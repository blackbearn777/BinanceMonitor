using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BinanceMonitor.WPF.Converters
{
    class ValueToBrushConverter : IMultiValueConverter
    {
        private Brush _currentBrush;


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal newValue = Decimal.Parse(values[0] as string);

            decimal oldValue = Decimal.Parse(values[1] as string);
            if (newValue > oldValue)
            {
                _currentBrush = Brushes.Green;
            }
            else if (newValue < oldValue)
            {
                _currentBrush = Brushes.Red;
            }
            else
            {
                return _currentBrush;
            }
            return _currentBrush;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
