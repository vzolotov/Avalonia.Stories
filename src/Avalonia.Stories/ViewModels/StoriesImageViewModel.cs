using System;
using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Stories.ViewModels
{
    public class StoriesImageViewModel : ReactiveObject, IStoriesImage
    {
        /// <summary>
        /// Image view model
        /// </summary>
        /// <param name="text">image description</param>
        /// <param name="image">image url</param>
        public StoriesImageViewModel(string text, Uri image)
        {
            Text = text;
            Image = image;
        }

        [Reactive] public string Text { get; set; }
        [Reactive] public Uri Image { get; set; }
        [Reactive] protected internal bool IsStarted { get; set; }
        
    }
}