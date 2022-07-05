using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Stories.ViewModels
{
    public class StoriesLineViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<StoriesImageViewModel>?Source { get; set; }
    }
}