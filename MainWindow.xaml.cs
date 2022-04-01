using LibVLCSharp.Shared;
using System.Windows;

namespace Stream1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            Core.Initialize();
            DataContextChanged += MainWindow_DataContextChanged;
            vm = new MainViewModel();
            DataContext = vm;
        }

        private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(sender is MainWindow win)
            {
                if (vm.ShowOnWpfWindow)
                    win.videoView.MediaPlayer = vm.mediaPlayer;
            }
        }
    }
}
