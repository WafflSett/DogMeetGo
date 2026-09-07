using DogMeetGo.ViewModels;

namespace DogMeetGo.Pages;

public partial class HomePage : ContentPage
{
	public HomeViewModel VM { get; set; } = new HomeViewModel();
    public HomePage()
	{
		InitializeComponent();
		this.BindingContext = VM;
	}
}