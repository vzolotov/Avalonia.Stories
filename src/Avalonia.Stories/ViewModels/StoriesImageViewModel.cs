using System;
using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Stories.ViewModels
{
    public class StoriesImageViewModel : ReactiveObject, IStoriesImage
    {
        public StoriesImageViewModel(string text, Uri image)
        {
            Text = text;
            Image = image;
        }

        [Reactive] public string Text { get; set; }
        [Reactive] public Uri Image { get; set; }
        [Reactive] internal protected bool IsStarted { get; set; }
        
    }
}