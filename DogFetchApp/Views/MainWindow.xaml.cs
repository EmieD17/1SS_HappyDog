using DogFetchApp.ViewModels;
using DogFetchApp.Commands;
using System.Windows;
using System.Threading.Tasks;
using ApiHelper;
using ApiHelper.Models;
using System.Windows.Media.Imaging;
using System;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel currentViewmodel;
        App app;

        public DogModel imgList { get; set; }
        int imgIdx;


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
        private async Task LoadBreedList()
        {
            var breedList = await DogApiProcessor.LoadBreedList();
            var bl = breedList.breedlist;
            foreach (var e in bl)
            {
                if (e.Value.Count == 0)
                {
                    cBoxBL.Items.Add(e.Key);
                }
                else
                {
                    for (int i = 0; i < e.Value.Count; i++)
                    {
                        cBoxBL.Items.Add(e.Key + "/" + e.Value[i]);
                    }
                }
            }
        }
        private async void MainWindow_is_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadBreedList();
            btn_previous.IsEnabled = false;
            btn_next.IsEnabled = false;
        }
        private async void Fetch_Button_Click(object sender, RoutedEventArgs e)
        {
            imgIdx = 0;
            string nb = cBoxNbImg.Text;
            string breed = cBoxBL.Text;
            if (nb != "" && breed != "")
            {
                imgList = await DogApiProcessor.GetImageUrl(breed, nb);
                var r = imgList.imglist[imgIdx];
                imgListView.Source = new BitmapImage(new Uri(r));
                btn_next.IsEnabled = true;
            }
        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            imgIdx--;
            var r = imgList.imglist[imgIdx];
            imgListView.Source = new BitmapImage(new Uri(r));
            btn_next.IsEnabled = true;
            if (imgIdx == 0)
            {
                btn_previous.IsEnabled = false;
            }
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            imgIdx++;
            var r = imgList.imglist[imgIdx];
            imgListView.Source = new BitmapImage(new Uri(r));
            btn_previous.IsEnabled = true;
            if (imgIdx == imgList.imglist.Count - 1)
            {
                btn_next.IsEnabled = false;
            }
        }
    }
}
