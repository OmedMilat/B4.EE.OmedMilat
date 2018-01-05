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
            string path = ApplicationData.Current.LocalFolder.Path;
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);

            CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }
        public static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                string assets = "Assets/Jarvis.db3";
                File.Copy(assets, dbPath, true);
            }
        }
    }
}
