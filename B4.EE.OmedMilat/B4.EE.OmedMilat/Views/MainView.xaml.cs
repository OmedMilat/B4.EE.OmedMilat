using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using B4.EE.OmedMilat.ViewModels;

namespace B4.EE.OmedMilat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(this.Navigation);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(2000);

            //await Task.WhenAll(
            //    SplashGrid.FadeTo(0, 2000),
            //    logo.ScaleTo(10, 2000));
        }
    }
}