using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserManager.Services;
using UserManager.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UserManager
{
    public partial class App : Application
    {
        public static IDataStore<User> dataUserReposi;
        public App(IDataStore<User> UserRepository)
        {

            #if DEBUG
            LiveReload.Init();
            #endif

            InitializeComponent();

            dataUserReposi = UserRepository;

            MainPage = new NavigationPage(new UserManager.Views.ListUser());
;            
            
        }
        public App()
        {

            InitializeComponent();

        }

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
