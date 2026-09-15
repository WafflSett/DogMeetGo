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
            var err = InputCheck();
            if (err!=null)
            {
                await Application.Current!.Windows[0]!.Page!.DisplayAlertAsync("Empty fields", err, "Ok");
            }
            else
            {
                await Shell.Current.GoToAsync("//createprofile");
            }
        }

        private string? InputCheck()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return "Please enter an email address!";
            if (string.IsNullOrWhiteSpace(Password))
                return "Please enter a password!";
            return null;
        }

        [RelayCommand]
        private async Task Guest()
        {
            await Shell.Current.GoToAsync("//home");

        }
    }
}
