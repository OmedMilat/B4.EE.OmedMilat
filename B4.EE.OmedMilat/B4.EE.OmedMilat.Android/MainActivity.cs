using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using B4.EE.OmedMilat.Droid.Services;

namespace B4.EE.OmedMilat.Droid
{
    [Activity(Label = "B4.EE.OmedMilat", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            this.Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TurnScreenOn);

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.Forms.DependencyService.Register<OpenAppAndroid>();
            Xamarin.Forms.DependencyService.Register<SystemSetting>();
            Xamarin.Forms.DependencyService.Register<OpenMedia>();
            LoadApplication(new App());
        }
    }
}

