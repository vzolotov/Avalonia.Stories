using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Stories.ViewModels
{
    /// <summary>
    /// Top line view model
    /// </summary>
    public class StoriesLineViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<StoriesImageViewModel>?Source { get; set; }
    }
}