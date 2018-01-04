using B4.EE.OmedMilat.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.OmedMilat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoView : ContentPage
    {
        public VideoView(string videolink)
        {
            InitializeComponent();
            BindingContext = new VideoViewModel(videolink, this.Navigation);
        }
    }
}