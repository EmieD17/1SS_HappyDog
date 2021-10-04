using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ApiHelper;
using DogFetchApp.Commands;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public DelegateCommand<string> RestartCommand { get; set; }
        public DelegateCommand<string> ChangeLanguageCommand { get; set; }

        private void ChangeLanguage(string param)
        {
            Properties.Settings.Default.Language = param;
            Properties.Settings.Default.Save();

            RestartCommand?.Execute("");
        }
        public MainViewModel()
        {
            ChangeLanguageCommand = new DelegateCommand<string>(ChangeLanguage);
        }
        private async Task LoadBreedList()
        {
            var breedlist = await DogApiProcessor.LoadBreedList();
            var p = breedlist.breedlist;
            foreach (var e in p)
            {
                if (e.Value.Count == 0)
                {
                   
                }
                else
                {
                    var a = e.Value;
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadBreedList();
        }
    }
}
