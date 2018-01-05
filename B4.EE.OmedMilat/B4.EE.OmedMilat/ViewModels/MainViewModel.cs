using B4.EE.OmedMilat.Domain.Services;
using B4.EE.OmedMilat.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace B4.EE.OmedMilat.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BingSpeechService bingSpeechService;
        public JarvisService jarvisService;
        INavigation navigation;

        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            jarvislogo = "jarvislogo.png";
            bingSpeechService = new BingSpeechService();
            jarvisService = new JarvisService();
        }
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string jarvislogo;
        public string Jarvislogo
        {
            get { return jarvislogo; }
            set
            {
                jarvislogo = value;
                RaisePropertyChanged();
            }
        }

        public async Task VideoNextPage()
        {
            await navigation.PushAsync(new VideoView(JarvisService.videolink));
        }

        public ICommand RecordAudio => new Command(
             async () =>
            {
                Jarvislogo = "offlinejarvislogo.png";

                try
                {
                    await bingSpeechService.RecordAudio();
                    await jarvisService.Commands();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                if (jarvisService.Video() == true)
                {
                    await VideoNextPage();
                    JarvisService.videobool = false;
                }
                Jarvislogo = "jarvislogo.png";
            });


    }
}