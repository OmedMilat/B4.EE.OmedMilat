using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.System;
using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using System.Collections.Generic;
using Windows.Management.Deployment;
using Windows.ApplicationModel;
using System.Linq;

//namespace B4.EE.OmedMilat.UWP.Services
//{
//    public class OpenAppUWP : IOpenApp
//    {
//        //private static readonly Uri dummyUri = new Uri("mailto:dummy@seznam.cz");

//        //public static async Task<bool> IsAppInstalledAsync(string packageName)
//        //{           
//        //    try
//        //    {
//        //        bool appInstalled;
//        //        LaunchQuerySupportStatus result = await Launcher.QueryUriSupportAsync(dummyUri, LaunchQuerySupportType.Uri, packageName);
//        //        switch (result)
//        //        {
//        //            case LaunchQuerySupportStatus.Available:
//        //            case LaunchQuerySupportStatus.NotSupported:
//        //                appInstalled = true;
//        //                break;
//        //            //case LaunchQuerySupportStatus.AppNotInstalled:
//        //            //case LaunchQuerySupportStatus.AppUnavailable:
//        //            //case LaunchQuerySupportStatus.Unknown:
//        //            default:
//        //                appInstalled = false;
//        //                break;
//        //        }

//        //        Debug.WriteLine($"App {packageName}, query status: {result}, installed: {appInstalled}");
//        //        return appInstalled;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        Debug.WriteLine($"Error checking if app {packageName} is installed. Error: {ex}");
//        //        return false;
//        //    }
//        //}


//        public void OpenExternalApp(string appname)
//        {
//            throw new NotImplementedException();
//        }

//        List<InstalledAppsInfo> IOpenApp.AppInfo()
//        {
//            PackageManager packageManager = new PackageManager();
//            IEnumerable<Package> appInfo = packageManager.FindPackages();
//            return appInfo.Cast<InstalledAppsInfo>().ToList();
//        }
//    }
//}
