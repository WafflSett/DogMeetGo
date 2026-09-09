using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DogMeetGo.Classes;
using DogMeetGo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DogMeetGo.ViewModels.Forms
{
    public partial class CreateDogViewModel : ObservableObject
    {
        [ObservableProperty]
        public string name = "";

        [ObservableProperty]
        public ObservableCollection<string> selectedBreeds = [];

        [ObservableProperty]
        public string gender = "";

        [ObservableProperty]
        public DateOnly date = DateOnly.FromDateTime(DateTime.Now);

        [ObservableProperty]
        public ObservableCollection<string> breeds = new ObservableCollection<string>();

        [ObservableProperty]
        public ObservableCollection<string> genders = new ObservableCollection<string>();

        [ObservableProperty]
        public string imgPath = "add_image.png";

        private FileResult? icon;

        public bool IsSkipVisible;

        public CreateDogViewModel()
        {
            Breeds = ["A", "B", "C", "D", "E"];
            Genders = ["Male", "Female"];
            UserData.IsOnboarding = IsSkipVisible;
        }

        [RelayCommand]
        private async Task Continue()
        {
            //off while debugging
            //if (!InputCheck())
            //{
            //    await Application.Current!.Windows[0]!.Page!.DisplayAlertAsync("Missing info", "Please fill out all input fields!", "Ok");
            //}
            //else
            //{

                // add API call here

                await Shell.Current.GoToAsync("//home");
            //}
        }
        [RelayCommand]
        private async Task Skip()
        {
            await Shell.Current.GoToAsync("//home");
        }

        private bool InputCheck()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;
            if (string.IsNullOrWhiteSpace(Gender))
                return false;
            if (SelectedBreeds.Count <= 0)
                return false;
            if (icon == null)
                return false;
            return true;
        }

        [RelayCommand]
        private async Task AddImage()
        {
            const string camera = "Take a photo";
            const string gallery = "Select from gallery";
            string action = await Application.Current!.Windows[0].Page!.DisplayActionSheetAsync("Choose an icon...", "Cancel", null, camera, gallery);
            switch (action)
            {
                case camera:
                    var result = await ImageService.TakePhoto();
                    if (result != null)
                    {
                        icon = result;
                        ImgPath = result.FullPath;
                        await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Success!", "Icon has been added successfully!", "Ok");
                    }
                    break;
                case gallery:
                    var result1 = await ImageService.PickPhoto();
                    if (result1 != null)
                    {
                        icon = result1[0];
                        ImgPath = result1[0].FullPath;
                        await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Success!", "Icon has been added successfully!", "Ok");
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
