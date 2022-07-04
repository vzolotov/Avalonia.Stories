using System.Collections.ObjectModel;

namespace Avalonia.Stories.ViewModels
{
    public interface IStoriesViewModel
    {
        ObservableCollection<StoriesImageViewModel>? Items{ get; set; }
    }
}