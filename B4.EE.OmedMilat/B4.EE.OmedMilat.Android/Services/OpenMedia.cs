using System.Threading.Tasks;
using B4.EE.OmedMilat.Domain.Interface;
using Plugin.MediaManager;
using Android.Media;
using Xamarin.Forms;
using System;

//[assembly: Dependency(typeof(B4.EE.OmedMilat.Droid.Services.OpenMedia))]
namespace B4.EE.OmedMilat.Droid.Services
{
    public class OpenMedia : IMedia
    {
        //MediaPlayer _mediaPlayer;
        public async Task Playaudio()
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Resources) + "/" + "hall9000.mp3";
            await CrossMediaManager.Current.Play("");

            //_mediaPlayer = MediaPlayer
            //    .Create(global::Android.App.Application.Context, Resource.Drawable.hall9000);
            //_mediaPlayer.Start();
            //return Task.Delay(0);
        }
    }
}