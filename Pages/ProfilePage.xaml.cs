using DogMeetGo.ViewModels;

namespace DogMeetGo.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfileViewModel VM { get; set; } = new ProfileViewModel();
    public ProfilePage()
	{
		InitializeComponent();
		this.BindingContext = VM;
	}
}