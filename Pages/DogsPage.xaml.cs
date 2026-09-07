using DogMeetGo.ViewModels;

namespace DogMeetGo.Pages;

public partial class DogsPage : ContentPage
{
	public DogsViewModel VM { get; set; } = new DogsViewModel();
    public DogsPage()
	{
		InitializeComponent();
		this.BindingContext = VM;
	}
}