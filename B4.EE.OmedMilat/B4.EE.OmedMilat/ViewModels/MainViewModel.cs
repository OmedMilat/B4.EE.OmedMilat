using B4.EE.OmedMilat.Domain.Interface;
using B4.EE.OmedMilat.Domain.Models;
using B4.EE.OmedMilat.Domain.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.OmedMilat.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BingSpeechService bingSpeechService;
        public JarvisService jarvisService;
        public MainViewModel()
        {
            jarvislogo = "jarvislogo.png";
            bingSpeechService = new BingSpeechService();
            jarvisService = new JarvisService();
            
        }
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        public ICommand RecordAudio => new Command(
             async () =>
            {
                Jarvislogo = "offlinejarvislogo.png";
                //await bingSpeechService.RecordAudio();             
                await jarvisService.Hall9000();
                Jarvislogo = "jarvislogo.png";
            });


    }
}