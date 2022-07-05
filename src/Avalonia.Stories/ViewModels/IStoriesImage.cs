using System;
using Avalonia.Media.Imaging;

namespace Avalonia.Stories.ViewModels
{
    public interface IStoriesImage
    {
        string Text { get; set; }
        Uri Image { get; set; }
    }
}