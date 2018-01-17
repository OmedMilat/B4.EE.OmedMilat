using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.OmedMilat.ViewModels
{
    public class VideoViewModel
    {
        INavigation navigation;
        string VideoLink;
        public VideoViewModel(string videolink, INavigation navigation)
        {
            this.navigation = navigation;
            VideoLink = videolink;
        }

        public ICommand AppearingCommand => new Command(
        async () =>
           {
               try
               {
                   await CrossMediaManager.Current.Play(VideoLink, MediaFileType.Video);
               }
               catch
               {
                   await CrossMediaManager.Current.Play("https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4", MediaFileType.Video);
               }
           });

        public ICommand DisappearingCommand => new Command(
        async () =>
            {
                await CrossMediaManager.Current.Stop();
            });
    }
}
