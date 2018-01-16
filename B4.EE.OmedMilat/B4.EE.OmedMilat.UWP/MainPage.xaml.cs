using B4.EE.OmedMilat.UWP.Services;

namespace B4.EE.OmedMilat.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.Forms.DependencyService.Register<OpenAppUWP>();
            Xamarin.Forms.DependencyService.Register<OpenMedia>();
            Xamarin.Forms.DependencyService.Register<SystemSetting>();
            LoadApplication(new OmedMilat.App());
        }
    }
}
