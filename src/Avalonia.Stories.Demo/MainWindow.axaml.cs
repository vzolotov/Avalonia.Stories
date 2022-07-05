using System;
using Avalonia.Controls;
using Avalonia.Stories.Views;

namespace Avalonia.Stories.Demo
{
    public partial class MainWindow : Window
    {
        private StoriesView? _view;
        public MainWindow()
        {
            InitializeComponent();
            _view = this.FindControl<StoriesView>("stories");
            this.Activated += OnActivated;
            
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void OnActivated(object? sender, EventArgs e)
        {
            this.Activated -= OnActivated;
            stories.IsStarted = true;
        }
    }
}