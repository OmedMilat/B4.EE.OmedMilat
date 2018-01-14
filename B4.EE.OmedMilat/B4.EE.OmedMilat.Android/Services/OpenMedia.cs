using System.Threading.Tasks;
using B4.EE.OmedMilat.Domain.Interface;
using Android.Media;
using Android.Views;
using Plugin.CurrentActivity;

//[assembly: Dependency(typeof(B4.EE.OmedMilat.Droid.Services.OpenMedia))]
namespace B4.EE.OmedMilat.Droid.Services
{
    public class OpenMedia : IMedia
    {
        Window window = CrossCurrentActivity.Current.Activity.Window;
        MediaPlayer _mediaPlayer;
        public Task Playaudio()
        {
            _mediaPlayer = MediaPlayer
                .Create(global::Android.App.Application.Context, Resource.Drawable.hall9000);
            _mediaPlayer.Start();
            return Task.Delay(0);
        }
    }
}