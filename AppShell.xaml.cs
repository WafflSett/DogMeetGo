using DogMeetGo.Pages;

namespace DogMeetGo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("walkdetails", typeof(WalkDetailsPage));
            Routing.RegisterRoute("createdog", typeof(CreateDogPage));
            Routing.RegisterRoute("createwalk", typeof(CreateWalkPage));
            Routing.RegisterRoute("createprofile", typeof(CreateProfilePage));
        }
    }
}
