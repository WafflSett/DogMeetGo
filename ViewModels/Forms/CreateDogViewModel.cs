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
        public string breedStr = "";

        [ObservableProperty]
        public int? gender;

        [ObservableProperty]
        public DateTime date = DateTime.Now;

        [ObservableProperty]
        public string imgPath = "add_image.png";

        [ObservableProperty]
        public float? weight = null;

        private FileResult? icon;

        public bool IsSkipVisible;
        public List<string> SelectedBreeds = [];

        public CreateDogViewModel()
        {
            UserData.IsOnboarding = IsSkipVisible;
        }

        [RelayCommand]
        private async Task Continue()
        {
            var err = InputCheck();
            if (err != null)
            {
                await Application.Current!.Windows[0]!.Page!.DisplayAlertAsync("Empty fields", err, "Ok");
            }
            else
            {

                // add API call here

                await Shell.Current.GoToAsync("//home");
            }
        }


        [RelayCommand]
        private async Task Skip()
        {
            await Shell.Current.GoToAsync("//home");
        }

        private string? InputCheck()
        {
            // split breeds into list
            SelectedBreeds = BreedStr.Split(",").Select(x => string.IsNullOrWhiteSpace(x) ? x : (x.TrimStart().First().ToString().ToUpper() + x.Substring(1).TrimEnd())).ToList();

            if (string.IsNullOrWhiteSpace(Name))
                return "Please enter your dog's name!";
            if (SelectedBreeds.Count <= 0)
                return "Please enter at least one breed!";
            if (Gender == null)
                return "Please choose your dog's sex!";
            if (Date >= DateTime.Now)
                return "Please enter a date before today!";
            if (Weight == null)
                return "Please enter your dog's weight! (Approximate is fine)";
            if (Weight == 0)
                return "Your dog's weight can't be 0!";
            if (Weight < 0)
                return "Your dog's weight can't be less than 0 kg!";
            if (icon == null)
                icon = new FileResult("paw.png");
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
