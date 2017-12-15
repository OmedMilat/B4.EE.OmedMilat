using B4.EE.OmedMilat.Domain.Models;
using B4.EE.OmedMilat.Domain.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.OmedMilat.ViewModels
{
    public class MainViewModel
        {
        public BingSpeechService bingSpeechService;

        public MainViewModel()
        {
            bingSpeechService = new BingSpeechService();
        }

        public ICommand RecordAudio => new Command(
            async () =>
            {
                await bingSpeechService.RecordAudio();
                await bingSpeechService.test();
            });

    }
}