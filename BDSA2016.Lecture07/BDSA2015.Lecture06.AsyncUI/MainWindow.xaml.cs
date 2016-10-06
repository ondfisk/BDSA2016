using BDSA2016.Lecture06.AsyncUI.ViewModels;
using System.Windows;

namespace BDSA2015.Lecture06.AsyncUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowAsyncViewModel();
        }
    }
}
