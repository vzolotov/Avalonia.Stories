# Avalonia.Stories

is similar like Instagram Stories

[![Release to NuGet](https://github.com/vzolotov/Avalonia.Stories/actions/workflows/release.yml/badge.svg?branch=main)](https://github.com/vzolotov/Avalonia.Stories/actions/workflows/release.yml)

The easiest way to get started is this:

in view model
```cs
public class MainViewModel : IStoriesViewModel
{
    public ObservableCollection<StoriesImageViewModel> Items { get; set; } = new();
    public MainViewModel()
    {
        Items.Add(new StoriesImageViewModel("image1", new Uri("https://user-images.githubusercontent.com/4672627/152126443-932966cf-57e7-4e77-9be6-62463a66b9f8.png")));
        Items.Add(new StoriesImageViewModel("image2", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
        Items.Add(new StoriesImageViewModel("image3", new Uri("https://github.com/AvaloniaUI/avaloniaui.net/blob/master/assets/showcase/GritGene.png?raw=true")));
    }
} 
```

in view

```xml
 <Window.DataContext>
        <demo:MainViewModel/> <-- set data conxext
    </Window.DataContext>
    <views:StoriesView
        x:Name="stories1" 
        IsStarted="True"
        DataContext="{Binding}"/>
```
