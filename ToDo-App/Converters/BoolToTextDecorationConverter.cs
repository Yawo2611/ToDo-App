using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace ToDo_App.Converters
{
    public class BoolToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TextDecorations.Strikethrough : TextDecorations.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
