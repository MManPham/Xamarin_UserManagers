using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using UserManager.Views;

namespace UserManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LogoXamarin.Source = ImageSource.FromResource("UserManager.Assets.Image.xamarin.png");

        }
        async void btnRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        async void btnForgetPw(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgetPw());
        }

        async void submit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListUser());
        }
    }
}
