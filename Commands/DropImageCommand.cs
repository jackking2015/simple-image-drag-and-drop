using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlogPostApp.ViewModels;

namespace BlogPostApp.Commands
{
    public class DropImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly List<string> _supportedImageFormats;
        private readonly MainViewModel _viewModel;

        public DropImageCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            _supportedImageFormats = new List<string>
            {
                ".jpg",
                ".jpeg",
                ".png"
            };
        }

        public bool CanExecute(object parameter)
        {
            var imagePaths = ToArrayOfFilePaths(parameter);
            return imagePaths.Length != 0 &&
                   imagePaths.Any(imagePath => _supportedImageFormats.Contains(Path.GetExtension(imagePath)));
        }

        public void Execute(object parameter)
        {
            var imagePaths = ToArrayOfFilePaths(parameter);
            var filteredImagePaths = FilterNotSupportedFormats(imagePaths);

            foreach (var imagePath in filteredImagePaths)
            {
                _viewModel.Images.Add(imagePath);
            }
        }

        private string[] ToArrayOfFilePaths(object givenParameter)
        {
            return givenParameter as string[] ?? new string[] { };
        }

        private string[] FilterNotSupportedFormats(string[] filePaths)
        {
            return filePaths.Where(filePath => _supportedImageFormats.Contains(Path.GetExtension(filePath))).ToArray();
        }
    }
}
