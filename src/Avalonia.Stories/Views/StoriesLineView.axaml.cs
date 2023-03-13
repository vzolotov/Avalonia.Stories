using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Stories.ViewModels;
using Avalonia.Stories.Views.Internals;

namespace Avalonia.Stories.Views
{
    public partial class StoriesLineView : UserControl
    {
        private const int DefaultIndex = -1;
        private readonly ItemsControl? _images;
        public StoriesLineView()
        {
            InitializeComponent();
            _images = this.FindControl<ItemsControl>("images");
            ItemsProperty
                .Changed
                .Where(x => x.NewValue.Value != x.OldValue.Value)
                .Subscribe(arg =>
                {
                    if (_images != null) _images.Items = arg?.NewValue.Value;
                });
            
            CurrentItemProperty
                .Changed
                .Where(x => x.NewValue.Value != x.OldValue.Value)
                .Subscribe(x =>
                {
                    if (x.OldValue.Value != null)
                    {
                        x.OldValue.Value.IsStarted = false;
                    }

                    if (x.NewValue.Value != null)
                    {
                        x.NewValue.Value.IsStarted = true;
                        if (Items != null) SelectedIndex = Items.IndexOf(x.NewValue.Value);
                    }
                    else
                    {
                        SelectedIndex = DefaultIndex;
                    }
                });
            
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public static readonly StyledProperty<ObservableCollection<StoriesImageViewModel>?> ItemsProperty =
            AvaloniaProperty.Register<StoriesLineView, ObservableCollection<StoriesImageViewModel>?>(
                nameof(Items));

        public ObservableCollection<StoriesImageViewModel>? Items
        {
            get => GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
        
        public static readonly StyledProperty<StoriesImageViewModel?> CurrentItemProperty =
            AvaloniaProperty.Register<StoriesLineView, StoriesImageViewModel?>(
                nameof(CurrentItem),
                defaultBindingMode: BindingMode.TwoWay);

        public StoriesImageViewModel? CurrentItem
        {
            get => GetValue(CurrentItemProperty);
            set => SetValue(CurrentItemProperty, value);
        }
        
        public static readonly StyledProperty<int> SelectedIndexProperty =
            AvaloniaProperty.Register<StoriesLineView, int>(
                nameof(SelectedIndex));

        public int SelectedIndex
        {
            get => GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }
        
        public static readonly StyledProperty<ICommand?> ItemTapCommandProperty =
            AvaloniaProperty.Register<StoriesLineView, ICommand?>(
                nameof(ItemTapCommand));

        public ICommand? ItemTapCommand
        {
            get => GetValue(ItemTapCommandProperty);
            set => SetValue(ItemTapCommandProperty, value);
        }
        
        public static readonly StyledProperty<object?> ItemTapCommandParameterProperty =
            AvaloniaProperty.Register<StoriesLineView, object?>(
                nameof(ItemTapCommandParameter));

        public object? ItemTapCommandParameter
        {
            get => GetValue(ItemTapCommandParameterProperty);
            set => SetValue(ItemTapCommandParameterProperty, value);
        }

        public static readonly StyledProperty<double> DurationSecondsProperty =
            StoriesAnimatedBar.DurationSecondsProperty.AddOwner<StoriesView>();
        public double DurationSeconds
        {
            get => GetValue(DurationSecondsProperty);
            set => SetValue(DurationSecondsProperty, value);
        }

        public static readonly StyledProperty<bool> IsDescriptionVisibleProperty =
            StoriesImage.IsDescriptionVisibleProperty.AddOwner<StoriesLineView>();

        public bool IsDescriptionVisible
        {
            get => GetValue(IsDescriptionVisibleProperty);
            set => SetValue(IsDescriptionVisibleProperty, value);
        }
        
        public void Start()
        {
            if (CurrentItem == null)
            {
                CurrentItem = Items?.FirstOrDefault();
            }
            else
            {
                CurrentItem.IsStarted = true;
            }
        }

        public void Stop()
        {
            if (CurrentItem != null) CurrentItem.IsStarted = false;
        }

        private void InputElement_OnTapped(object sender, TappedEventArgs e)
        {
            if (!(sender is StackPanel panel)) return;
            if (panel.DataContext == null) return;
            
            var story = panel.DataContext as StoriesImageViewModel;
            if (CurrentItem == story)
            {
                CurrentItem.IsStarted = !CurrentItem.IsStarted;
            }
            else
            {
                CurrentItem.IsStarted = false;
                CurrentItem = story;
                CurrentItem.IsStarted = true;
            }
        }

        private void StoriesAnimatedBar_OnCompleted(object sender, EventArgs e)
        {
            var bar = sender as StoriesAnimatedBar;
            if (Items != null && bar?.DataContext is StoriesImageViewModel story && story != Items.Last())
            {
                CurrentItem = Items[SelectedIndex + 1];
            }
        }
    }
}