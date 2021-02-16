using System;
using System.Runtime;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BinanceMonitor.WPF.Converters
{
    public class ValueToSumConverter : IMultiValueConverter
    {


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = System.Convert.ToDecimal(values[0].ToString().Replace('.',',')) ;

            decimal qty = System.Convert.ToDecimal(values[1].ToString().Replace('.', ','));

            return Math.Round((price*qty),8).ToString();

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
