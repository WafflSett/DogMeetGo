using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DogMeetGo.Classes;
using DogMeetGo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogMeetGo.ViewModels.Forms
{
    public partial class CreateProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        public string name = "";

        [ObservableProperty]
        public string city = "";

        [ObservableProperty]
        public string about = "";

        [ObservableProperty]
        public string imgPath = "add_image.png";

        private FileResult? icon;

        public CreateProfileViewModel()
        {
            UserData.IsOnboarding = true;
        }


        [RelayCommand]
        private async Task Continue()
        {
            //off while debugging
            var input = InputCheck();
            if (input != null)
            {
                await Application.Current!.Windows[0]!.Page!.DisplayAlertAsync("Empty fields", input, "Ok");
            }
            else
            {

                // add API call here
                await Shell.Current.GoToAsync("//createdog");
            }
        }

        private string? InputCheck()
        {

            if (string.IsNullOrWhiteSpace(Name))
                return "Please enter your name!";
            if (string.IsNullOrWhiteSpace(City))
                return "Please enter your city/neighbourhood";
            if (icon == null)
                icon = new FileResult("user.png");
            return null;
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
