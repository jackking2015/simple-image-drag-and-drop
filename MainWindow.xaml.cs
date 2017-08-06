using System.Windows;
using BlogPostApp.ViewModels;

namespace BlogPostApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new MainViewModel();
            DragDropPanel.Drop +=
                (sender, args) => ViewModel.DropImageCommand.Execute(args.Data.GetData(DataFormats.FileDrop));
            DragDropPanel.Drop += (sender, args) => DragDropPanel.Opacity = 1d;
            DragDropPanel.DragOver += (sender, args) => DragDropPanel.Opacity = 0.7d;
            DragDropPanel.DragLeave += (sender, args) => DragDropPanel.Opacity = 1d;
        }
    }
}
