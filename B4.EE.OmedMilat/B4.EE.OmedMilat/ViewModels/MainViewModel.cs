using B4.EE.OmedMilat.Domain.Interface;
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
        Stopwatch testo = new Stopwatch();
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

        async Task Test()
        {
            testo.Start();
            await bingSpeechService.RecordAudio();
            while (BingSpeechService.Result() == null && testo.Elapsed.Seconds < 15)
            {
                if (testo.Elapsed.Seconds > 14)
                {
                    testo.Restart();
                    await bingSpeechService.StopRecording();
                    await bingSpeechService.RecordAudio();
                }
            }
            await jarvisService.Commands();
        }
        public ICommand AppearingCommand => new Command(
            async () =>
            {
                if (FirstTime == true)
                {
                    Jarvislogo = "offlinejarvislogo.png";
                    await Task.Delay(2900);
                    Jarvislogo = "jarvislogo.png";
                    FirstTime = false;
                }
            });

        public ICommand VisualInfo => new Command(
            async () =>
            {
                try
                {
                    await jarvisService.VisualInfo();
                }
                catch { }
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