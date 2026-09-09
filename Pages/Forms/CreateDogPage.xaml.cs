using DogMeetGo.ViewModels.Forms;

namespace DogMeetGo.Pages;

public partial class CreateDogPage : ContentPage
{
    public CreateDogViewModel VM { get; set; } = new CreateDogViewModel();
    public CreateDogPage()
	{
		InitializeComponent();
        this.BindingContext = VM;
	}
}