﻿using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Egorozh.ColorPicker
{
    public class ColorEditor : Control, IColorClient
    {
        #region Static Constructor

        static ColorEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorEditor),
                new FrameworkPropertyMetadata(typeof(ColorEditor)));
        }

        #endregion

        public void ColorUpdated(Color color, IColorClient client)
        {
        }

        public void Init(IColorManager colorManager)
        {
        }
    }
}