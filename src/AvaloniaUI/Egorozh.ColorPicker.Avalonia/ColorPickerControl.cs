﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;

namespace Egorozh.ColorPicker.Avalonia
{
    public class ColorPickerControl : TemplatedControl, IStyleable
    {
        #region Private Fields

        private readonly IColorManager _manager = new ColorManager();

        #endregion

        #region IStyleable

        Type IStyleable.StyleKey => typeof(ColorPickerControl);

        #endregion

        #region Dependency Properties

        public static readonly StyledProperty<Color> ColorProperty =
            AvaloniaProperty.Register<ColorPickerControl, Color>(nameof(Color), notifying: ColorChanged);

        private static void ColorChanged(IAvaloniaObject obj, bool isAfter)
        {
            if (obj is ColorPickerControl colorPickerControl)
                colorPickerControl.ColorChanged(colorPickerControl.Color);
        }

        #endregion

        #region Public Properties

        public Color Color
        {
            get => GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _manager.ColorChanged += Manager_ColorChanged;

            var colorWheel = e.NameScope.Find<ColorWheel>("PART_ColorWheel");
            
            _manager.AddClient(colorWheel);
        }

        #endregion

        #region Private Methods

        private void Manager_ColorChanged(System.Drawing.Color color)
        {
            _manager.ColorChanged -= Manager_ColorChanged;

            Color = color.ToColor();

            _manager.ColorChanged += Manager_ColorChanged;
        }

        private void ColorChanged(Color color)
        {
            _manager.CurrentColor = color.ToColor();
        }

        #endregion
    }
}