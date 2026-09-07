namespace DogMeetGo.Views;

public partial class HeaderView : ContentView
{
	public static readonly BindableProperty TitleProp = BindableProperty.Create(nameof(Title), typeof(string), typeof(HeaderView), string.Empty);

    public string Title { 
		get => (string)GetValue(TitleProp);
		set => SetValue(TitleProp, value); 
	}

    public HeaderView()
	{
		InitializeComponent();
		this.BindingContext = this;
	}
}