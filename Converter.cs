using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string [] arr = new string[values.Length];

            if (values != null)
            {

                Parallel.For(0, values.Length, i =>
                      {
                          arr[i] = values[i].ToString().ToUpper();

                      });

                int a = 0;
                Parallel.ForEach(values, value=>
               {
                   arr[a] = value.ToString().ToUpper();
                   a++;
               });

            }

            return arr;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
