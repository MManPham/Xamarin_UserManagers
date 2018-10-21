using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await Navigation.PushAsync(new ListUser());
        }
    }
}