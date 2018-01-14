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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(500);
            if (FirstTime == true)
            {

                await Task.WhenAll(
                logo.FadeTo(0.4, 1000),
                logo.ScaleTo(10, 1000, Easing.CubicIn));

                await Task.WhenAll(
                logo.FadeTo(1, 1000),
                logo.ScaleTo(1, 1000));

                FirstTime = false;
            }

        }
    }
}