using System.Collections.ObjectModel;

namespace DogMeetGo.Views;

public partial class PickerView : ContentView
{
	public static readonly BindableProperty ItemsSourceProp = BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<string>), typeof(PickerView), defaultValueCreator: bindable=>new ObservableCollection<string>());

	public static readonly BindableProperty SelectedItemsProp = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<string>), typeof(PickerView), defaultValueCreator: bindable=> new ObservableCollection<string>());

    public ObservableCollection<string> ItemsSource
    {
		get => (ObservableCollection<string>)GetValue(ItemsSourceProp);
		set => SetValue(ItemsSourceProp, value);
	}

    public ObservableCollection<string> SelectedItems {
		get => (ObservableCollection<string>)GetValue(SelectedItemsProp);
		set => SetValue(SelectedItemsProp, value); 
	}

    public PickerView()
	{
		InitializeComponent();
		this.BindingContext = this;
	}
}