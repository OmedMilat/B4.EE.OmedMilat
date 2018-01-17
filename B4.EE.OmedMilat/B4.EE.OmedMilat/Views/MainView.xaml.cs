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
        bool FirstTime;
        public MainView()
        {
            InitializeComponent();
            FirstTime = true;
            BindingContext = new MainViewModel(this.Navigation);
        }

        //Splash animatie met "Task.Whenall()"
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(700);
            if (FirstTime == true)

            { 
                await Task.WhenAll(
                logo.FadeTo(0.4, 1200),
                logo.ScaleTo(10, 1200, Easing.SpringOut));
                
                await Task.WhenAll(
                logo.FadeTo(1, 1200),
                logo.ScaleTo(1, 1200));
                FirstTime = false;
            }
        }
    }
}