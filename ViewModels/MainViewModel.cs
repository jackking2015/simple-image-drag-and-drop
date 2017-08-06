using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using BlogPostApp.Commands;

namespace BlogPostApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DropImageCommand { get; set; }
        public ObservableCollection<ImageListItemViewModel> Images { get; set; }
        public Visibility DropPanelLabelVisibility => Images.Any() ? Visibility.Collapsed : Visibility.Visible;

        public MainViewModel()
        {
            DropImageCommand = new DropImageCommand(this);
            Images = new ObservableCollection<ImageListItemViewModel>();
            Images.CollectionChanged += OnImagesCollectionChange;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnImagesCollectionChange(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            OnPropertyChanged(nameof(Images));
            OnPropertyChanged(nameof(DropPanelLabelVisibility));
        }
    }
}
