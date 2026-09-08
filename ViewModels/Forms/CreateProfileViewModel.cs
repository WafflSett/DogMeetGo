using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public string imgPath = "";


        [RelayCommand]
        private async Task AddImage()
        {
            const string camera = "Take a photo";
            const string gallery = "Select from gallery";
            string action = await Application.Current!.Windows[0].Page!.DisplayActionSheetAsync("Choose an icon...", "Cancel", null, camera, gallery);
            switch (action)
            {
                case camera:
                    await TakePhoto();
                    break;
                case gallery:
                    await PickPhoto();
                    break;
                default:
                    break;
            }
        }

        private async Task TakePhoto()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        ImgPath = photo.FullPath;
                        await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Success!", "Icon has been added successfully!", "Ok");
                    }
                }
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Error!", "This feature is not supported by your device!", "Ok");
            }
            catch (PermissionException)
            {
                await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Error!", "Permission to access camera denied!", "Ok");
            }
        }

        private async Task PickPhoto()
        {
            try
            {
                var result = await MediaPicker.PickPhotosAsync(new MediaPickerOptions()
                {
                    Title = "Choose a picture for your profile!"
                });
                if (result != null && result.Count > 0)
                {
                    ImgPath = result[0].FullPath;
                    await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Success!", "Icon has been added successfully!", "Ok");
                }
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Error!", "This feature is not supported by your device!", "Ok");
            }
            catch (PermissionException)
            {
                await Application.Current!.Windows[0].Page!.DisplayAlertAsync("Error!", "Permission to access gallery denied!", "Ok");
            }
        }
    }
}
