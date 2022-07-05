using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Styling;
using Avalonia.Threading;

namespace Avalonia.Stories.Views.Internals
{
    public sealed class StoriesAnimatedBar : ProgressBar, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ProgressBar);
        private DispatcherTimer? _dispatcherTimer;
        public bool Started { get; private set; } = false;
        public bool Paused { get; private set; } = false;
        public event EventHandler Completed;
        
        public StoriesAnimatedBar()
        {
        }
        
        public static readonly StyledProperty<bool> IsCompleteProperty =
            AvaloniaProperty.Register<StoriesAnimatedBar, bool>(
                nameof(IsComplete));

        public bool IsComplete
        {
            get => GetValue(IsCompleteProperty);
            set => SetValue(IsCompleteProperty, value);
        }
        
        public static readonly DirectProperty<StoriesAnimatedBar,bool> IsWorkedProperty =
            AvaloniaProperty.RegisterDirect<StoriesAnimatedBar, bool>(
                nameof(IsWorked),
                o => o.IsWorked,
                (o, v) =>
                {
                    if (v)
                    {
                        o.Started = false;
                        o.Paused = false;
                        o.IsComplete = false;
                        o.Value = 0;
                    }
                    o.IsWorked = v;
                });

        private bool _isWorked;
        public bool IsWorked
        {
            get => _isWorked;
            set => SetAndRaise(IsWorkedProperty, ref _isWorked, value);
        }
        
        void Start()
        {
            if (IsComplete || !Started)
                _dispatcherTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(300), DispatcherPriority.Layout,
                    DispatcherTimerOnTick);
            
            Started = true;
            Paused = false;
            _dispatcherTimer?.Start();
        }

        private void DispatcherTimerOnTick(object sender, EventArgs e)
        {
            if (Value >= Maximum)
            {
                Stop();
                IsComplete = true;
                Completed.Invoke(this, EventArgs.Empty);
            }

            Value += _dispatcherTimer.Interval.TotalMilliseconds;
        }


        public void Pause()
        {
            _dispatcherTimer?.Stop();
            Started = false;
            Paused = true;
        }
        
        public void Stop()
        {
            _dispatcherTimer?.Stop();
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
            Started = false;
            Paused = false;
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);
            if (change.Property.Name == nameof(IsWorked))
            {
                if (IsWorked)
                {
                    if (!Started)
                        Start();
                }
                else
                {
                    Stop();
                }
            }
        }
    }
}