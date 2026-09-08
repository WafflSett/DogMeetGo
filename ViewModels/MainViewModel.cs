using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogMeetGo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public string email = "";

        [ObservableProperty]
        public string password = "";

        [RelayCommand]
        private async Task LogIn()
        {
            await Shell.Current.GoToAsync("//home");
        }

        [RelayCommand]
        private async Task SignUp()
        {
            await Shell.Current.GoToAsync("//createprofile");

        }

        [RelayCommand]
        private async Task Guest()
        {
            await Shell.Current.GoToAsync("//home");

        }
    }
}
