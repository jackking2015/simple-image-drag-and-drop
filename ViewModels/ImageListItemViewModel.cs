using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BlogPostApp.Commands;

namespace BlogPostApp.ViewModels
{
    public class ImageListItemViewModel : INotifyPropertyChanged
    {
        public ICommand DoSomethingCommand { get; set; }
        public ICommand DoSomethingElseCommand { get; set; }
        public string Path { get; set; }

        public string Caption => DidSomething
            ? "Did Something"
            : DidSomethingElse
                ? "Did Something Else"
                : "Nothing has been done";

        public bool DidSomething { get; private set; }
        public bool DidSomethingElse { get; private set; }

        public ImageListItemViewModel()
        {
            DoSomethingCommand = new DoSomethingCommand();
            DoSomethingElseCommand = new DoSomethingElseCommand();
        }

        public void DoSomething()
        {
            DidSomething = true;
            DidSomethingElse = false;
            OnPropertyChanged(nameof(Caption));
        }

        public void DoSomethingElse()
        {
            DidSomething = false;
            DidSomethingElse = true;
            OnPropertyChanged(nameof(Caption));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
