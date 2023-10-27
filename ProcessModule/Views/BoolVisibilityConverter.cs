using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace ProcessModule.Views
{

    public class BooleanConverter<T> : IValueConverter
    {
        public BooleanConverter(T trueValue, T falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            => value is bool boolValue && boolValue ? TrueValue : FalseValue;

        public virtual object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => value is T tValue && EqualityComparer<T>.Default.Equals(tValue, TrueValue);
    }

    public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverter() :
            base(Visibility.Visible, Visibility.Collapsed)
        { }
    }
    //public class BoolVisibilityConverter : MarkupExtension
    //{
    //    public static BoolVisibilityConverter converter;
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value == null)
    //            return Visibility.Collapsed;
    //        else
    //            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value == null)
    //            return false;
    //        else
    //            return (Visibility)value == Visibility.Visible ? true : false;
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        return converter ?? (converter = new BoolVisibilityConverter());
    //    }
    //}
}
