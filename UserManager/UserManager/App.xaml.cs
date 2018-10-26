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
        public static IDataStore dataUserReposi;

        public static bool IsUserLoggedIn { get; set; }

        public App(IDataStore UserRepository)
        {

            #if DEBUG
            LiveReload.Init();
            #endif

            InitializeComponent();

            dataUserReposi = UserRepository;
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Views.Login());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
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
