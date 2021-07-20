using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace iQuest.CaesarCipher.PresentationBase.Controls
{
    public class Led : ContentControl
    {
        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(LedState), typeof(Led));

        public LedState State
        {
            get => (LedState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public static readonly DependencyProperty OnColorProperty = DependencyProperty.Register("OnColor", typeof(Brush), typeof(Led), new PropertyMetadata(Brushes.Green));

        public Brush OnColor
        {
            get => (Brush)GetValue(OnColorProperty);
            set => SetValue(OnColorProperty, value);
        }

        public static readonly DependencyProperty OffColorProperty = DependencyProperty.Register("OffColor", typeof(Brush), typeof(Led), new PropertyMetadata(Brushes.LightGray));

        public Brush OffColor
        {
            get => (Brush)GetValue(OffColorProperty);
            set => SetValue(OffColorProperty, value);
        }

        static Led()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Led), new FrameworkPropertyMetadata(typeof(Led)));
        }
    }
}