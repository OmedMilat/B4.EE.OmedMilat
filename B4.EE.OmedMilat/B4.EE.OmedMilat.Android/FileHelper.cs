using System;
using System.IO;
using Xamarin.Forms;
using B4.EE.OmedMilat.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace B4.EE.OmedMilat.Droid 
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}