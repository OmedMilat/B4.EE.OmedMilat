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
        bool FirstTime;

        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            bingSpeechService = new BingSpeechService();
            jarvisService = new JarvisService();
            FirstTime = true;
            Jarvislogo = "jarvislogo.png";
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

        public ICommand AppearingCommand => new Command(
            async () =>
            {
                if (FirstTime == true)
                {
                    Jarvislogo = "offlinejarvislogo.png";
                    await jarvisService.Sound("startup");
                    await jarvisService.JarvisTalk("Starting up the system..",false);
                    await Task.Delay(1000);
                    Jarvislogo = "jarvislogo.png";
                    FirstTime = false;
                    await jarvisService.Startup();
                }
            });

        public ICommand VisualInfo => new Command(
            async () =>
            {
                Jarvislogo = "offlinejarvislogo.png";
                await jarvisService.VisualInfo();
                Jarvislogo = "jarvislogo.png";
            });

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