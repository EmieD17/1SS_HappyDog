using DogFetchApp.ViewModels;
using DogFetchApp.Commands;
using System.Windows;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel currentViewmodel;
        App app;


        public MainWindow(App _app)
        {
            this.app = _app;
            InitializeComponent();
            ApiHelper.ApiHelper.InitializeClient();

            currentViewmodel = new MainViewModel();

            DataContext = currentViewmodel;

            currentViewmodel.RestartCommand = new DelegateCommand<string>(Restart);
        }

        private void Restart(string obj)
        {
            var result = MessageBox.Show(Properties.Resources.msB_restartMessage, "Message", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                app.Restart();
            }
        }
    }
}
