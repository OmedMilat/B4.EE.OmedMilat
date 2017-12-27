using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using B4.EE.OmedMilat.Domain.Interface;
using Xamarin.Forms;
using Android.Content.PM;
using System.Collections.Generic;
using System.Collections;
using System;
using B4.EE.OmedMilat.Domain.Models;

namespace B4.EE.OmedMilat.Droid
{
    class OpenAppAndroid : Activity, IOpenApp
    {
        public OpenAppAndroid() { }

        

        public void OpenExternalApp(string appname)
        {
            Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(appname);

            // If not NULL run the app, if not, take the user to the app store
            if (intent != null)
            {
                intent.AddFlags(ActivityFlags.NewTask);
                Forms.Context.StartActivity(intent);
            }
            else
            {
                intent = new Intent(Intent.ActionView);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetData(Android.Net.Uri.Parse("market://details?id=" + appname));
                Forms.Context.StartActivity(intent);
            }
        }

        List<InstalledAppsInfo> IOpenApp.AppInfo()
        {
            IList<ApplicationInfo> apps = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            List<InstalledAppsInfo> appInfo = new List<InstalledAppsInfo>();
            for (int i = 0; i < apps.Count; i++)
            {
                appInfo.Add(new InstalledAppsInfo
                {
                    Name = apps[i].LoadLabel(Android.App.Application.Context.PackageManager),
                    PackageName = apps[i].PackageName
                });
            }
            return appInfo;
        }
    }
}
