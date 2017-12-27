using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using Lamp.Plugin;
using Plugin.TextToSpeech;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using OpenWeatherMap;
using System.Diagnostics;
using Plugin.Geolocator;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class JarvisService
    {
        List<InstalledAppsInfo> apps = DependencyService.Get<IOpenApp>().AppInfo();
        public async Task JarvisTalk(string message)
        {
            await CrossTextToSpeech.Current.Speak(message);
        }


        public async Task Commands()
        {
            if (BingSpeechService.Result().StartsWith("open ") == true)
                await OpenApp();
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

                }
        }

        #region Tasks
        public async Task OpenApp()
        {
            await Task.Delay(0);
            string openapp = BingSpeechService.Result().TrimStart("open ".ToCharArray());
            for (int i = 0; i < apps.Count; i++)
            {
                if (apps[i].Name.ToLower() == openapp)
                {
                    DependencyService.Get<IOpenApp>().OpenExternalApp(apps[i].PackageName);
                    break;
                }
            }
        }
        public async Task OpenApp(string name)
        {
            await Task.Delay(0);

            if (Device.RuntimePlatform == Device.Android)
            {
                DependencyService.Get<IOpenApp>().OpenExternalApp(name);
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
                new Coordinates {Latitude=position.Latitude, Longitude=position.Longitude}, MetricSystem.Metric);

            await JarvisTalk($"The sky in {weather.City.Name} is {weather.Clouds.Name}. The temperature is {weather.Temperature.Value} " +
                $"celcius, the temperature today can go up to {weather.Temperature.Max} celcius. The sun will set at {weather.City.Sun.Set.Hour}:" +
                $"{weather.City.Sun.Set.Minute}");
        }
    }
}
#endregion