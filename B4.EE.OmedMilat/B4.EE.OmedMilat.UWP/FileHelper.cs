using System.IO;
using Xamarin.Forms;
using B4.EE.OmedMilat.UWP;
using Windows.Storage;
using System.Diagnostics;

[assembly: Dependency(typeof(FileHelper))]
namespace B4.EE.OmedMilat.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
