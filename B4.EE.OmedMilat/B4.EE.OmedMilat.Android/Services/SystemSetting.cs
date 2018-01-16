using Android.App;
using Android.Content;
using Android.Media;
using Android.Views;
using B4.EE.OmedMilat.Domain.Interface;
using Plugin.CurrentActivity;
using Android.Provider;
using System;
using Android.OS;

namespace B4.EE.OmedMilat.Droid.Services
{
    public class SystemSetting : Activity, ISystemSetting
    {
        Window window = CrossCurrentActivity.Current.Activity.Window;
        public void ChangeVolume(int volume)
        {
            AudioManager am = (AudioManager)window.Context.GetSystemService(Context.AudioService);
            if (volume == 0)
            {
                am.AdjustStreamVolume(Stream.Music, Adjust.Lower, VolumeNotificationFlags.ShowUi);
                am.AdjustStreamVolume(Stream.Ring, Adjust.Lower, VolumeNotificationFlags.RemoveSoundAndVibrate);
                am.AdjustStreamVolume(Stream.Notification, Adjust.Lower, VolumeNotificationFlags.RemoveSoundAndVibrate);
                am.AdjustStreamVolume(Stream.System, Adjust.Lower, VolumeNotificationFlags.RemoveSoundAndVibrate);
            }
            else if (volume == 1)
            {
                am.RingerMode = RingerMode.Normal;
                am.AdjustStreamVolume(Stream.Music, Adjust.Raise, VolumeNotificationFlags.ShowUi);
                am.AdjustStreamVolume(Stream.Ring, Adjust.Raise, VolumeNotificationFlags.RemoveSoundAndVibrate);
                am.AdjustStreamVolume(Stream.Notification, Adjust.Raise, VolumeNotificationFlags.RemoveSoundAndVibrate);
                am.AdjustStreamVolume(Stream.System, Adjust.Raise, VolumeNotificationFlags.RemoveSoundAndVibrate);
            }
            else
            {
                am.RingerMode = RingerMode.Vibrate;
                am.AdjustStreamVolume(Stream.Music, Adjust.Mute, VolumeNotificationFlags.ShowUi);
                am.AdjustStreamVolume(Stream.Notification, Adjust.Mute, VolumeNotificationFlags.RemoveSoundAndVibrate);
                am.AdjustStreamVolume(Stream.System, Adjust.Mute, VolumeNotificationFlags.RemoveSoundAndVibrate);
            }
        }

        public void ChangeBrightness(int brightness)
        {
            int CurrScreenBrightness = Settings.System.GetInt(
                window.Context.ContentResolver, Settings.System.ScreenBrightness);

            if (brightness == 0)
            {
                Settings.System.PutInt(window.Context.ContentResolver,
                Settings.System.ScreenBrightness, Math.Max(0, CurrScreenBrightness - 35));
            }
            else
            {
                Settings.System.PutInt(window.Context.ContentResolver,
                Settings.System.ScreenBrightness, Math.Min(255, CurrScreenBrightness + 35));
            }
        }

        public void Vibrate(int ms)
        {
            using (Vibrator vibrate = (Vibrator)window.Context.GetSystemService(Context.VibratorService))
            {
                if (!vibrate.HasVibrator)
                    return;

                vibrate.Vibrate(ms);
            }
        }
        public void CloseApp()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}