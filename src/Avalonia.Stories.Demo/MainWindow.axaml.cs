using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Stories.Views;

namespace Avalonia.Stories.Demo
{
    public partial class MainWindow : Window
    {
        private StoriesView? _view;
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            _view = this.FindControl<StoriesView>("stories1");
            this.Activated += OnActivated;
            
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void OnActivated(object? sender, EventArgs e)
        {
            this.Activated -= OnActivated;
            _view.IsStarted = true;
        }
    }
}