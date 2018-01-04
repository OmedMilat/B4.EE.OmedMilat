using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using Lamp.Plugin;
using Plugin.TextToSpeech;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using OpenWeatherMap;
using Plugin.Geolocator;
using System;
using B4.EE.OmedMilat.ViewModels;
using B4.EE.OmedMilat.Views;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class JarvisService
    {
        List<InstalledAppsInfo> apps = DependencyService.Get<IOpenApp>().AppInfo();
        public static bool videobool;
        public static string videolink;
        public async Task JarvisTalk(string message)
        {
            await CrossTextToSpeech.Current.Speak(message);
        }

        public async Task Commands()
        {
            if (BingSpeechService.Result().StartsWith("open ") == true)
                await OpenApp();
            else
            if (BingSpeechService.Result().StartsWith("search ") == true)
            {
                await SearchGoogle();
            }
            else
                switch (BingSpeechService.Result())
                {
                    case "how are you":
                        await JarvisTalk("I am doing very well, thanks for asking. How about you?");
                        break;

                    case "what's the weather like":
                        await GetWeather();
                        break;

                    case "turn the flashlight on":
                        await JarvisTalk("There will be light.");
                        CrossLamp.Current.TurnOn();
                        break;
                    case "turn the flashlight off":
                        await JarvisTalk("There will be darkness.");
                        CrossLamp.Current.TurnOff();
                        break;

                    case "turn down the volume":
                    case "lower the volume":
                        await ChangeVolume(0);
                        break;
                    case "turn up the volume":
                    case "raise the volume":
                        await ChangeVolume(1);
                        break;

                    case "turn down the brightness":
                    case "lower the brightness":
                        await ChangeScreenBrightness(0);
                        break;
                    case "turn up the brightness":
                    case "raise the brightness":
                        await ChangeScreenBrightness(1);
                        break;

                    case "can you go away":
                        await Hall9000();
                        break;

                    case "play video":
                        videobool = true;
                        Video();
                        break;
                }
        }

        #region Tasks   
        public bool Video()
        {
            videolink = "https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4";
            return videobool;
        }
        public async Task Hall9000()
        {
            //https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3
            await DependencyService.Get<IMedia>().Playaudio();
        }

        public async Task ChangeScreenBrightness(int brightness)
        {
            await Task.Delay(0);
            DependencyService.Get<ISystemSetting>().ChangeBrightness(brightness);
        }

        public async Task ChangeVolume(int volume)
        {
            await Task.Delay(0);
            DependencyService.Get<ISystemSetting>().ChangeVolume(volume);
        }

        public async Task SearchGoogle()
        {
            await Task.Delay(0);
            string browsegoogle = BingSpeechService.Result().TrimStart("search ".ToCharArray()).Replace(" ", "+");
            Device.OpenUri(new Uri($"http://www.google.com/search?q= {browsegoogle}"));
        }

        public async Task OpenApp()
        {
            await Task.Delay(0);
            string openapp = BingSpeechService.Result().TrimStart("open ".ToCharArray());
            for (int i = 0; i < apps.Count; i++)
            {
                if (apps[i].Name.ToLower() == openapp)
                {
                    await DependencyService.Get<IOpenApp>().OpenExternalApp(apps[i].PackageName);
                    break;
                }
            }
        }
        public async Task OpenApp(string name)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                await DependencyService.Get<IOpenApp>().OpenExternalApp(name);
            }
            else if (Device.RuntimePlatform == Device.Windows)
            {
                //Device.OpenUri(new Uri(link));
            }

        }

        public async Task GetWeather()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 15000);

            OpenWeatherMapClient client = new OpenWeatherMapClient("200510b1716274cf3afd3f5b71b0b73b");
            var weather = await client.CurrentWeather.GetByCoordinates(
                new Coordinates { Latitude = position.Latitude, Longitude = position.Longitude }, MetricSystem.Metric);

            await JarvisTalk($"The sky in {weather.City.Name} is {weather.Clouds.Name}. The temperature is {weather.Temperature.Value} " +
                $"celcius, the temperature today can go up to {weather.Temperature.Max} celcius. The sun will set at {weather.City.Sun.Set.Hour}:" +
                $"{weather.City.Sun.Set.Minute}");
        }
    }
}
#endregion