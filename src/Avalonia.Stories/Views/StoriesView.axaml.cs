using System;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Stories.ViewModels;

namespace Avalonia.Stories.Views
{
    public partial class StoriesView : UserControl
    {
        private readonly Carousel? _carousel;
        private readonly StoriesLineView? _line;

        public StoriesView()
        {
            InitializeComponent();
            _carousel = this.FindControl<Carousel>("carousel");
            _line = this.FindControl<StoriesLineView>("line");

            _line?.CurrentItem?
                .Changed
                .Subscribe(x =>
                {
                    if (_line.CurrentItem != null)
                    {
                        if (_carousel != null) _carousel.SelectedIndex = _line.SelectedIndex;
                    }
                });

            IsStartedProperty
                .Changed
                .Where(x => x.NewValue.Value != x.OldValue.Value)
                .Subscribe(x =>
                {
                    if (x.NewValue.Value)
                    {
                        Start();
                    }
                    else
                    {
                        Stop();
                    }
                });
        }

        public static readonly StyledProperty<bool> IsStartedProperty =
            AvaloniaProperty.Register<StoriesView, bool>(
                nameof(IsStarted));

        public bool IsStarted
        {
            get => GetValue(IsStartedProperty);
            set => SetValue(IsStartedProperty, value);
        }
        
        public static readonly StyledProperty<double> DurationSecondsProperty =
            StoriesLineView.DurationSecondsProperty.AddOwner<StoriesView>();
        public double DurationSeconds
        {
            get => GetValue(DurationSecondsProperty);
            set => SetValue(DurationSecondsProperty, value);
        }
        
        public static readonly StyledProperty<bool> IsDescriptionVisibleProperty =
            StoriesLineView.IsDescriptionVisibleProperty.AddOwner<StoriesLineView>();

        public bool IsDescriptionVisible
        {
            get => GetValue(IsDescriptionVisibleProperty);
            set => SetValue(IsDescriptionVisibleProperty, value);
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Start()
        {
            _line?.Start();
        }
        
        public void Stop()
        {
            _line?.Stop();
        }
    }
}