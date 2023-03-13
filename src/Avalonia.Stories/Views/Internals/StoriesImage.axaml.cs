using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.Stories.Views.Internals
{
    public partial class StoriesImage : StackPanel
    {
        public StoriesImage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public static readonly StyledProperty<bool> IsDescriptionVisibleProperty =
            AvaloniaProperty.Register<StoriesImage, bool>(
                nameof(IsDescriptionVisible), defaultValue: false);

        public bool IsDescriptionVisible
        {
            get => GetValue(IsDescriptionVisibleProperty);
            set => SetValue(IsDescriptionVisibleProperty, value);
        }
        
        public static readonly StyledProperty<double> PreviewHeightProperty =
            AvaloniaProperty.Register<StoriesImage, double>(
                nameof(PreviewHeight), defaultValue:90);

        public double PreviewHeight
        {
            get => GetValue(PreviewHeightProperty);
            set => SetValue(PreviewHeightProperty, value);
        }
    }
}