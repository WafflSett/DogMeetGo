using System;
using System.Collections.Generic;
using System.Text;

namespace DogMeetGo.Services
{
    public static class ImageService
    {
        public static async Task<FileResult?> TakePhoto()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        return photo;
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
            return null;
        }

        public static async Task<List<FileResult>?> PickPhoto()
        {
            try
            {
                var result = await MediaPicker.PickPhotosAsync(new MediaPickerOptions()
                {
                    Title = "Choose a picture for your profile!"
                });
                if (result != null && result.Count > 0)
                {
                    return result;
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
            return null;
        }
    }
}
