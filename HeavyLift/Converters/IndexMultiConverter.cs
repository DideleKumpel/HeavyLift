using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Converters
{
    class IndexMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] == null || values[1] == null)
                return "";

            var item = values[0];
            var reps = values[1] as IEnumerable;

            if (reps == null)
                return "";

            int index = 0;
            foreach (var rep in reps)
            {
                if (rep == item)
                    return (index + 1).ToString();

                index++;
            }

            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
