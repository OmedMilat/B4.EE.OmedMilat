using B4.EE.OmedMilat.Domain.Interface;
using System;
using Plugin.MediaManager;
using System.Threading.Tasks;
using Plugin.MediaManager.Abstractions.Enums;
using Windows.Storage;

namespace B4.EE.OmedMilat.UWP.Services
{
    public class OpenMedia : IMedia
    {
        StorageFile file;
        public async Task Playaudio(string which)
        {
            if (which == "startup")
            {
                StorageFolder folder = await Windows.ApplicationModel.Package
                   .Current.InstalledLocation.GetFolderAsync("Assets");
                file = await folder.GetFileAsync("startup.mp3");
            }
            else if (which == "what")
            {
                StorageFolder folder = await Windows.ApplicationModel.Package
                   .Current.InstalledLocation.GetFolderAsync("Assets");
                file = await folder.GetFileAsync("what.wav");
            }
            else if(which == "hall9000")
            {
                StorageFolder folder = await Windows.ApplicationModel.Package
                   .Current.InstalledLocation.GetFolderAsync("Assets");
                file = await folder.GetFileAsync("hall9000.mp3");
            }
            await CrossMediaManager.Current.Play(file.Path, MediaFileType.Audio);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
        }

        private void Current_MediaFinished(object sender, Plugin.MediaManager.Abstractions.EventArguments.MediaFinishedEventArgs e)
        {
            CrossMediaManager.Current.Stop();
        }
    }
}
