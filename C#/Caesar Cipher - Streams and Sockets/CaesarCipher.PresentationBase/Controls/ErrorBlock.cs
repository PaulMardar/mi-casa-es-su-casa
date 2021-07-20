using System.Windows;
using System.Windows.Controls;

namespace iQuest.CaesarCipher.PresentationBase.Controls
{
    public class ErrorBlock : ContentControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(ErrorBlock));

        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        static ErrorBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ErrorBlock), new FrameworkPropertyMetadata(typeof(ErrorBlock)));
        }
    }
}