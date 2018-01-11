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
using System.Diagnostics;

namespace B4.EE.OmedMilat.UWP.Services
{
    public class OpenAppUWP : IOpenApp
    {
        public List<InstalledAppsInfo> Applinks()
        {
            List<InstalledAppsInfo> installedAppsInfo = new List<InstalledAppsInfo>();
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Instagram", PackageName = "https://www.instagram.com/" });
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Facebook", PackageName = "https://www.facebook.com/" });
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Netflix", PackageName = "https://www.netflix.com/" });
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Youtube", PackageName = "https://www.youtube.com/" });
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Google", PackageName = "https://www.google.be/" });
            installedAppsInfo.Add(new InstalledAppsInfo { Name = "Maps", PackageName = "https://www.google.be/maps/" });
            return installedAppsInfo;
        }
        
        public async Task OpenExternalApp(string appname)
        {
            await Launcher.LaunchUriAsync(new Uri(appname));
        }

        List<InstalledAppsInfo> IOpenApp.AppInfo()
        {
            List<InstalledAppsInfo> appInfo = new List<InstalledAppsInfo>();
            for (int i = 0; i < Applinks().Count; i++)
            {
                appInfo.Add(new InstalledAppsInfo
                {
                    Name = Applinks()[i].Name,
                    PackageName = Applinks()[i].PackageName
                });
            }
            return appInfo;
        }
    }
}
