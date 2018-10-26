using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
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
            string userName = user_name.Text;
            string password = Password.Text;

            if (userName == null && password == null) await DisplayAlert("Warnings", "Name and Password is required!", "Cancle");
            else if (password == null) await DisplayAlert("Warnings", "Password is required!", "Cancle");
            else if(userName == null) await DisplayAlert("Warnings", "Name  is required!", "Cancle");
            else{
                LoginAccept _login_accept = new LoginAccept(userName, password);
                
                if (_login_accept.isAccept())
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
                else await DisplayAlert("Warnings", "Name or Password is not correct!", "Cancle");
            }





        }
    }
}