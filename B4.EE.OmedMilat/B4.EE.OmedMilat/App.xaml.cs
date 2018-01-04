using B4.EE.OmedMilat.Views;

using Xamarin.Forms;

namespace B4.EE.OmedMilat
{
    public partial class App : Application
    {
        //static Repository database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }

        //public static Repository Database
        //{
        //    get
        //    {
        //        if(database == null)
        //        {
        //            database = new Repository(DependencyService.Get<IFileHelper>().GetLocalFilePath("Jarvis.db3")); 
        //        }
        //        return database;
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
