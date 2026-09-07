using DogMeetGo.ViewModels;

namespace DogMeetGo.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel VM { get; set; }
        public MainPage()
        {
            InitializeComponent();
            VM = new MainViewModel();
            this.BindingContext = VM;
#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            });
#endif
        }
    }
}
