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
using Newtonsoft.Json;
using Acr.UserDialogs;
using System.Diagnostics;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class JarvisService
    {
        BingVisionService bingVisionService = new BingVisionService();
        List<InstalledAppsInfo> apps = DependencyService.Get<IOpenApp>().AppInfo();
        Task<List<JarvisCommands>> jokes = App.Database.GetAllCommads();
        Random random = new Random();
        ToastConfig Toast;

        public static bool videobool;
        public static string videolink;
        public bool FromCamera = true;
        public bool Forecast = false;

        public async Task JarvisTalk(string message, bool toast = true)
        {
            if (toast)
            {
                Toast = new ToastConfig(message);
                Toast.SetDuration(3300);
                Toast.SetBackgroundColor(System.Drawing.Color.FromArgb(10, 110, 144));
                Toast.SetMessageTextColor(System.Drawing.Color.White);
                UserDialogs.Instance.Toast(Toast);
            }
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
                    case "what's the weather tomorrow":
                        Forecast = true;
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
                    case "mute the volume":
                        await ChangeVolume(3);
                        await JarvisTalk("Okay i set it to the lowest level");
                        break;

                    case "turn down the brightness":
                    case "lower the brightness":
                        await ChangeScreenBrightness(0);
                        await JarvisTalk("No Problem. i've lowered the brightness.");
                        break;
                    case "turn up the brightness":
                    case "raise the brightness":
                        await ChangeScreenBrightness(1);
                        await JarvisTalk("Got it. I increased the display brightness for you.");
                        break;

                    case "can you go away":
                        await Sound("hall9000");
                        break;

                    case "play video":
                        videobool = true;
                        Video();
                        break;

                    case "tell me a joke":
                        await JarvisTalk(GetRandomJokes());
                        break;

                    case "you need to see something":
                        await JarvisTalk("Alright, lets take a picture.");
                        await VisualInfo();
                        break;
                    case "i want to show you something":
                        await JarvisTalk("Ok then show it to me!");
                        FromCamera = false;
                        await VisualInfo();
                        break;

                    case "you need to go":
                        await ExitCurrentApp();
                        break;

                    case "tell me about yourself":
                        await JarvisTalk("My name is Jarvis, i am 1 month old. I was once an boring empty xamarin application, " +
                            "till my creator got an assignment from school to make something unique. So here am i inspired from the movie" +
                            "Iron Man, i am far from good but with the time as i get older my creator will make me better",false);
                        break;

                    case "what":
                        await Sound("what");
                        break;
                }
        }

        #region Tasks&Methodes
        public async Task ExitCurrentApp()
        {
            await JarvisTalk("Thanks for listening class of Milat. It was a pleasure being here. I wish you all best of luck with the exams.",false);
            DependencyService.Get<ISystemSetting>().Vibrate(1500);
            DependencyService.Get<ISystemSetting>().CloseApp();
        }
        public async Task VisualInfo()
        {
            if (FromCamera)
                await bingVisionService.TakePhoto();
            else
            {
                await bingVisionService.PhotoFromGallery();
                FromCamera = true;
            }

            var result = JsonConvert.DeserializeObject<BingVisionResult>(BingVisionService.ResponseString);
            if (result.Faces.Count == 0 || result.Faces.Count > 1)
                await JarvisTalk($"I see {result.Description.Captions[0].Text}");

            else if (result.Faces[0].Gender == "Female")
            {
                await JarvisTalk($"I see {result.Description.Captions[0].Text}. She looks " +
                    $"like {result.Faces[0].Age} years old");
            }
            else
            {
                await JarvisTalk($"I see {result.Description.Captions[0].Text}. He looks " +
                  $"like {result.Faces[0].Age} years old");
            }
        }

        public string GetRandomJokes()
        {
            int rondom = random.Next(0, jokes.Result.Count);
            return jokes.Result[rondom].Joke;
        }
        public bool Video()
        {
            videolink = "https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4";
            return videobool;
        }
        public async Task Sound(string which)
        {
            await DependencyService.Get<IMedia>().Playaudio(which);
        }

        public async Task ChangeScreenBrightness(int brightness)
        {
           
            await Task.Delay(0);
            //0 = lower, 1 = raise,
            DependencyService.Get<ISystemSetting>().ChangeBrightness(brightness);
        }

        public async Task ChangeVolume(int volume)
        {
            
            await Task.Delay(0);
            //0 = lower, 1 = raise, 3 = mute
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
            string openapp = BingSpeechService.Result().TrimStart("open ".ToCharArray());
            for (int i = 0; i < apps.Count; i++)
            {
                if (apps[i].Name.ToLower() == openapp)
                {
                    await JarvisTalk($"Opening {openapp}");
                    await DependencyService.Get<IOpenApp>().OpenExternalApp(apps[i].PackageName);
                    break;
                }
            }
        }

        public async Task GetWeather()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            if (!locator.IsGeolocationEnabled)
                await JarvisTalk("Looks like your gps is currently off. Make sure to turn on the gps.");
            else
            {
                await JarvisTalk("Hold on i am searching your current location.");
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 15000);
                OpenWeatherMapClient client = new OpenWeatherMapClient(ApiConstants.OpenWeatherMapApi);

                if (!Forecast)
                {
                    var weather = await client.CurrentWeather.GetByCoordinates(
                        new Coordinates { Latitude = position.Latitude, Longitude = position.Longitude }, MetricSystem.Metric);

                    await JarvisTalk($"Looks like there is a {weather.Clouds.Name} in {weather.City.Name}. The current temperature is {weather.Temperature.Value} " +
                    $"celcius, the temperature today can go up to {weather.Temperature.Max} celcius and go down as to {weather.Temperature.Min} celcius. " +
                    $"The sun will set at {weather.City.Sun.Set.Hour}:{weather.City.Sun.Set.Minute}",false);
                }
                else
                {
                    var weather = await client.Forecast.GetByCoordinates(
                    new Coordinates { Latitude = position.Latitude, Longitude = position.Longitude }, false, MetricSystem.Metric);

                    await JarvisTalk($"Tomorrow it Looks like there will be a {weather.Forecast[7].Clouds} in {weather.Location.Name}. " +
                    $"The temperature will be {weather.Forecast[7].Temperature.Max} The sun will set at {weather.Sun.Set.Hour}:{weather.Sun.Set.Minute}",false);

                    Forecast = false;

                }

            }
        }
    }
}
#endregion