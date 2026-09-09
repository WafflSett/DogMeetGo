using DogMeetGo.ViewModels.Forms;

namespace DogMeetGo.Pages;

public partial class CreateProfilePage : ContentPage
{
	public CreateProfileViewModel VM { get; set; } = new CreateProfileViewModel();
    public CreateProfilePage()
	{
		InitializeComponent();
		this.BindingContext = VM;
	}
}