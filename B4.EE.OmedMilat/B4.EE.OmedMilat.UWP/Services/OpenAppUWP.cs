using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using System.Collections.Generic;
using Windows.Management.Deployment;
using Windows.ApplicationModel;
using System.Linq;
using Windows.System;
using System.Threading.Tasks;
using System;
using Windows.Storage;

namespace B4.EE.OmedMilat.UWP.Services
{
    public class OpenAppUWP : IOpenApp
    {
        //private static readonly Uri dummyUri = new Uri("mailto:dummy@seznam.cz");

        //public static async Task<bool> IsAppInstalledAsync(string packageName)
        //{
        //    try
        //    {
        //        bool appInstalled;
        //        LaunchQuerySupportStatus result = await Launcher.QueryUriSupportAsync(dummyUri, LaunchQuerySupportType.Uri, packageName);
        //        switch (result)
        //        {
        //            case LaunchQuerySupportStatus.Available:
        //            case LaunchQuerySupportStatus.NotSupported:
        //                appInstalled = true;
        //                break;
        //            //case LaunchQuerySupportStatus.AppNotInstalled:
        //            //case LaunchQuerySupportStatus.AppUnavailable:
        //            //case LaunchQuerySupportStatus.Unknown:
        //            default:
        //                appInstalled = false;
        //                break;
        //        }

        //        Debug.WriteLine($"App {packageName}, query status: {result}, installed: {appInstalled}");
        //        return appInstalled;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error checking if app {packageName} is installed. Error: {ex}");
        //        return false;
        //    }
        //}


        public async Task OpenExternalApp(string appname)
        {
            await Launcher.LaunchUriAsync(new Uri(appname));
        }

        List<InstalledAppsInfo> IOpenApp.AppInfo()
        {
            //PackageManager packageManager = new PackageManager();

            //IEnumerable<Package> apps = packageManager.FindPackages().ToList();
            List<InstalledAppsInfo> appInfo = new List<InstalledAppsInfo>();
            //for (int i = 0; i < apps.Count(); i++)
            //{
            //    appInfo.Add(new InstalledAppsInfo
            //    {
            //        Name = apps.ElementAt(i).DisplayName,
            //        PackageName = apps.ElementAt(i).Id.FullName
            //    });
            //}
            return appInfo;
        }
    }
}
