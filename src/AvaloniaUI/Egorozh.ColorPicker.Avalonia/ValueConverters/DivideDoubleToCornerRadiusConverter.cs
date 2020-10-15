﻿using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace Egorozh.ColorPicker.Avalonia
{
    public class DivideDoubleToCornerRadiusConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var divider = 2.0;

            if (parameter != null && double.TryParse(parameter.ToString(), out var div))
            {
                divider = div;
            }

            if (value is double dividend)
                return new CornerRadius(dividend / divider);

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}