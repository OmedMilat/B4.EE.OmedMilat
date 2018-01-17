using System.Threading.Tasks;
using B4.EE.OmedMilat.Domain.Interface;
using Android.Media;
using Android.Views;
using Plugin.CurrentActivity;

namespace B4.EE.OmedMilat.Droid.Services
{
    public class OpenMedia : IMedia
    {
        Window window = CrossCurrentActivity.Current.Activity.Window;
        MediaPlayer mediaPlayer;
        public Task Playaudio(string which)
        {
            if (which == "startup")
            {
                mediaPlayer = MediaPlayer
                .Create(Android.App.Application.Context, Resource.Drawable.startup);
            }
            else if(which=="what")
            {
                mediaPlayer = MediaPlayer
                .Create(Android.App.Application.Context, Resource.Drawable.what);
            }
            else if(which == "hall9000")
            {
                mediaPlayer = MediaPlayer
                .Create(Android.App.Application.Context, Resource.Drawable.hall9000);
            }
            mediaPlayer.Start();

            return Task.Delay(0);
        }
    }
}