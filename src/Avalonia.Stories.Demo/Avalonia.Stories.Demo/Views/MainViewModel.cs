using System;
using System.Collections.ObjectModel;
using Avalonia.Stories.ViewModels;

namespace Avalonia.Stories.Demo.Views;

public class MainViewModel : IStoriesViewModel
{
    public ObservableCollection<StoriesImageViewModel> Items { get; set; } = new();
    public MainViewModel()
    {
        Items.Add(new StoriesImageViewModel("image1", new Uri("https://user-images.githubusercontent.com/4672627/152126443-932966cf-57e7-4e77-9be6-62463a66b9f8.png")));
        Items.Add(new StoriesImageViewModel("image2", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
        Items.Add(new StoriesImageViewModel("image3", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/Wasabi.png?raw=true")));
    }
}