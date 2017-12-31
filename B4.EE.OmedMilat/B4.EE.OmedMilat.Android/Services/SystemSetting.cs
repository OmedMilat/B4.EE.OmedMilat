using Android.App;
using Android.Content;
using Android.Media;
using Android.Views;
using B4.EE.OmedMilat.Domain.Interface;
using Plugin.CurrentActivity;
using Android.Provider;
using System;

namespace B4.EE.OmedMilat.Droid.Services
{
    public class SystemSetting : Activity, ISystemSetting
    {
        Window window = CrossCurrentActivity.Current.Activity.Window;
        public void ChangeVolume(int volume)
        {
            AudioManager am = (AudioManager)window.Context.GetSystemService(Context.AudioService);

            if (volume == 0)
                am.AdjustStreamVolume(Stream.Ring, Adjust.Lower, VolumeNotificationFlags.ShowUi);
            else
                am.AdjustStreamVolume(Stream.Ring, Adjust.Raise, VolumeNotificationFlags.ShowUi);
        }

        public void ChangeBrightness(int brightness)
        {
            int CurrScreenBrightness = Settings.System.GetInt(
                window.Context.ContentResolver, Settings.System.ScreenBrightness);

            if (brightness == 0)
            {
                Settings.System.PutInt(window.Context.ContentResolver,
                Settings.System.ScreenBrightness, Math.Max(0,CurrScreenBrightness-35));
            }
            else
            {
                Settings.System.PutInt(window.Context.ContentResolver,
                Settings.System.ScreenBrightness, Math.Min(255, CurrScreenBrightness + 35));
            }
        }
    }
}