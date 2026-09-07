using DogMeetGo.ViewModels;

namespace DogMeetGo.Pages;

public partial class DiscoverPage : ContentPage
{
	public DiscoverViewModel VM { get; set; } = new DiscoverViewModel();
    public DiscoverPage()
	{
		InitializeComponent();
		this.BindingContext = VM;
	}
}