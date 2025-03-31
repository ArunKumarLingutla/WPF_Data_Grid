using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace WPF_MVVM_SetUp.Base
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                bool invert = parameter as string == "Invert";
                return (boolValue ^ invert) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                bool invert = parameter as string == "Invert";
                return (visibility == Visibility.Visible) ^ invert;
            }
            return false;
        }
    }

    //Use Case
    /*
    1. Add the Converter to Resources in app.xaml
        <Application.Resources>
            <Base:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
        </Application.Resources>

    2. Bind a bool Property to Visibility where ever required, for example button
        <Button Content="Click Me" Visibility="{Binding IsButtonVisible, Converter={StaticResource BoolToVisibility}}" />

    3. Invert the Visibility (Optional)
        <Button Content="Hidden When True" Visibility="{Binding IsButtonVisible, Converter={StaticResource BoolToVisibility}, ConverterParameter=Invert}" />
    */
}
