using System;
using System.Windows.Input;
using BlogPostApp.ViewModels;

namespace BlogPostApp.Commands
{
    public class DoSomethingCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter is ImageListItemViewModel imageViewModel)
            {
                return !imageViewModel.DidSomething;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter is ImageListItemViewModel imageViewModel)
            {
                imageViewModel.DoSomething();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
