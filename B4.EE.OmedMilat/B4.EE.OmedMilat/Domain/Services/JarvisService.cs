using Lamp.Plugin;
using Plugin.TextToSpeech;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class JarvisService
    {
        public async Task JarivsTalk(string message)
        {
           await CrossTextToSpeech.Current.Speak(message); 
        }
        public async Task Commands()
        {
            switch (BingSpeechService.Result())
            {
                case "how are you":
                    await JarivsTalk("I am doing very well, thanks for asking. How about you?");
                    break;

                case "open youtube":
                    await JarivsTalk("I am on it.");
                        break;

                case "turn the flashlight on":
                    await JarivsTalk("There will be light.");
                    CrossLamp.Current.TurnOn();
                    break;

                case "turn the flashlight off":
                    await JarivsTalk("There will be darkness.");
                    CrossLamp.Current.TurnOff();
                    break;

            }
                

        }

    }
}
