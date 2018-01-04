using B4.EE.OmedMilat.Domain.Interface;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
               await CrossMediaManager.Current.Play(VideoLink, MediaFileType.Video);
           });

        public ICommand DisappearingCommand => new Command(
        async () =>
            {
                await CrossMediaManager.Current.Stop();
            });
    }
}
