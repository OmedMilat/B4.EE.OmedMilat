using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using System.Collections.Generic;
using Windows.System;
using System.Threading.Tasks;
using System;

namespace B4.EE.OmedMilat.UWP.Services
{
    public class OpenAppUWP : IOpenApp
    {
        public List<InstalledAppsInfo> Applinks()
        {
            List<InstalledAppsInfo> installedAppsInfo = new List<InstalledAppsInfo>
            {
                new InstalledAppsInfo { Name = "Instagram", PackageName = "https://www.instagram.com/" },
                new InstalledAppsInfo { Name = "Facebook", PackageName = "https://www.facebook.com/" },
                new InstalledAppsInfo { Name = "Netflix", PackageName = "https://www.netflix.com/" },
                new InstalledAppsInfo { Name = "Youtube", PackageName = "https://www.youtube.com/" },
                new InstalledAppsInfo { Name = "Google", PackageName = "https://www.google.be/" },
                new InstalledAppsInfo { Name = "Maps", PackageName = "https://www.google.be/maps/" }
            };
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
